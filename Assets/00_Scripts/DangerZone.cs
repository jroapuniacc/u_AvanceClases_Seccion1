using UnityEngine;
using System.Collections;

public class DangerZone : MonoBehaviour
{
    [SerializeField] private int healthDecrease = 10;
    private IEnumerator micorrutinaDecrease;

    private void Start()
    {
        micorrutinaDecrease = DecreaseHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(micorrutinaDecrease);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(micorrutinaDecrease);
        }
    }
    

    IEnumerator DecreaseHealth()
    {
        while (GameManager.instance.health >= 0)
        {
            GameManager.instance.DecreaseHealth(healthDecrease);
            yield return new WaitForSeconds(1f);
        }
        
    }
        
    
}
