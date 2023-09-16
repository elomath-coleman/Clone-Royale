using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : CombatInterface
{
    Vector3 trajectory = Vector3.zero;
    [SerializeField] float bulletSpeed = 3;

    private void FixedUpdate()
    {
        transform.Translate(trajectory * Time.fixedDeltaTime * bulletSpeed);
    }

    public void InitializeBullet(int factionID, Vector3 newTrajectory, float newDamage)
    {
        trajectory = newTrajectory;
        InitializeCombatInterface(factionID, newDamage);
    }


}
