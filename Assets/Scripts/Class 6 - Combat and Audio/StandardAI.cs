using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StandardAI : UnitAI
{
    enum StandardAIState {  Moving, Attacking, Dead }
    StandardAIState aiState = StandardAIState.Moving;

    [Space(10)]
    [SerializeField] float attackRange = 1;
    [SerializeField] float attackDamage = 1;
    [SerializeField] float attackCooldown = 1;
    float attackCooldownTimer = 0;
    [SerializeField] GameObject attackPrefab;
    GameObject target;

    public override void RunAI()
    {
        switch (aiState)
        {
            case StandardAIState.Moving:
                RunMovement();
                break;
            case StandardAIState.Attacking:
                RunAttacking();
                break;
            case StandardAIState.Dead:
                RunDead();
                break;
        }
    }

    void RunMovement()
    {
        base.RunAI();
    }
    // --------------------------------------------
    // If you still have a target, go through standard attack mode
    // else, try to get a new target
    // ----- Standard Attack Mode -----
    //      If you are within attack range of your target, attack it
    //          - Set the agent so you stand still
    //          - Count your attack timer, modified by the attackCooldown variable
    //          - If your attack timer is up
    //              - Reset your attack timer
    //              - If the attack is a ranged attack, shoot the bow
    //              - otherwise, melee attack
    //      else chase it
    // ----- Get New Target -----
    //      Get the nearby colliders
    //      Check which are buildings or units and save the last one
    //      If we didn't find a target, start moving again
    void RunAttacking()
    {
        // If you still have a target, go through standard attack mode
        // else, try to get a new target
        if (target != null) RunStandardAttackMode();
        else AttemptToAcquireNewTarget();
    }
    void RunStandardAttackMode()
    {
        // If you are within attack range of your target, attack it
        // else chase it
        if (TargetInRange())
        {
            // Set the agent so you stand still
            StandStill();

            RunAttack();
        }
        else
        {
            // Chase the enemy
            ChaseTarget();
        }
    }

    void RunAttack()
    {
        // Count your attack timer, modified by the attackCooldown variable
        attackCooldownTimer += Time.deltaTime / attackCooldown;
        // If your attack timer is up
        if (attackCooldownTimer > 1)
        {
            // Reset your attack timer
            attackCooldownTimer -= 1;

            // If the attack is a ranged attack, shoot the bow
            // otherwise, melee attack
            RunAttackAnimations();

            // Spawn the attack at the enemy
            SpawnAttackPrefab();
        }
    }
    void RunAttackAnimations()
    {
        if (attackRange > 1.5f) GetComponent<UnitAnimator>().AnimateBowAttack();
        else GetComponent<UnitAnimator>().AnimateMeleeAttack();
    }
    void SpawnAttackPrefab()
    {
        GameObject newAttack = Instantiate(attackPrefab, transform.position, Quaternion.identity);

        Vector3 attackTrajectory = (target.transform.position - transform.position);
        newAttack.GetComponent<Bullet>().InitializeBullet(GetFactionID(), attackTrajectory, attackDamage);
    }
    void StandStill()
    {
        GetComponent<NavMeshAgent>().destination = transform.position;
    }
    void ChaseTarget()
    {
        GetComponent<NavMeshAgent>().destination = target.transform.position;
    }
    void AttemptToAcquireNewTarget()
    {
        // Get the nearby colliders
        Collider[] potentialTargets = Physics.OverlapSphere(transform.position, 8);

        // Check which are buildings or units and save the last one
        foreach (Collider potentialTarget in potentialTargets)
        {
            if (potentialTarget.gameObject.GetComponent<Building>())
            {
                if (potentialTarget.gameObject.GetComponent<Building>().GetFactionID() != GetFactionID())
                    target = potentialTarget.gameObject;
            }
            if (potentialTarget.gameObject.GetComponent<UnitCombat>())
            {
                if (potentialTarget.gameObject.GetComponent<UnitCombat>().GetFactionID() != GetFactionID())
                    target = potentialTarget.gameObject;
            }
        }

        // If we didn't find a target, start moving again
        if (target == null) aiState = StandardAIState.Moving;
    }
    bool TargetInRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) <= attackRange;
    }
    void AttackBuilding(GameObject buildingToAttack)
    {
        if(buildingToAttack.GetComponent<Building>().GetFactionID() != GetFactionID())
        {
            aiState = StandardAIState.Attacking;
            target = buildingToAttack;
        }
    }
    void AttackUnit(GameObject unitToAttack)
    {
        if (unitToAttack.GetComponent<UnitCombat>().GetFactionID() != GetFactionID())
        {
            aiState = StandardAIState.Attacking;
            target = unitToAttack;
        }
    }
    // --------------------------------------------
    void RunDead()
    {
        // Nothing- the thing is dead
    }

    public override void TriggerDeath()
    {
        base.TriggerDeath();
        aiState = StandardAIState.Dead;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Building>() != null) AttackBuilding(other.gameObject);
        if (other.gameObject.GetComponent<UnitCombat>() != null) AttackUnit(other.gameObject);
    }
}
