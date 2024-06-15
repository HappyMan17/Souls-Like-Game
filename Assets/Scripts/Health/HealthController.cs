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
        
        if (playerAnimator && !playerAnimator.GetBool("usingShield"))
        {
            // health Change event
            OnHealthChange.Invoke();
        
            _currentHealth -= damageAmount;
        }

        if ( _currentHealth < 0 )
        {
            _currentHealth = 0;    
        }

        if ( _currentHealth > 0 )
        {
            OnDied.Invoke();
        }
    }

    public void AddHealth( float amountToAdd )
    {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }

        // health Change event
        OnHealthChange.Invoke();

        _currentHealth += amountToAdd;

        if ( _currentHealth > _maximumHealth ) 
        { 
            _currentHealth = _maximumHealth;
        }
    }
}
