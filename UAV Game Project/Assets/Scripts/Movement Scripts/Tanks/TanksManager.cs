using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TanksManager : MonoBehaviour
{

    public GameObject targetDestination;
    public float forwardSpeed = 5f;
    
    private NavMeshAgent tankNavMeshAgent;
    private Animator animator;
    
    private float rotationSpeed = 5f;
    
    void Awake()
    {
        tankNavMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        MoveTowardsTargetDestination();
        RotateTowardCurrentTarget();
        tankNavMeshAgent.velocity = Vector3.zero;
    }

    private void MoveTowardsTargetDestination()
    {
        transform.position += transform.forward * forwardSpeed * Time.deltaTime;
    }
    
    private void RotateTowardCurrentTarget()
    {
        tankNavMeshAgent.enabled = true;
        
        tankNavMeshAgent.SetDestination(targetDestination.transform.position);
        
        transform.rotation = Quaternion.Slerp(transform.rotation,
            tankNavMeshAgent.transform.rotation,
            rotationSpeed/Time.deltaTime);
    }
}
