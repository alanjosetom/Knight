using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField] private GameObject player;
    // private float distance;
    private Vector2 spawnDis;
    void Start()
    {

        spawnDis = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // distance = transform.position.x - player.transform.position.x;
        if (Vector2.Distance(spawnDis, transform.position) > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }
}

