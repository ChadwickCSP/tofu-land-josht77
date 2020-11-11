using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public bool movingLeft;
    
    // The amount of force to apply to tofu on contact
    public float strength;

    // Update is called once per frame
    void Update()
    {
        float speed = 0;

        if (movingLeft)
        {
            speed = -1;
            GetComponent<SpriteRenderer>().flipX = false;
        }else
        {
            speed = 1;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject);
        EdgeChecker checker = collision.gameObject.GetComponent<EdgeChecker>();
        if (checker != null)
        {
            this.movingLeft = ! checker.isLeftBound;
        }

        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            UnityEngine.Object.Destroy(this.gameObject);
            playerController.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
        }

    }

}
