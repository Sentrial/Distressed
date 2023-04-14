using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public bool dynamiteCollected;

    //public UnityEvent<PlayerInventory> OnItemCollected;

    private void Start()
    {
        dynamiteCollected = false;
    }
    
    public void setDynamiteCollected(bool b)
    {
        dynamiteCollected = b;
    }
}
