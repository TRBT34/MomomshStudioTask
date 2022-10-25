using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    public bool AIState = false;
    NavMeshAgent EnemyAgent;
    public GameObject enemyCollector;
    public GameObject forEnemyDestination;
    float distance;
    Animator EnemyAnimator;
    private void Awake()
    {
        enemyCollector = GameObject.Find("Player");
        EnemyAgent = gameObject.GetComponent<NavMeshAgent>();
        EnemyAnimator = gameObject.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if(!GameObject.Find("prison").GetComponent<PrisonControl>().Prision)
        {
            AIfollow();
        }
    }
    void AIfollow()
    {
        if (AIState)
        {
            forEnemyDestination = enemyCollector.GetComponent<EnemyCollector>().tmpObjecttofollow.gameObject;
            AIState = false;
        }
        if (forEnemyDestination != null)
        {
            distance = Vector3.Distance(transform.position, forEnemyDestination.transform.position);
        }
        if (distance >= 5)
        {
            EnemyAgent.enabled = true;
            EnemyAnimator.SetBool("Run", true);
        }
        else
        {
            EnemyAgent.enabled = false;
            EnemyAnimator.SetBool("Run", false);
        }
        if (EnemyAgent.enabled)
        {
            EnemyAgent.destination = forEnemyDestination.transform.position;
        }
    }
}
