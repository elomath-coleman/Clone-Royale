using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Waypoint nextWaypoint;

    public Waypoint GetNextWaypoint()
    {
    return nextWaypoint;
   }
}
