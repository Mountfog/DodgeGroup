using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour
{
    public int id;
    public int itemType;
    public int value;
    public void Initialize(int i, int kvalue)
    {
        id = i;
        itemType = id % 2;
        value = kvalue;
    }
}
