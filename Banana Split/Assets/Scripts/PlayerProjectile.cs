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
            if (FindObjectOfType<PeeledPlayer>())
            {
                Die();
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            PickUp(collision.gameObject.GetComponent<PeeledPlayer>());
        }
    }

    private void PickUp(PeeledPlayer player)
    {
        player.Catch();
        Destroy(gameObject);
    }

    private void Die()
    {
        FindObjectOfType<PeeledPlayer>().KillPlayer();
        FindObjectOfType<SceneLoader>().RestartLevel();
    }

}
