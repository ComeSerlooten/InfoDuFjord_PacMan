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

    public List<CollectibleGum> gommes = new List<CollectibleGum>();
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

    [SerializeField] bool isSearching = true;
    bool activeSearch = false;
    
    void Start()
    {
        //Récupérer les gommes dans la scene automatiquement
        GetGums();

        ActiveGomme = gommes[0].transform;
        //initialise la gomme la plus proche
        GetClosestGomme();
        chasetimerCur = chasetimerMax;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSearching && !activeSearch) StartCoroutine(SearchDelay());
        else if (!isSearching && activeSearch)
        {
            StopCoroutine(SearchDelay());
            activeSearch = false;
        }

        //si en poursuite
        
    }

    IEnumerator SearchDelay()
    {
        activeSearch = true;
        while(isSearching)
        {
            yield return new WaitForSeconds(.5f);
            Search();
        }
    }

    void Search()
    {
        GetClosestGomme();
        if (gommes.Count > 0)
        {
            if (Vector3.Distance(ActiveGomme.position, transform.position) >
            Vector3.Distance(player.position, transform.position))
            {
                isChasingPlayer = true;
                ChasePlayer();
            }
            else
            {
                ChaseGum();
            }
        }
        else
        {
            ChasePlayer();
        }

    }

    void GetGums()
    {
        foreach ( CollectibleGum cg in FindObjectsOfType(typeof(CollectibleGum)))
        {
            gommes.Add(cg);
        }
    }

    void ChaseGum()
    {
        agent.SetDestination(ActiveGomme.position);


        if(agent.remainingDistance < 2 && agent.remainingDistance > 0)
        {
           ActiveGomme.GetComponent<CollectibleGum>().Collected();
            gommes.Remove(ActiveGomme.GetComponent<CollectibleGum>());
           GetClosestGomme();
        }
        
    }
    
    private void ChasePlayer()
    {
        //poursuit le joueur. Si le timer se termine, on arrête de le suivre par défaut et on peut vérifier dans update
        //qui est le plus proche
        agent.SetDestination(player.position);
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Check for player collision
        if (collision.transform == player)
        {
            //Collided with player

        }
    }

    private void GetClosestGomme()
    {
        foreach (CollectibleGum gomme in gommes)
        {
            float distance = Vector3.Distance(gomme.transform.position, transform.position);
            if (distance < Vector3.Distance(ActiveGomme.position, transform.position))
            {
                ActiveGomme = gomme.transform;
            }
        }
    }
}
