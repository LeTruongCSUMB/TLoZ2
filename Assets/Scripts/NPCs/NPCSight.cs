using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSight : MonoBehaviour
{

    public GameObject NPC;
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public string playerTag = "Player";
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    private Transform NPCHead;
    private float t = 0.0f;
    public static int caseNum;
    public static bool headToPoint, hasDied;

    //[HideInInspector]
    public List<GameObject> visibleTargets = new List<GameObject>();

    //private bool inList;

    void Start()
    {
        RestartNPC();
    }

    void FixedUpdate()
    {
        if (NPCPatrol.isAtPoint)
        {
            switch (caseNum)
            {
                case 1:
                    NPCHead.localRotation = Quaternion.Euler(0.0f, Mathf.Lerp(0.0f, 90.0f, t), 0.0f);
                    t += 0.95f * Time.deltaTime;
                    if (t > 1.0f)
                    {
                        t = 0.0f;
                        NPCHead.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                        caseNum = 2;
                    }
                    break;

                case 2:
                    NPCHead.localRotation = Quaternion.Euler(0.0f, Mathf.Lerp(90.0f, 0.0f, t), 0.0f);
                    t += 0.95f * Time.deltaTime;
                    if (t > 1.0f)
                    {
                        t = 0.0f;
                        NPCHead.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                        caseNum = 3;
                    }
                    break;


                case 3:
                    NPCHead.localRotation = Quaternion.Euler(0.0f, Mathf.Lerp(0.0f, -90.0f, t), 0.0f);
                    t += 0.95f * Time.deltaTime;
                    if (t > 1.0f)
                    {
                        t = 0.0f;
                        NPCHead.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                        caseNum = 4;
                    }
                    break;


                case 4:
                    NPCHead.localRotation = Quaternion.Euler(0.0f, Mathf.Lerp(-90.0f, 0.0f, t), 0.0f);
                    t += 0.95f * Time.deltaTime;
                    if (t > 1.0f)
                    {
                        t = 0.0f;
                        NPCHead.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                        caseNum = 5;
                    }
                    break;


                case 5:
                    NPCPatrol.isAtPoint = false;
                    headToPoint = true;
                    caseNum = 0;
                    break; 
            }
        }
        if (NPC.transform.GetComponent<EntityHealth>() != null)
        {
            if (!NPC.transform.GetComponent<EntityHealth>().respawnTime && hasDied)
            {
                print("Only once");
                RestartNPC();
            }
        }
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        //visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            GameObject target = targetsInViewRadius[i].gameObject;
            Vector3 dirToTarget = (target.transform.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.transform.position);

                if(Physics.Raycast(transform.position, dirToTarget, dstToTarget, 1))
                {
                    print(target.name);
                    if(target.tag.Equals("Player"))
                    {
                        if (NPC.transform.GetComponent<NPCPatrol>() != null)
                        {
                            NPC.transform.GetComponent<NPCPatrol>().attacking = true;
                        }
                    }
                }

                /*if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {

                    if (visibleTargets.Count == 0)                                          //When list is started
                    {
                        visibleTargets.Add(NPC);                                            //Add the itself to the list
                    }
                    else
                    {
                        for (int k = 0; k < visibleTargets.Count; k++)                      //Goes through list of seen
                        {

                            if (visibleTargets[k] == target)                                //If target matches with target in list
                            {

                                inList = true;                                              //Then bool inList goes true

                                if(visibleTargets[k].tag == "NPC")
                                {
                                    GameObject visibleNPC = visibleTargets[k];
                                }
                                else if(visibleTargets[k].tag == "Player")
                                {
                                    GameObject visiblePlayer = visibleTargets[k];
                                }
                            }
                        }
                        if(inList != true)                                                  //If inList is false
                        {
                            visibleTargets.Add(target);                                     //Add the target as a new target to the List
                        }
                        else
                        {
                            inList = false;                                                 //Else reset inList
                        }
                    }
                }*/
            }
        }
    }

    public void RestartNPC()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
        NPCHead = transform;
        caseNum = 0;
        headToPoint = false;
        hasDied = false;
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
