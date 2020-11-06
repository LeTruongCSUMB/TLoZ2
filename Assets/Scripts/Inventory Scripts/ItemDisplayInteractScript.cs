using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ItemDisplayInteractScript : MonoBehaviour
{
    public ItemDisplaySO itemData;
    public Transform displayCoord;
    public Flowchart flowchart;
    public string dialogue;
    

    void Start()
    {
        GameObject displayObject = Instantiate(itemData.itemLoot, displayCoord.position, Quaternion.identity);
        displayObject.GetComponent<LootPickUpScript>().enabled = false;
        displayObject.GetComponent<SphereCollider>().enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {                        
            if(other.GetComponent<PlayerController>() != null)
            {
                other.GetComponent<PlayerController>().SetDisplay(this.gameObject);
                flowchart.ExecuteBlock(dialogue);
            }
        }
    }

    //Returns name of item
    public string getItemName() 
    {
        return itemData.itemLoot.name;
    }

    //Returns value of item
    public int getValue()       
    {
        return itemData.value;
    }

    //Returns bool that represents if the player has more/exactly enough luppees compared
    //to the value of the item.
    public bool checkWallet()   
    {
        return PlayerController.lupeeCount >= itemData.value;
    }

    //Instantiates the item while subtracting its value from the player's luppee count
    public void purchaseItem()
    {
        Instantiate(itemData.itemLoot, transform.position, Quaternion.identity);
        PlayerController.lupeeCount -= itemData.value;
    }
}
