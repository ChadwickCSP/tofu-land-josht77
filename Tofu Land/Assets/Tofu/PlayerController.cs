using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Determines the speed that the Tofu moves
    public float speed;

// Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * speed * Time.deltaTime * horizontalInput);

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
}
