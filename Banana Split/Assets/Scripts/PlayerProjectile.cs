using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] int secsToWait;
    
    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.tag == "Deadly")
        {
            if (FindObjectOfType<Player>())
            {
                Die();
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            PickUp(collision.gameObject.GetComponent<Player>());
        }
    }

    private void PickUp(Player player)
    {
        player.SetCanShoot(true);
        player.SetIsComplete(true);
        player.transform.localScale = new Vector3(1, 1, 1);
        Destroy(gameObject);
    }

    private void Die()
    {
        FindObjectOfType<Player>().KillPlayer();
        FindObjectOfType<SceneLoader>().RestartLevel();
    }

}
