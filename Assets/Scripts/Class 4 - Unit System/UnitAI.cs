using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAI : MonoBehaviour
{
    [SerializeField] int factionID = 0;
    NavMeshAgent agent;
    [SerializeField] Waypoint waypoint;
    [SerializeField] UnitAnimator unitAnimator;
    bool alive = true;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive) RunAI();
    }


    public virtual void RunAI()
    {
        if (Vector3.Distance(agent.destination, transform.position) < .15f) 
            waypoint = waypoint.GetNextWaypoint();
        agent.destination = waypoint.transform.position;
    }

    public virtual void InitializeAI(Waypoint startingWaypoint, int faction)
    {
        waypoint = startingWaypoint;
        agent.destination = waypoint.transform.position;
        factionID = faction;
    }

    public void TriggerDeath()
    {
        alive = false;
        // Trigger the death animation
        unitAnimator.AnimateDeath();
    }
}
