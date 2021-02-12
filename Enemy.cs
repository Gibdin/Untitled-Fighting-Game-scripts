using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100; //Defined hp and blocking as a boolean
    public int currentHealth;
    public bool blocking;

    public healthbar hpb;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //set current health value as max health value
        hpb.SetMaxHealth(maxHealth); //set the slider bar in the ui for the healthbar
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            blocking = true; //if the b button is pressed then the boolean blocking is considered true and is now a state.
        }

        else
        {
            blocking = false;
        }


    }

    public void TakeDamage(int damage)
    {
        if (blocking)
        {
            damage = 0;
            Debug.Log("Opponent is blocking! no damage taken!"); //When the enemy takes damage, it will be neglected if the opponent is blocking. I can change this in case of having chip damage
        }
        currentHealth -= damage; //If the opponent is not blocking, damage is taken to the current health and the slider is set at a new value

        hpb.SetHealth(currentHealth);

        if (currentHealth <= 0) //if the enemy healthbar is 0 or below they die. 
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!"); //Once the function is performed, the game object is destroyed.
        Destroy(gameObject);
    }
}
