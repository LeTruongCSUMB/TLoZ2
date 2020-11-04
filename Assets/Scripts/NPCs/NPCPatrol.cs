using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform patrolPoint1;
    public Transform patrolPoint2;
    public Vector3 checkPoint;
    public Vector3 startTransform;
    private GameObject npcObject;
    public  GameObject player;
    private NavMeshAgent navMeshAgent;
    public static bool isAtPoint;
    private bool chased;
    public static bool once;
    public bool attacking;
    public float patrolDistance;

    void Start()
    {
        npcObject = transform.gameObject;
        startTransform = transform.position;
        player = GameObject.Find("Player").gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
        isAtPoint = false;
        once = false;
        attacking = false;
        chased = true;
        HeadToPoint();
        patrolDistance = Vector3.Distance(patrolPoint2.position, patrolPoint1.position);

    }

    // Update is called once per frame
    void Update()
    {
        if(npcObject.GetComponent<EntityHealth>() != null)
        {
            if (!npcObject.GetComponent<EntityHealth>().respawnTime)
            {
                if (attacking)
                {
                    ChasePlayer();
                }
                else
                {
                    Patrol();
                }
            }
            else
            {
                startTransform = transform.position;
            }
        }
        else
        {
            Debug.Log("NPCPatrol: ERROR, NPC is missing EntityHealth Script!");
        }
    }

    void Patrol()
    {
        if (!chased)
        {
            if (NPCSight.headToPoint)
            {
                isAtPoint = false;
                chased = true;
            }
            else if (((Vector3.Distance(transform.position, patrolPoint1.position) < 0.25) && (Vector3.Distance(transform.position, patrolPoint2.position) > 1)) && !NPCSight.headToPoint)
            {
                if (!isAtPoint && !once)
                {
                    isAtPoint = true;
                    once = true;
                    NPCSight.caseNum = 1;
                }
                checkPoint = patrolPoint1.position;
            }
            else if (((Vector3.Distance(transform.position, patrolPoint2.position) < 0.25) && (Vector3.Distance(transform.position, patrolPoint1.position) > 1)) && !NPCSight.headToPoint)
            {
                if (!isAtPoint && !once)
                {
                    isAtPoint = true;
                    once = true;
                    NPCSight.caseNum = 1;
                }
                checkPoint = patrolPoint2.position;
            }
        }
        else
        {
            if (checkPoint == patrolPoint2.position)
            {
                navMeshAgent.SetDestination(patrolPoint1.position);
                if (Vector3.Distance(transform.position, patrolPoint2.position) >= patrolDistance)
                {
                    once = false;
                    chased = false;
                    NPCSight.headToPoint = false;
                    checkPoint = patrolPoint1.position;
                }
            }
            else if (checkPoint == patrolPoint1.position)
            {
                navMeshAgent.SetDestination(patrolPoint2.position);
                if (Vector3.Distance(transform.position, patrolPoint1.position) >= patrolDistance)
                {
                    once = false;
                    chased = false;
                    NPCSight.headToPoint = false;
                    checkPoint = patrolPoint2.position;
                }
            }
        }
    }
    
    void HeadToPoint()
    {
        if(Vector3.Distance(transform.position, patrolPoint1.transform.position) < Vector3.Distance(transform.position, patrolPoint2.transform.position))
        {
            navMeshAgent.SetDestination(patrolPoint1.position);
            checkPoint = patrolPoint1.position;
            chased = false;
            NPCSight.headToPoint = false;
        }
        else
        {
            navMeshAgent.SetDestination(patrolPoint2.position);
            checkPoint = patrolPoint2.position;
            chased = false;
            NPCSight.headToPoint = false;
        }
    }

    void ChasePlayer()
    {
        if (!transform.GetComponent<NPCController>().swinging)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
    }
}