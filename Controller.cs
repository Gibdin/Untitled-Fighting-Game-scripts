using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 15f; //Defining variables for movement
    public Rigidbody2D rb;
    public float jumpForce = 30f;

    public Transform lAttackPos; //Defining variables of three attacks. Creating a layermask so the attacks only interact with the enemies. I give each attack a range, hitbox position and damage value property.
    public float lAttackRange = 0.7f;
    public LayerMask enemyLayer;
    public int lAttackDmg = 10;

    public Transform mAttackPos;
    public float mAttackRange = 1f;
    public int mAttackDmg = 20;

    public Transform hAttackPos;
    public float hAttackRange = 1.5f;
    public int hAttackDmg = 50;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal"); //horizontal movement input
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed; // creates movement based off player input
        
        if (Input.GetKeyDown(KeyCode.W) && Mathf.Abs(rb.velocity.y) < 0.01) //Allows the player to jump only when the velocity on the y axis is less than 0.01, This will prevent jumping multiples times
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.U)) //Input for attacks
        {
            LightAttack();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            MediumAttack();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            HeavyAttack();

        }
    }

    public void LightAttack() //all attacks follow the same layout/blueprint. When the function begins a cricle collider is created at the position and given the same range previously defined. It only interacts in the enemy layer
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(lAttackPos.position, lAttackRange, enemyLayer);
        Debug.Log("Light Attack!");
        foreach (Collider2D enemy in hitEnemies) //once an enemy is detected and collision occurs the enemy takes damage from the enemy script from the same amount of damage the attack property is
        {
            Debug.Log("We hit " + enemy.name + "with a Light attack!");
            enemy.GetComponent<Enemy>().TakeDamage(lAttackDmg);
        }
    }

    void MediumAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(mAttackPos.position, mAttackRange, enemyLayer);
        Debug.Log("Medium Attack!");
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name + "with a Medium attack!");
            enemy.GetComponent<Enemy>().TakeDamage(mAttackDmg);
        }
    }

    void HeavyAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hAttackPos.position, hAttackRange, enemyLayer);
        Debug.Log("Heavy Attack!");
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name + "with a Heavy attack!");
            enemy.GetComponent<Enemy>().TakeDamage(hAttackDmg);
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); //This is the jump function that adds a positive impulse force on the y axis. 
    }
    private void OnDrawGizmosSelected() //This draws the gizmos and hitboxes in the editor
    {
        Gizmos.DrawWireSphere(lAttackPos.position, lAttackRange);
        Gizmos.DrawWireSphere(mAttackPos.position, mAttackRange);
        Gizmos.DrawWireSphere(hAttackPos.position, hAttackRange);

    }
}
