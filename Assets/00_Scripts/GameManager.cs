using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static: no muere, vive en todas las escenas. Vive durante el juego
    public static GameManager instance;
    
    [Header("Health")]
    public int health = 100;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // crea la instancia
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Me encontré con otro Dios. Aquí vive uno");
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
    }

    

    
}
