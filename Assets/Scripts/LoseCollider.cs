using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCollider : MonoBehaviour
{

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        Debug.Log("Trigger");
        if (LevelManager.playerLives <= 0)
        {
            levelManager.LoadLevel("Lose");
            LevelManager.playerLives = 3;
        }
        else
        {
            LevelManager.playerLives--;           
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }
}


