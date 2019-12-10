using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    LineRenderer lr;

    [Header("Player switch")]
    [SerializeField] GameObject peeledPlayer;
    

    [Header("Player Projectile")]
    [SerializeField] float power = 2f;
    [SerializeField] PlayerProjectile projectile;
    [SerializeField] Transform shootPoint;
    [SerializeField] Vector3 projectileRotation = new Vector3(270,180,0);
    private Vector3 startPos;
    private Vector3 endPos;
   

    void Start()
    {
        //Get line renderer on player
        lr = GetComponent<LineRenderer>();
        
    }

    private void Update()
    {
        ShootBanana();
    }

    private void ShootBanana()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Get position clicked
            Plane plane = new Plane(Vector3.forward, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                startPos = ray.GetPoint(distanceToPlane);
                lr.enabled = true;
                lr.SetPosition(0, startPos);
            }
        }

        Aim();

        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
            Fire(startPos, endPos);
        }
    }

    private void Aim()
    {
        if (Input.GetMouseButton(0))
        {
            endPos = shootPoint.position;
            lr.SetPosition(1, endPos);

            Plane plane = new Plane(Vector3.forward, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                startPos = ray.GetPoint(distanceToPlane);
                lr.SetPosition(0, startPos);
            }
        }
    }

    private void Fire(Vector3 start, Vector3 end)
    {
        Vector3 direction = start - end;
        PlayerProjectile playerProjectile = Instantiate(projectile, shootPoint.position, Quaternion.Euler(projectileRotation)) as PlayerProjectile;
        playerProjectile.GetComponent<Rigidbody>().velocity = direction * power;
        SwitchPlayer();

    }

    private void SwitchPlayer()
    {
        Instantiate(peeledPlayer, transform.position, Quaternion.Euler(0,90,0));
        KillPlayer();
    }

    public void KillPlayer()
    {
        Destroy(gameObject);
    }

  

}
