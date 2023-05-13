using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seguir : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update



    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        navMeshAgent.SetDestination(objetivo.position);
        transform.LookAt(objetivo);
    }

}
