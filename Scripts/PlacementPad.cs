using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlacementPad : MonoBehaviour
{
    public PlayerInventory inventory;
    public GameObject dynamite;
    public void placeDynamite()
    {
        dynamite.SetActive(true);
        inventory.dynamiteCollected = false;
    }
}
