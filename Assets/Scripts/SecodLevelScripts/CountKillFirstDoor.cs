using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountKillFirstDoor : MonoBehaviour
{
    public Animator grillDoorAni;
    int skeletonKills;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(skeletonKills==2)
        {
            grillDoorAni.SetBool("unlock",true);
        }
    }

    public void AddKill()
    {
        skeletonKills ++;
    }
}
