using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            Debug.Log("" + _damageAmount);
            healthController.TakeDamage(_damageAmount);
        }
    }

}
