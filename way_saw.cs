using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class way_saw : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoint;
    private int currentIndex = 0;
    private int speed = 3;
    private int rotationSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360 * rotationSpeed * Time.deltaTime);
        if (Vector2.Distance(waypoint[currentIndex].transform.position, transform.position) < 0.1f)
        {
            currentIndex++;
            if (currentIndex >= waypoint.Length)
            {
                currentIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentIndex].transform.position, Time.deltaTime * speed);
    }

}
