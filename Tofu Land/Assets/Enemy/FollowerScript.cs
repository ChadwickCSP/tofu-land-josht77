using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour
{

    public bool movingLeft;
    
    // The amount of force to apply to tofu on contact
    public float strength;

    public PlayerController tofu;

    // Update is called once per frame
    void Update()
    {
        // if the enemy is left of tofu, then the speed will be -1 meaning they walk to the left. if false, then it will walk to the right
        float speed = 0;
        float tofuX = tofu.transform.position.x;
        float enemyX = this.transform.position.x;
        bool isLeftofTofu = tofuX > enemyX;
        if (!isLeftofTofu)

        {
            speed = -1;
            GetComponent<SpriteRenderer>().flipX = false;
        }else
        {
            speed = 1;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        // if the enemy is not left not the tofu then the speed is -1 os moving to the left and toward the tofu. 
        // if the enemy is to the right of the tofu, then the speed is 1 making it move right towards the tofu.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print each collision with an edgechecker
        print(collision.gameObject);
        EdgeChecker checker = collision.gameObject.GetComponent<EdgeChecker>();
        // if the object that collides with is not equal to null (which is something that is not a component on this object) it will make it do the opposite
        if (checker != null)
        {
            // if there is a checker on the object, then it will make the enemy go the opposite way
            this.movingLeft = ! checker.isLeftBound;
        }

        // if playercontroller is attacked to the object then it will destory this game object
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            UnityEngine.Object.Destroy(this.gameObject);
            playerController.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 600);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    // print the collision of the object. Every time the enemy hits the ground, it will add a force up becuse the ground has a certain amount of strength to make the enemy resemble a hopping motion
        print(collision.gameObject);
        Ground ground = collision.gameObject.GetComponent<Ground>();
        if (ground != null)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * ground.strength);
        }

     }
}