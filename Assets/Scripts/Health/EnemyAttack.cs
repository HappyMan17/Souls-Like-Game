using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;
    [SerializeField]
    private bool isTrigger = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthController>())
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
        
        if (healthController != null)
        {
            healthController.TakeDamage(_damageAmount);
        }
    }
}
