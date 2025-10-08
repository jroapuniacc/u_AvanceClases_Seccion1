using System;
using UnityEngine;
using UnityEngine.SceneManagement;


// Cursor.lockState = CursorLockMode.Locked;

public class MenuManager : MonoBehaviour
{
    public void ButtonStartGame()
    {
        GameManager.instance.ResetHealth();
        SceneManager.LoadScene("Game_Level1");
    }
    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

   
}
