using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Reflectable"))
        {
            //reflect back
        }
        else
        {
            if (collision.gameObject.tag.Equals("Player") || collision.gameObject.GetComponent<EntityHealth>() || collision.gameObject.tag.Equals("Arrow"))
            {
                Destroy(transform.gameObject);
            }

            transform.GetComponent<Rigidbody>().isKinematic = true;
            transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
            transform.parent = collision.transform.parent;
            Destroy(transform.GetComponent<Rigidbody>());
        }
    }
}
