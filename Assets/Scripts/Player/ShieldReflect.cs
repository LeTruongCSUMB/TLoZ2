using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldReflect : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Arrow"))
        {
            print("arrow");
            if (player.GetComponent<PlayerTools>().reflecting)
            {
                print("reflecting is true");
                player.GetComponent<PlayerTools>().ShieldDefense(other.gameObject);
            }
            else
            {
                print("reflecting is false");
            }
        }
    }
}
