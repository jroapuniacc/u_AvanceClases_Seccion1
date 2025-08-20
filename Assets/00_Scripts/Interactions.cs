using System;
using UnityEngine;

public class Interactions : MonoBehaviour
{       
        [Header("Llaves")]
        [Tooltip("Artistas, estas son las llaves del jugador")]
        [SerializeField] private bool key1 = false;
        [Tooltip("Artistas, estas son la llave 2 del NPC")]
        [SerializeField] private bool key2 = false;

        public GameObject door;
        private Animator animatorDoor;

        private void Start()
        {
                animatorDoor = door.GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
                switch (other.tag)
                {
                        case "NPC1": 
                                key1 = true;
                                Debug.Log("Obtuve la llave 1");
                                break;
                        case "NPC2":
                                key2 = true;
                                Debug.Log("Obtuve la llave 2");
                                break;
                        case "Door":
                                Debug.Log("Abrí la puerta");
                                animatorDoor.SetBool("Anim_door", true);
                                break;
                        default:
                                Debug.Log("Consigue las llaves");
                                break;
                }
        }
}
    
    



