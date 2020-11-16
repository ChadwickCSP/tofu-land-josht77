using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Determines the speed that the Tofu moves
    public float speed;
    // Determines how high the Tofu jumps
    public float jumpPower;
    // heath of the tofu
    public float health;

    void Start()
{
    health = 5;
}
// Update is called once per frame
    void Update()
    {
        // the horizontal input will equal the horizontal axis and allows for the tofu to move on the horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * speed * Time.deltaTime * horizontalInput);

        // The space bar will now allow tofu to jump
        bool isJumping = Input.GetKeyDown(KeyCode.Space);
        // Tofu jump power 
        if (isJumping)
        {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        }

        // if the horizontal input is less than 0 then the axis flips
        if (horizontalInput < 0) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // if the horizontal input is not equal to 0 then the tofu will move 
        if (horizontalInput != 0)
        {
            GetComponent<Animator>().SetBool("isMoving", true);
        } else
        {
            GetComponent<Animator>().SetBool("isMoving", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // prints the collisions
        print(collision.gameObject);
        // if the enemy colldies with the tofu then the enemy will knock the tofu back depending on the enemy's strength
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy !=null)
        {

            float tofuX = this.transform.position.x;
            float enemyX = enemy.transform.position.x;
            bool isLeftOfEnemy = tofuX < enemyX;
            if(isLeftOfEnemy)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * enemy.strength);
            } else 
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * enemy.strength);
            }
        SpikeController spike = collision.gameObject.GetComponent<SpikeController>();
        if (spike != null)
        {
            health += -1;
        }
        
        }
    }
}
