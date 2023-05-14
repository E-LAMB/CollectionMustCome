using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBlinker : MonoBehaviour
{

    public bool in_sight;

    public Transform player;
    public Transform self;
    public Transform my_eyes;

    public Vector3 stored_position;

    public NavMeshAgent my_agent;

    public float time_to_warp;
    public float max_time_to_warp;
    public float max_distance;

    /*
    void OnBecameVisible()
    {
        in_sight = true;
    }

    void OnBecameInvisible()
    {
        in_sight = false;
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        my_eyes.LookAt(player.position);
        time_to_warp -= Time.deltaTime;

        if (0f > time_to_warp)
        {
            time_to_warp = max_time_to_warp;
            stored_position = player.position;
            stored_position.y = self.position.y;
            my_agent.Warp(Vector3.MoveTowards(self.position, stored_position, max_distance));
        }
    }
}
