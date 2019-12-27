using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints = new List<Transform>();
    [SerializeField] float speed;
    [SerializeField] int waitTime = 0;
    bool platformMoving = true;
    int currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (platformMoving) { PlatformMove(); }
        
    }

    private void PlatformMove()
    {
        //Platform follows waypoints
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentPoint].position, Time.deltaTime * speed);
        if (transform.position == waypoints[currentPoint].position)
        {
            StartCoroutine(Wait());
            currentPoint++;
            if (currentPoint >= waypoints.Count)
            {
                currentPoint = 0;
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Set moving platform as parent so player moves with it
        Debug.Log("collision");
        if (collision.gameObject.tag == "Player")
        {
            
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Stops players parent being moving platform so stops moving with it
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    IEnumerator Wait()
    {
        platformMoving = false;
        yield return new WaitForSeconds(waitTime);
        platformMoving = true;
    }
}
