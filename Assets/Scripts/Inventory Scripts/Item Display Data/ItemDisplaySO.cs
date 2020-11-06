using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Assets/Inventory/Item Data")]
public class ItemDisplaySO : ScriptableObject
{
    public int value;
    public GameObject itemLoot;
}
