using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Determines the speed that the Tofu moves
    public float speed;
    // Determines how high the Tofu jumps
    public float jumpPower;

// Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * speed * Time.deltaTime * horizontalInput);

        // The space bar will now allow tofu to jump
        bool isJumping = Input.GetKeyDown(KeyCode.Space);
        // Tofu jump power 
        if (isJumping)
        {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        }

        if (horizontalInput < 0) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

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
        print(collision.gameObject);
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy !=null)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * enemy.strength);
        }
    }
}
