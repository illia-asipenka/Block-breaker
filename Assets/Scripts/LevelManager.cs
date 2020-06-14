using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    Scene myScene;
    public static int playerLives = 3;


    private void Start()
    {
        myScene = SceneManager.GetActiveScene();
    }


    public void LoadLevel(string name)
    {
        Debug.Log($"Level load requested for: {name}");
        SceneManager.LoadScene(name);
        //Application.LoadLevel(name);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturnOnStartScreen()
    {
        SceneManager.LoadScene(0);

    }    

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(myScene.buildIndex + 1);
    }
    
    public void BrickDestroyed()
    {
        if (brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
        
    }

}
