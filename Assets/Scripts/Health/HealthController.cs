using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maximumHealth;

    [SerializeField]
    private Animator playerAnimator;

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public UnityEvent OnDied;
    public UnityEvent OnHealthChange;

    public void TakeDamage(float damageAmount)
    {
        if ( _currentHealth == 0 )
        {
            return;
        }

        if ((_currentHealth - damageAmount) <= 0)
        {
            OnDied.Invoke();
        }

        if (playerAnimator && !playerAnimator.GetBool("usingShield"))
        {
            _currentHealth -= damageAmount;

            // health Change event
            OnHealthChange.Invoke();        
        }

        if ( _currentHealth < 0 )
        {
            _currentHealth = 0;    
        }
        
    }

    public void AddHealth( float amountToAdd )
    {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;

        // health Change event
        OnHealthChange.Invoke();

        if ( _currentHealth > _maximumHealth ) 
        { 
            _currentHealth = _maximumHealth;
        }
    }
}
