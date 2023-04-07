using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    
    public NavMeshAgent agent;
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 WalkPoint;
    public bool WalkPointSet;

    public float WalkPointRange;
    public float SightRange;
    public bool PlayerinSightRange;
    
    void Start()
    {

        
    
    }
    
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerinSightRange = Physics.CheckSphere(transform.position, SightRange, whatIsPlayer);

        if (PlayerinSightRange)
            ChasePlayer();
        
        else Patrol();
    }

    void Patrol()
    {
        if (!WalkPointSet)
            SetWalkPoint();
    }

    void SetWalkPoint()
    {
        
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
}
