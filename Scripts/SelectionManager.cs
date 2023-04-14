using UnityEngine;
using System.Collections;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public GameObject hoverText;
    public bool isHovering;
    [SerializeField] private Transform player;

    public GameObject timer;
    public TimerUI timerUI;
    public GameObject timeEffect;
    public GameObject timeGlow;

    public PlacementPad placementPad;
    public DynamiteItem dynamite;
    public Lever lever;
    public BoxDoor boxDoor;
    public AnimeGirl girl;
    public PlayerInventory inventory;

    public GameManager manager;


    private Transform currentSelection;

    // Update is called once per frame
    void Update()
    {
        // Get where the player is looking
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // If the player is looking at something...
        if (Physics.Raycast(ray, out hit))
        {
            // Get the selection
            var selection = hit.transform;

            // If the tag is selectable...
            if (selection.tag.Equals("Selectable"))
            {
                // If in range of the selection...
                if (inRange(selection))
                {
                    // Set it as the current selection, and display appropriate text.
                    DisplayText(selection.name);
                    currentSelection = selection;
                    isHovering = true;
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        ActivateItem(selection.name);
                    }
                }
                else
                {
                    hoverText.GetComponent<TextMeshProUGUI>().text = "";
                    currentSelection = null;
                    isHovering = false;
                }
            }
            // If the tag is a button...
            else if (selection.tag.Equals("Button"))
            {
                // If in range of the selection...
                if (inRange(selection))
                {
                    // Set it as the current selection, and display appropriate text.
                    hoverText.GetComponent<TextMeshProUGUI>().text = "Press F to Activate";
                    currentSelection = selection;
                    isHovering = true;
                }
                else
                {
                    hoverText.GetComponent<TextMeshProUGUI>().text = "";
                    currentSelection = null;
                    isHovering = false;
                }
            }
            // If no valid tag...
            else
            {
                hoverText.GetComponent<TextMeshProUGUI>().text = "";
                currentSelection = null;
                isHovering = false;
            }

        }

    }

    // Checks to see if the item the player is looking at is in range of the player.
    bool inRange(Transform selection)
    {
        // If the player is within 6 radius of the selection, return true
        // else, return false.
        if (Mathf.Abs(selection.position.x - player.position.x) < 6
            && Mathf.Abs(selection.position.y - player.position.y) < 6 
            && Mathf.Abs(selection.position.z - player.position.z) < 6)
        {
            return true;
        }

        return false;
    }

    // Returns what the player is currently looking at and in range of
    public Transform getCurrentSelection()
    {
        return currentSelection;
        
    }
    // Displays appropriate text per selectable
    void DisplayText(string name)
    {
        if (name.Equals("sand_clock"))
        {
            hoverText.GetComponent<TextMeshProUGUI>().text = "Press F to Activate Time Machine";
        }
        if (name.Equals("Dynamite Item"))
        {
            hoverText.GetComponent<TextMeshProUGUI>().text = "Press F to Collect Dynamite";
        }
        if (name.Equals("Placement Pad"))
        {
            if (inventory.dynamiteCollected)
                hoverText.GetComponent<TextMeshProUGUI>().text = "Press F to Place Dynamite";
            else
                hoverText.GetComponent<TextMeshProUGUI>().text = "Find an Explosive to Place";
        }
        if (name.Equals("Lever Handle"))
        {
            hoverText.GetComponent<TextMeshProUGUI>().text = "Press F to Activate";
        }
    }

    // Activates specific item / selectable
    void ActivateItem(string name)
    {
        if (name.Equals("Dynamite Item"))
        {
            dynamite.PickUp();
            inventory.setDynamiteCollected(true);
            return;
        }
        if (name.Equals("sand_clock"))
        {
            StartCoroutine(TimeTravel());
            return;
        }
        if (name.Equals("Placement Pad"))
        {
            if (inventory.dynamiteCollected)
            {
                placementPad.placeDynamite();
            }
            return;
        }
        if (name.Equals("Lever Handle"))
        {
            timer.SetActive(false);
            StartCoroutine(LeverDoorAnimation());
        }
    }

    IEnumerator TimeTravel()
    {
        timeGlow.SetActive(true);
        timeEffect.SetActive(true);
        yield return new WaitForSeconds(5);
        Destroy(timeGlow);
        Destroy(timeEffect);
        timerUI.SetMinSec(0, 30);
    }

    // End Game Bad Animation Sequence
    IEnumerator LeverDoorAnimation()
    {
        lever.Activate();
        yield return new WaitForSeconds(1f);
        boxDoor.Open();
        yield return new WaitForSeconds(1.5f);
        girl.Power();
        yield return new WaitForSeconds(2f);
        manager.EndGameBad();
    }
}
