using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeGirl : MonoBehaviour
{
    public Animator animator;
    public void Power()
    {
        animator.SetTrigger("power");
    }
}
