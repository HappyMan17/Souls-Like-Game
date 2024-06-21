using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 10f;

    private void OnTriggerEnter(Collider other)
    {
        var healthController = other.GetComponent<HealthController>();
        
        if (healthController != null)
        {
            healthController.AddHealth(health);
            gameObject.SetActive(false);
        }
    }
}
