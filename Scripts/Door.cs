using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public Button buttonParent;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the parent butto is activated, open.
        if (buttonParent.isParentButtonPressed(buttonParent.name))
        {
            animator.SetTrigger("activated");
        }
    }
}
