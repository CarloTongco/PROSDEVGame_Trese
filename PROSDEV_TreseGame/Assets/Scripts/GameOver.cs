using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    public void Update()
    {
        if (gameOverPanel.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }
    public void EndGame()
    {
        gameOverPanel.SetActive(true); 
    }
}
