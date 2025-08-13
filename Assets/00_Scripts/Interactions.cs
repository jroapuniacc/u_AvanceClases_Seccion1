using System;
using UnityEngine;

public class Interactions : MonoBehaviour
{
        public bool key1 = false;
        
        private void OnTriggerEnter(Collider other)
        {
                if (other.CompareTag("NPC1"))
                { 
                        key1 = true;
                }

                if (other.CompareTag("Door"))
                {
                        Debug.Log("Puerta");
                }
        }
}
    
    



