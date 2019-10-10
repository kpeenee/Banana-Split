﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PickUp(collision.gameObject.GetComponent<Player>());
        }
        
    }

    private void PickUp(Player player)
    {
        player.SetCanShoot(true);
        player.transform.localScale = new Vector3(1, 1, 1);
        Destroy(gameObject);
    }

}
