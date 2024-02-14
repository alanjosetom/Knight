using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballTrapspawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D ballTrap;
    public int[] spawnArray = new int[] { 110, 120, 130, 147, 170 };
    void Start()
    {
        InvokeRepeating("ballFunction", 2.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ballFunction()
    {
        int randomIndex = Random.Range(0, spawnArray.Length);
        Vector3 spawnPos = new Vector3(spawnArray[randomIndex], 8, 0);
        Rigidbody2D bd = Instantiate(ballTrap, spawnPos, transform.rotation);
        bd.AddForce(transform.forward * 10);
    }
}
