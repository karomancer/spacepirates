using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyHealth = 100;
    public int enemyMaxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    // subtract damage done from health, and destroy object if it has 0 health
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        print(enemyHealth);
    }
}
