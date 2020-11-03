using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public bool isSwordsman;
    public bool isBowsman;

    public GameObject weapon;
    public GameObject rightHand;
    public GameObject arrow;
    public GameObject player;
    public Transform shotPos;
    public float attackDistance;

    private float time = 0.0f;
    public float attackSpeed;
    private float startRot = -45.0f;
    private float finalRot = 45.0f;

    private GameObject npcObject;

    public bool swinging;

    // Start is called before the first frame update
    void Start()
    {
        swinging = false;
        player = GameObject.Find("Player").gameObject;
        npcObject = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (swinging)
        {
            if (!rightHand.activeSelf)
            {
                weapon.transform.localRotation = Quaternion.Euler(0.0f, Mathf.Lerp(startRot, finalRot, time), 0.0f);
                time += attackSpeed * Time.deltaTime;

                if (time > attackSpeed)
                {
                    time = 0.0f;
                    weapon.transform.localRotation = Quaternion.Euler(0.0f, startRot, 0.0f);
                    weapon.SetActive(false);
                    transform.GetComponent<NavMeshAgent>().enabled = true;
                    transform.GetComponent<Rigidbody>().useGravity = true;
                    transform.GetComponent<Rigidbody>().isKinematic = false;
                    rightHand.SetActive(true);
                    swinging = false;
                }
            }
        }
        CheckDistance();
    }

    public void CheckDistance()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance && npcObject.GetComponent<EntityHealth>().currentEntityHealth > 0.0f)
        {
            if (isSwordsman && !swinging)
            {
                NPCSwordAttack();
            }

            if(isBowsman)
            {
                NPCBowAttack();
            }
        }
    }

    void NPCSwordAttack()
    {
        if(transform.GetComponent<NavMeshAgent>() != null && transform.GetComponent<Rigidbody>() != null)
        {
            transform.GetComponent<NavMeshAgent>().enabled = false;
            transform.GetComponent<Rigidbody>().useGravity = false;
            transform.GetComponent<Rigidbody>().isKinematic = true;
        }
        rightHand.SetActive(false);
        weapon.SetActive(true);
        weapon.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, startRot);
        swinging = true;
    }

    void NPCBowAttack()
    {
        transform.LookAt(player.transform);
        time += attackSpeed * Time.deltaTime;

        if (time > attackSpeed)
        {
            if (transform.GetComponent<NavMeshAgent>() != null && transform.GetComponent<Rigidbody>() != null)
            {
                transform.GetComponent<NavMeshAgent>().enabled = false;
                transform.GetComponent<Rigidbody>().useGravity = false;
                transform.GetComponent<Rigidbody>().isKinematic = true;
            }
            time = 0.0f;
            rightHand.SetActive(false);
            weapon.SetActive(true);
            Rigidbody arrowShot = Instantiate(arrow.GetComponent<Rigidbody>(), shotPos.position, shotPos.rotation) as Rigidbody;
            arrowShot.AddForce(shotPos.forward * 500.0f);
        }
        transform.GetComponent<NavMeshAgent>().enabled = true;
        transform.GetComponent<Rigidbody>().useGravity = true;
        transform.GetComponent<Rigidbody>().isKinematic = false;
    }
}
