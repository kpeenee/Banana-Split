using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] int secsToWait;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PickUp(collision.gameObject.GetComponent<Player>());
        }
        else if(collision.gameObject.tag == "Deadly")
        {
            if (FindObjectOfType<Player>())
            {
                StartCoroutine(Die());
            }
        }
    }

    private void PickUp(Player player)
    {
        player.SetCanShoot(true);
        player.transform.localScale = new Vector3(1, 1, 1);
        Destroy(gameObject);
    }

    private IEnumerator Die()
    {
        FindObjectOfType<Player>().KillPlayer();
        yield return new WaitForSeconds(secsToWait);
        FindObjectOfType<SceneLoader>().RestartLevel();
    }

}
