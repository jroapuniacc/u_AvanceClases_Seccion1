using System;
using System.Collections;
using UnityEngine;

public class Interactions : MonoBehaviour
{       
        [Header("Llaves")]
        [Tooltip("Artistas, estas son las llaves del jugador")]
        [SerializeField] private bool key1 = false;
        [Tooltip("Artistas, estas son la llave 2 del NPC")]
        [SerializeField] private bool key2 = false;
        
        [Space(10)]
        [Header("Door")]
        [SerializeField] private GameObject door; // Es el GO del pivotDoor
        private Animator animatorDoor; // Componente del Pivot Door
        private bool isOpenDoor = false;
        
        
        [Header("Health")]
        [SerializeField] private float health = 100f;
        [SerializeField] private int healthDecrease = 5;
        [SerializeField] private int healthIncrease = 10;
        
        [Header("UI")]
        [SerializeField] private GameObject uiDangerZone;

        private IEnumerator miCorrutina;

        private void Start()
        {
                animatorDoor = door.GetComponent<Animator>();
                miCorrutina = DangerZoneDamage();
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
                                if (key1 || key2)
                                {
                                        Debug.Log("Abrí la puerta");
                                        animatorDoor.SetBool("Anim_door", true);
                                        isOpenDoor = true;
                                }
                                break;
                        case "ZoneDanger":
                                StartCoroutine(miCorrutina);
                                break;
                       
                }
        }

        /*private void OnTriggerStay(Collider other)
        {
                switch (other.tag)
                {
                        case "ZoneDanger":
                                // Salud menos el daño
                                // heatlh - healthdecrease
                                if (isOpenDoor)
                                {
                                        health -= healthDecrease * Time.deltaTime;
                                        Debug.Log("Mi vida está en " + health); // Concatenar   
                                }
                                break; 
                        case "ZoneHealth":
                                if (isOpenDoor)
                                {
                                        health += healthIncrease * Time.deltaTime;
                                        Debug.Log("Mida vida está en " + health);    
                                }
                                break;  
                }
        }*/

        private void OnTriggerExit(Collider other)
        {
                switch (other.tag)
                {
                        case "Door":
                                Debug.Log("Salí del collider Door");
                                animatorDoor.SetBool("Anim_door", false);
                                break;
                        case "ZoneDanger":
                                StopCoroutine(miCorrutina);
                                break;
                }
        }

        IEnumerator DangerZoneDamage()
        {
                while (health >= 0)
                {
                        health -= healthDecrease;
                        uiDangerZone.SetActive(true);
                        yield return new WaitForSeconds(1f);
                        uiDangerZone.SetActive(false);
                        yield return new WaitForSeconds(1f);
                } 
               
        }
        
}
    
    



