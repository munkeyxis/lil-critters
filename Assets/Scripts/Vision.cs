using UnityEngine;

public class Vision : MonoBehaviour 
{
    private CritterBrain brain;
    private bool seesSomething;
    private Collider thingSeen;

    private void Start()
    {
        brain = transform.parent.GetComponent<CritterBrain>();
        seesSomething = false;
    }

    private void Update()
    {
        if(seesSomething)
        {
            if(thingSeen) // Have to do this because OnTriggerExit is not called when the object is destroyed
            {
                return;
            }
            seesSomething = false;
        }

        brain.ViewedNothing();
    }

    private void OnTriggerEnter(Collider other)
    {
        LogTrigger(other);
        seesSomething = true;
        thingSeen = other;
    }

    private void OnTriggerStay(Collider other) 
    {
        brain.ViewedColor(); // BUG: critters spawn with something in their Vision collider, this method triggers before Start().
        // Need workaround. Move brain assignment to Awake() or delay activating Vision collider.
    }

    private void OnTriggerExit()
    {
        // BUG: This isn't called when the trigger is Destroyed
        // Work around: Update() checks that the seenObject still exists and will set to false if it is not
        seesSomething = false;
    }

    private void LogTrigger(Collider other)
    {
        OrganismColors otherColor = other.GetComponent<OrganismColor>().color;
        Debug.Log("Triggered by something that is the color " + otherColor.ToString()); // Temporary
    }
}
