using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator animator;
    public SelectionManager selectionManager;
    public bool blueButtonPressed;
    public bool greenButtonPressed;
    public bool redButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        blueButtonPressed = false;
        greenButtonPressed = false;
        redButtonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is currently hovering on a button...
        if (selectionManager.isHovering && selectionManager.getCurrentSelection().tag.Equals("Button"))
        {
            // If the F key is pressed...
            if (Input.GetKeyDown(KeyCode.F))
            {
                // If it is the blue button....
                if (selectionManager.getCurrentSelection().name.Equals("Blue Button"))
                {
                    blueButtonPressed = true;
                    animator.SetTrigger("pressed");
                }
                // If it is the green button....
                if (selectionManager.getCurrentSelection().name.Equals("Green Button"))
                {
                    greenButtonPressed = true;
                    animator.SetTrigger("pressed");
                }
                // If it is the green button....
                if (selectionManager.getCurrentSelection().name.Equals("Red Button"))
                {
                    redButtonPressed = true;
                    animator.SetTrigger("pressed");
                }

            }
        }
        // Reset trigger
        else
        {
            animator.ResetTrigger("pressed");
        }
    }

    
    public bool isParentButtonPressed(string s)
    {
        // Returns the state of the button sent in to this method.
        if (s.Equals("Blue Button"))
        {
            return blueButtonPressed;
        }
        else if (s.Equals("Green Button"))
        {
            return greenButtonPressed;
        }
        else if (s.Equals("Red Button"))
        {
            return redButtonPressed;
        }

        return false;
    }
}
