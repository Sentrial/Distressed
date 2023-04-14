using UnityEngine;

public class DynamiteItem : MonoBehaviour
{
    public void PickUp()
    {
        Destroy(gameObject);
    }
}
