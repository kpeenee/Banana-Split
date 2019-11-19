using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeledPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void SwitchPlayer()
    {
        Instantiate(player, transform.position, Quaternion.Euler(0, 90, 0));
        KillPlayer();
    }

    public void KillPlayer()
    {
        Destroy(gameObject);
    }
}
