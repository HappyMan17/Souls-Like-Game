using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountKillFirstDoor : MonoBehaviour
{
    [SerializeField]
    private Animator grillDoorAni;
    private int skeletonKills = 0;

    // Update is called once per frame
    void Update()
    {
        if(skeletonKills == 2)
        {
            grillDoorAni.SetBool("unlock",true);
        }
    }

    public void AddKill()
    {
        skeletonKills ++;
    }
}
