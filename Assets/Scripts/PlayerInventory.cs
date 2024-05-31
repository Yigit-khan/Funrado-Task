using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Door> keys = new List<Door>();

    public void AddKey(Door door)
    {
        if (!keys.Contains(door))
        {
            keys.Add(door);
        }
    }

    public bool HasKey(Door door)
    {
        return keys.Contains(door);
    }

    public void UseKey(Door door)
    {
        if (keys.Contains(door))
        {
            keys.Remove(door);
        }
    }
}
