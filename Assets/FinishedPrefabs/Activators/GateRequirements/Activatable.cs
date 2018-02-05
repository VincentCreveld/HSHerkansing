using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour
{
    //startActivated: if this is true, the activatable already is on, and will be turned off when all activators are turned on.
    public bool startActivated;
    
    //triggersAreOn: true if all triggers belonging to this door that are supposed to be on are activated.
    //triggersAreOff: true if all triggers that are needed to be deactivated are deactivated.
    //activated: at the start the same as startActivated, the current state of the Activatable.
    protected bool triggerStateCorrect, activated;

    //lists of the triggers required
    public List<ActivatorObjects> triggersRequired;

    protected void Begin()
    {
        triggersRequired = new List<ActivatorObjects>();

        activated = startActivated;
        GameObject[] triggersfound;
        triggersfound = GameObject.FindGameObjectsWithTag(gameObject.tag);
        foreach (GameObject trigger in triggersfound)
        {
            if (trigger.GetComponent<InGameButton>() != null)
            {
                triggersRequired.Add(trigger.GetComponent<InGameButton>());
            }
            else if (trigger.GetComponent<Lever>() != null)
            {
                triggersRequired.Add(trigger.GetComponent<Lever>());
            }
            else if (trigger.GetComponent<PressurePlate>() != null)
            {
                triggersRequired.Add(trigger.GetComponent<PressurePlate>());
            }
        }
    }
	
	protected void baseUpdate ()
    {
        CheckTriggers();

        //If all triggers are correct, switch activation state, if not, return to standard state.
        if (triggerStateCorrect)
            activated = !startActivated;
        else
            activated = startActivated;
    }

    //Checks whether all triggers are in there correct state.
    protected void CheckTriggers()
    {
        if (triggersRequired.Count == 0)
            triggerStateCorrect = true;
        else
            foreach (ActivatorObjects triggerOn in triggersRequired)
            {
                if (!triggerOn.triggered)
                {
                    triggerStateCorrect = false;
                    break;
                }
                else
                    triggerStateCorrect = true;
            }
    }
}
