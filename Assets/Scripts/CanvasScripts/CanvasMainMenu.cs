using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainMenu : MonoBehaviour
{
    private  static CanvasMainMenu instance;
    public Canvas CanvasPlay;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void B_OnHandlePlayButton()
    {
        CanvasPlay.gameObject.SetActive(false);
        PauseController.GetInstance().SetIsPaused(false);
        //FreeLookCamController.GetInstance().SetStartCam(true);
    }
    public static CanvasMainMenu GetInstance()
    {
        return instance == null ? instance = new CanvasMainMenu() : instance;
    }
}
