using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pet : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _owner;

   
   

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_owner.position);
    }
}
