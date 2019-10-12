using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<SceneLoader>().LoadNextLevel();
        }
    }
}
