﻿using System.Collections;
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
        // if moving left is true then the speed is moving toward the left and the enemy will flip on the x axis depending which way it is moving
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
        // print the message when a collision happnes
        print(collision.gameObject);
        // checks to see if an object colliding has an edge checker
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
    // print the collision of the object. Every time the enemy hits the ground, it will add a force up becuse the ground has a certain amount of strength to make the enemy resemble a hopping motion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject);
        Ground ground = collision.gameObject.GetComponent<Ground>();
        if (ground != null)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * ground.strength);
        }

     }
}