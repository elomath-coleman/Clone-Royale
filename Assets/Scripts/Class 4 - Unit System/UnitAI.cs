using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAI : MonoBehaviour
{
    [SerializeField] int factionID;
    NavMeshAgent agent;
    [SerializeField] Waypoint waypoint;
    bool alive = true;
    [SerializeField] UnitAnimator unitAnimator;
    [SerializeField] BoxCollider objectCollider;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        //EffectsManager.instance.PlaySmallBoom(transform.position, 1);
    }
    void Update()
    {
        if(alive) RunAI();
    }
    public virtual void RunAI()
    {
        // If we have reached the target destination, move to the next Waypoint
        //   - We choose a "within .15f units" option because direct mathematical
        //   - equivalents cause trouble in WebGL builds
        if (Vector3.Distance(transform.position, agent.destination) < .15f) waypoint = waypoint.GetNextWaypoint();
        // Set the NavMeshAgent to move the agent towards the waypoint
        agent.destination = waypoint.transform.position;
    }
    public virtual void InitializeAI(Waypoint startingWaypoint, int faction)
    {
        waypoint = startingWaypoint;
        factionID = faction;
        GetComponent<UnitCombat>().InitializeCombat(faction);
    }
    public int GetFactionID()
    {
        return factionID;
    }
    public virtual void TriggerDeath()
    {
        alive = false;
        unitAnimator.AnimateDeath();
        agent.destination = transform.position;
        agent.enabled = false;
        if (objectCollider) objectCollider.enabled = false;
        Destroy(gameObject, 4);
    }
}
