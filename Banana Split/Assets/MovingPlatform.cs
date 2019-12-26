using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints = new List<Transform>();
    [SerializeField] float speed;
    int currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentPoint].position, Time.deltaTime * speed);
        if(transform.position == waypoints[currentPoint].position)
        {
            currentPoint++;
            if (currentPoint >= waypoints.Count)
            {
                currentPoint = 0;
            }
            
        }
    }
}
