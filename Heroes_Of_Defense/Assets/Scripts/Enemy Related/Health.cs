using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    public int MaxHealth { get; }

    [SerializeField]
    private int currentHealth;
    public int CurrentHealth { get; }
    
    public event UnityAction<float> OnHealthChanged = delegate { } ;

    public float HealthPercentage {  get { return (float)currentHealth / maxHealth; } }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHP(int amt)
    {
        currentHealth += amt;

        if (currentHealth >= maxHealth) 
        {
            currentHealth = maxHealth;
        }

        float currentHPPct = (float)currentHealth / (float)maxHealth;
        OnHealthChanged(currentHPPct);

        if (currentHealth <= 0) 
        {
            if (GetComponent<Enemy>() != null) 
            {
                StartCoroutine(GetComponent<Enemy>().Die());
            }

            else 
            {
                StartCoroutine(GetComponent<Tower>().Die());
            }
        }
    }

    public bool WillDieFromDamage(int amt) 
    {
        return currentHealth - amt <= 0;
    }
}

