using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;

    ListPoint listPoint;

    Transform player;
    float chaseRange = 5;
    int intWaiPoint;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        listPoint = animator.GetComponent<ListPoint>();

        //Transform wayPointsObject = GameObject.FindGameObjectWithTag("WayPoints").transform;
        //foreach (Transform t in wayPointsObject)
        //wayPoints.Add(t);

        foreach (Transform t in listPoint.Points)
        wayPoints.Add(t);
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(wayPoints[intWaiPoint].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if(intWaiPoint == wayPoints.Count - 1)
            {
                agent.SetDestination(wayPoints[intWaiPoint].position);
                intWaiPoint = 0;
            }
            else
            {
                agent.SetDestination(wayPoints[intWaiPoint].position);
                intWaiPoint += 1;
            }
        }
            //agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

        //timer += Time.deltaTime;
        //if (timer > 5)
           //animator.SetBool("isPatrolling", false);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
            animator.SetBool("isPatrolling", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
