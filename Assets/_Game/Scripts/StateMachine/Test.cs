using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform  test;

    private void Update() 
    {
        agent.SetDestination(test.position);
    }
}
