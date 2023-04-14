using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensitivity : MonoBehaviour
{

    // Set the mouse sensitivity
    public void SetSensitivity(float sense)
    {
        PlayerPrefs.SetFloat("Sensitivity", sense);
    }
    
}
