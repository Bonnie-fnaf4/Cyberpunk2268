using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class AIManager : MonoBehaviour
{
    public int hp = 100;
    Rigidbody rigidbody;
    NavMeshAgent navMeshAgent;
    Animator animator;

    float timerToShoot = 0;
    public ShootAI shootAI;

    public AIManager[] aimanagersFriends;

    bool isDead = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timerToShoot += Time.deltaTime;
        if(timerToShoot >= 2 && animator.GetBool("isChasing") && !isDead)
        {
            shootAI.Shoot();
            timerToShoot = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.tag == "Bullet")
        {
            hp -= Random.Range(10, 25);
            animator.SetBool("isChasing", true);
            animator.SetBool("isPatrolling", false);
            for(int i = 0; i < aimanagersFriends.Length; i++)
            {
                if(aimanagersFriends[i] != null)
                aimanagersFriends[i].isChasingTrue();
            }
        }
        if (hp <= 0)
        {
            animator.enabled = false;
            navMeshAgent.enabled = false;
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
            animator.SetBool("isChasing", false);
            animator.SetBool("isAttacking", false);
            isDead = true;
            Destroy(gameObject, 30);
        }
    }

    public void isChasingTrue()
    {
        animator.SetBool("isChasing", true);
        animator.SetBool("isPatrolling", false);
    }
}
