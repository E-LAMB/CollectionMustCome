using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMonitor : MonoBehaviour
{

    public Transform player_pos;

    public NavMeshAgent my_agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        my_agent.SetDestination(player_pos.position);
    }
}
