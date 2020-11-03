using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEntity : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageValue;
    public bool isEnemyWeapon;

    public int GetDamageValue()
    {
        return damageValue;
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.GetComponent<EntityHealth>() != null)
        {
            if (!isEnemyWeapon)
            {
                GameObject entity = hit.gameObject;
                entity.GetComponent<EntityHealth>().currentEntityHealth -= damageValue;
            }
        }
        else if(hit.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController.playerHealth -= damageValue;
            PlayerHUD.UpdatePlayerHUD();
        }
    }
}
