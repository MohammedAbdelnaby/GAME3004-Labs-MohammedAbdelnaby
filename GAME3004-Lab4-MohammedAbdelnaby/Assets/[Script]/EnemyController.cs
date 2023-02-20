using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform PlayerTransform;

    public NavMeshAgent agent;
    // Update is called once per frame
    void Update()
    {
        if (PlayerTransform != null)
        {
            agent.SetDestination(PlayerTransform.position);
        }
    }
}
