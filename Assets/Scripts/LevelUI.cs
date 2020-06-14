using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{

    public TextMeshProUGUI playerLives;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLives.text = LevelManager.playerLives.ToString();
    }
}
