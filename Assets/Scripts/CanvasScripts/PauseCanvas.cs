using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    public void ShowCanvas()
    {
        gameObject.SetActive(true);
    }
    
    public void HiddeCanvas()
    {
        gameObject.SetActive(false);
    }


}
