using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEndGame : MonoBehaviour
{
    [SerializeField]
    private PauseController playerPauseController;
    
    [SerializeField]
    private Canvas endGameCanvas;

    [SerializeField]
    private Canvas pauseCanvas;
    /*
    public void PlayerDeath()
    {
        playerPauseController.SetIsPaused(true);

        endGameCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
    }*/

    public void OnTriggerEnter()
    {
        playerPauseController.SetIsPaused(true);

        endGameCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
    }
}
