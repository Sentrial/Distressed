using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool power = false;

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.name == "Power")
        {
            
            collision.transform.localScale = new Vector3(.25f,.25f,.25f);
            power = true;
            
        }

        if (collision.gameObject.name == "EndGame")
        {
            Debug.Log("power = " + power);
            if (power)
            {
                Debug.Log(collision.gameObject.name);
                collision.rigidbody.AddForce(0,0,1000f);
            }
        }
    }
}
