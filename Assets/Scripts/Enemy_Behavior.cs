using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    
    public NavMeshAgent agent;
    public Transform player;

    public Transform[] gommes;
    private Transform ActiveGomme;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 WalkPoint;
    public bool WalkPointSet;

    public int chasetimerMax = 60;
    private int chasetimerCur;
    private bool isChasingPlayer = false;
    private bool canChasePlayer = true;

    public float WalkPointRange;
    public float SightRange;
    public bool PlayerinSightRange;
    
    void Start()
    {
        ActiveGomme = gommes[0];
        //initialise la gomme la plus proche
        SelectNewGomme();
        chasetimerCur = chasetimerMax;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //si en poursuite
        if(isChasingPlayer)
            ChasePlayer();

        //sinon, vérifier si le joueur est plus près que la gomme la plus proche
        if (Vector3.Distance(ActiveGomme.position, transform.position) >
            Vector3.Distance(player.position, transform.position))
        {
            //timer pour que cette vérification ne soit fait qu'une fois par seconde
            chasetimerCur = chasetimerMax;
            isChasingPlayer = true;
            ChasePlayer();
        }
        
        else ChaseGum();
    }

    void ChaseGum()
    {
        agent.SetDestination(ActiveGomme.position);
    }
    
    private void ChasePlayer()
    {
        //poursuit le joueur. Si le timer se termine, on arrête de le suivre par défaut et on peut vérifier dans update
        //qui est le plus proche
        agent.SetDestination(player.position);
        chasetimerCur--;
        if (chasetimerCur <= 0)
        {
            isChasingPlayer = false;
            SelectNewGomme();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //quand tu collisionne avec une gomme, en choisit une nouvelle
        SelectNewGomme();
    }

    private void SelectNewGomme()
    {
        foreach (Transform gomme in gommes)
        {
            float distance = Vector3.Distance(gomme.position, transform.position);
            if (distance < Vector3.Distance(ActiveGomme.position, transform.position))
            {
                ActiveGomme = gomme;
            }
        }
    }
}
