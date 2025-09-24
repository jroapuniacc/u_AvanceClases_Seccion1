using System;
using UnityEngine;
using System.Collections;

public class HealthZoneController : MonoBehaviour
{
    [SerializeField] private int healthIncrease = 10;
    private IEnumerator micorrutina;

    private void Start()
    {
        micorrutina = IncreaseHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(micorrutina);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(micorrutina);
        }
    }

    IEnumerator IncreaseHealth()
    {
        while (GameManager.instance.health >= 0)
        {
            GameManager.instance.IncreaseHealth(healthIncrease);
            yield return new WaitForSeconds(1f);
        }
        
    }
}



