using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void B_OnHandleEndGame()
    {
        Application.Quit();
        // CanvasPlay.gameObject.SetActive(false);
        // PauseController.GetInstance().SetIsPaused(false);
        // FreeLookCamController.GetInstance().SetStartCam(true);
    }
}
