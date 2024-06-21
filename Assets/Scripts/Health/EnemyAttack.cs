using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;
    [SerializeField]
    private bool isTrigger = false;
    [SerializeField]
    private string currentModel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthController>() && currentModel != collision.gameObject.name)
        {
            var healthController2 = collision.gameObject.GetComponent<HealthController>();
            // Debug.Log("" + _damageAmount);
            healthController2.TakeDamage(_damageAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTrigger)
        {
            return;
        }
        
        var healthController = other.GetComponent<HealthController>();
        
        if (healthController != null && currentModel != other.name)
        {
            healthController.TakeDamage(_damageAmount);
        }
    }
}
