using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI itemText;
    // Start is called before the first frame update
    void Start()
    {
        itemText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateItemText(PlayerInventory playerInventory)
    {
        
    }
}
