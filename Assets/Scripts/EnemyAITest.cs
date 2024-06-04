using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAITest : MonoBehaviour
{
    public int routine;
    public float chronometer;
    public Animator enemyAni;
    public Quaternion angle;
    public float degree;

    public bool attacking;
    public GameObject target;
    [SerializeField]
    private float speed;
    public NavMeshAgent agent;
    public float rangeAttack;
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
        //Debug.Log(Vector3.Distance(transform.position, target.transform.position));
    }

    void Behavior_enemy()
    {
        if(Vector3.Distance(transform.position,target.transform.position) >5)
        {   
            
            enemyAni.SetBool("run",false);
            chronometer += 1 * Time.deltaTime;
            if(chronometer >= 4)
            {
                routine = Random.Range(0,2);
                chronometer = 0;
            }
            switch (routine)
            {
                case 0:
                    enemyAni.SetBool("walk",false);
                    break;
                case 1:
                    degree = Random.Range(0,360);
                    angle = Quaternion.Euler(0,degree,0);
                    routine ++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    enemyAni.SetBool("walk",true);
                    break;
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, target.transform.position) >1.6f && !attacking)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation,3);
                
                enemyAni.SetBool("walk",false);
                enemyAni.SetBool("run",true);
                
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                
                enemyAni.SetBool("attack",false);
            } 
            else
            {
                if(Vector3.Distance(transform.position, target.transform.position) <=1.6f )
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
    void EndAttack()
    {
        enemyAni.SetBool("attack", false);
        attacking = false;
    }
}
