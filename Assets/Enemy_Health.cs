using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy_Health : MonoBehaviour
{
    int currentHealth = 3;
    private Animator Ani;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        Ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;
    }
    public void TakeDamage_Enemy(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage enemy"+ damage);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Ani.SetTrigger("Death");
            Destroy(this.gameObject,2f);
            Debug.Log("death enemy");
        }
} 
}
