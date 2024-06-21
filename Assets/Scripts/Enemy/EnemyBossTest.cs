using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossTest : MonoBehaviour
{
    
    public int routine;
    public float chronometer;
    public Animator enemyAni;
    public Quaternion angle;
    public float degree;

    public bool attacking;
    public bool isPatrolling = true;
    [SerializeField]
    private UnityEngine.UI.Image _MyHealth;

    public GameObject target;
    [SerializeField]
    private float speed;
    public float rangeToDetectPlayer = 4;
    public float rangeToAttack = 1.6f;
    public float degreeVision;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("PaladinPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Behavior_enemy();
        //Debug.Log(_MyHealth.fillAmount);
    }

    void Behavior_enemy()
    {
        if(_MyHealth.fillAmount >= 0.1f)
        {
            
            if(Vector3.Distance(transform.position,target.transform.position) > rangeToDetectPlayer)
            {   
                enemyAni.SetBool("run",false);
                enemyAni.SetBool("attack",false);
                enemyAni.SetBool("walk",false);
  
            }
            else
            {
                    // if the player is in range to attack
                    if(Vector3.Distance(transform.position, target.transform.position) > rangeToAttack && !attacking)
                    {
                        var lookPos = target.transform.position - transform.position;
                        lookPos.y = 0;
                        var rotation = Quaternion.LookRotation(lookPos);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation,3);
                        
                        enemyAni.SetBool("run",true);
                        
                        transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        
                        enemyAni.SetBool("attack",false);
                    } 
                    else
                    {
                        // if the player is in range to attack
                        if(Vector3.Distance(transform.position, target.transform.position) <= rangeToAttack )
                        {
                            enemyAni.SetBool("walk",false);
                            enemyAni.SetBool("run", false);

                            enemyAni.SetBool("attack", true);
                            attacking = true;
                        }
                        else
                        {
                            EndAttack(); 
                        }
                    }    
            }
        }
        else
        {
            enemyAni.SetBool("walk",false);
            enemyAni.SetBool("run",false);
            enemyAni.SetBool("attack",false);
            enemyAni.SetBool("dead",true);
        }   
    }
    void EndAttack()
    {
        enemyAni.SetBool("attack", false);
        attacking = false;
    }
}

