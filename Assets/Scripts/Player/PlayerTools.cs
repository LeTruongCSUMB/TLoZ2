using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    public bool hasSword;
    public bool getHasSword() { return hasSword; }

    public bool hasShield;
    public bool getHasShield() { return hasShield; }

    public bool hasBow;
    public bool getHasBow() { return hasBow;  }

    public List<AudioClip> playerAudio;

    public GameObject sword;
    private float startRot = 90.0f;
    private float finalRot = -90.0f;
    private float time = 0.0f;
    public static bool swinging;
    public float swingSpeed;
    

    public GameObject shield;
    public static bool shielding;
    public bool reflecting;
    public float shieldTime;
    private float sTime = 0.0f;

    public GameObject bow;
    public GameObject arrow;
    public Transform shotPos;
    public Transform refShotPos;
    public static float cooldownRef = 3.0f;
    public static float cooldown;

    public static int arrowCount;
    public static int maxArrowCount = 99;

    // Start is called before the first frame update
    void Start()
    {
        sword.SetActive(false);
        shield.SetActive(false);
        bow.SetActive(false);
        cooldown = cooldownRef;
        swinging = false;
    }

    // Update is called once per frame
    void Update()
    {
        // SWORD "ANIMATION"
        if(swinging)
        {
            sword.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Lerp(startRot, finalRot, time));
            time += swingSpeed * Time.deltaTime;

            if (time > swingSpeed)
            {
                transform.GetComponent<AudioSource>().PlayOneShot(playerAudio[0]);
                time = 0.0f;
                sword.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, startRot);
                sword.SetActive(false);
                swinging = false;
                
            }
        }

        // IF PRESSING SPACE
        if (Input.GetKey(KeyCode.Space))
        {
            if (bow.activeSelf)
            {
                BowAttack();
            }
            else
            {
                if (hasSword && !swinging)
                {
                    SwordAttack();
                }
            }
        }

        // HOLDING LEFT SHIFT
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(hasShield)
            {
                shield.SetActive(true);
                shielding = true;
                sTime += shieldTime * Time.deltaTime;

                if (sTime < shieldTime)
                {
                    reflecting = true;
                }
                else if (sTime > shieldTime)
                {
                    reflecting = false;
                }
                print("Reflecting = " + reflecting);
            }
        }
        else
        {
            shield.SetActive(false);
            sTime = 0.0f;
            shielding = false;
        }

        // HOLDING RIGHT SHIFT
        if(Input.GetKey(KeyCode.RightShift))
        {
            if (hasBow)
            {
                bow.SetActive(true);
            }
        }
        else
        {
            bow.SetActive(false);
        }
    }

    // SHIELD
    public void ShieldDefense(GameObject projectile)
    {
        print("Reflected");
        Rigidbody arrowShot = Instantiate(projectile.GetComponent<Rigidbody>(), refShotPos.position, refShotPos.rotation) as Rigidbody;
        arrowShot.AddForce(refShotPos.forward * 625.0f);
    }

    // BOW
    void BowAttack()
    {
        if(arrowCount > 0 )
        {
            if (Time.time > cooldownRef)
            {
                transform.GetComponent<AudioSource>().PlayOneShot(playerAudio[1]);
                cooldownRef = Time.time + cooldown;
                arrowCount--;
                Rigidbody arrowShot = Instantiate(arrow.GetComponent<Rigidbody>(), shotPos.position, shotPos.rotation) as Rigidbody;
                arrowShot.AddForce(shotPos.forward * 500.0f);
                PlayerHUD.UpdatePlayerHUD();
            }
        }
    }

    // SWORD
    void SwordAttack()
    {
        sword.SetActive(true);
        sword.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, startRot);
        swinging = true;
    }
}
