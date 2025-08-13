using System;
using UnityEngine;

public class NPC1 : MonoBehaviour
{
    private bool key1 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            key1 = true;
        }
        else
        {
            Debug.Log("este no es el Player");
        }
        
    }
}
