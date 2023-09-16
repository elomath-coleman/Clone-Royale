using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat : MonoBehaviour
{
    int factionID = 0;
    float currentHP = 1;
    [SerializeField] float maxHP = 15;
    // Start is called before the first frame update
    void Start()
    {
        // Start the unit at full hp
        currentHP = maxHP;
    }

    public virtual void TakeDamage(float amount)
    {
        if (currentHP <= 0) return;

        currentHP -= amount;

        if (currentHP <= 0) GetComponent<UnitAI>().TriggerDeath();
    }

    public int GetFactionID()
    {
        return factionID;
    }

    public virtual void InitializeCombat(int faction)
    {
        factionID = faction;
    }
}