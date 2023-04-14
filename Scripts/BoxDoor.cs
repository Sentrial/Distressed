using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDoor : MonoBehaviour
{
    public Animator animator;

    public void Open()
    {
        animator.SetTrigger("activated");
    }
}
