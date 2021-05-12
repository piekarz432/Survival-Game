using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float lookRdius = 10f;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform homePosition;

    private NavMeshAgent agent;

    private Enemy enemy;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRdius)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            enemy.walk();

            if(distance <= agent.stoppingDistance)
            {
                faceTarget();

                    enemy.attack();


                }

            //GameObject.Find("Manager").GetComponent<ChangeAudio>().setMusic("fight");
        }
        if (distance >= lookRdius)
        {
            agent.SetDestination(homePosition.position);
            
            if(Vector3.Distance(transform.position, homePosition.position) <= agent.stoppingDistance)
            {
                //transform.rotation = new Quaternion(0, 0, 0, 0);
                enemy.idle();
                //GameObject.Find("Manager").GetComponent<ChangeAudio>().setMusic("background");
            }

            

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRdius);
    }

    private void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
