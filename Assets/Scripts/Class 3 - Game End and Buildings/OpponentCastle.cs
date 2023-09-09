using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCastle : Building
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9)) Die();
    }
    public override void Die()
    {
        GameStateManager.instance.PlayerWon();
        base.Die();
    }
}
