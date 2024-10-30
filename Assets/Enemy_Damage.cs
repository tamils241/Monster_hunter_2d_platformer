using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    public HealthScript HealthScript;
    int Damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
                   
                    HealthScript.TakeDamage_Player(Damage);
           
    }
}
}

