using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTofu : MonoBehaviour
{
    // the tofu will transform over to the object spawnpoint when tofu collides with the spikes
    [SerializeField]Transform spawnPoint;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("Player"))
            col.transform.position = spawnPoint.position;
    }
}
