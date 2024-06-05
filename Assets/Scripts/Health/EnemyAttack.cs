using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;

    [SerializeField]
    private HealthController healthController;

    [SerializeField]
    private string targetName;

    [SerializeField]
    private Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (targetName == collision.collider.name)
        {
            //var healthController = collision.gameObject.GetComponent<HealthController>();
            // Debug.Log("" + _damageAmount);
            healthController.TakeDamage(_damageAmount);
        }
    }

}
