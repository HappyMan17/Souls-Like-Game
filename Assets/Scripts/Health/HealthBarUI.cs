using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _healthBarForegroundImage;
    public void UpateHealthBar(HealthController healthController)
    {
        if(healthController.RemainingHealthPercentage>0.1f)
        {
            _healthBarForegroundImage.fillAmount = healthController.RemainingHealthPercentage;       
        }
        else
        {
          _healthBarForegroundImage.fillAmount = 0  ;
        }
        Debug.Log(_healthBarForegroundImage.fillAmount);
    }
}
