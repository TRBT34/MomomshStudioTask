using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrisonControl : MonoBehaviour
{
    GameObject Player;
    public bool Prision = false;
    private void Awake()
    {
        Player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Prision = true;
            var Enemeycount = Player.GetComponent<EnemyCollector>().StacksEnemy.Count;  
            for (int i = 0; i < Enemeycount; i++)
            {
                Player.GetComponent<EnemyCollector>().StacksEnemy[i].GetComponent<NavMeshAgent>().enabled = true;
                Player.GetComponent<EnemyCollector>().StacksEnemy[i].GetComponent<NavMeshAgent>().destination = this.gameObject.transform.position;
            }
        }
    }
    private void Update()
    {
        if (Player.GetComponent<EnemyCollector>().StacksEnemy.Count == 0)
        {
            Prision = false;
        }
    }
}
