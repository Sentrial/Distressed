using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator animator;
    public void Activate()
    {
        animator.SetTrigger("activated");
    }
}
