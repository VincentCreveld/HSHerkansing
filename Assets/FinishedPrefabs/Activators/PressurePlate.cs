using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : ActivatorObjects
{
    //depressionSpeed: speed at which the pressurePlate should move
    public int depressionSpeed;

    //startPos: where the pressurePlate begins its movement
    //difference: how much it should move
    //endPos: where the pressurePlate ends up when depressed
    public Vector3 startPos, difference;
    Vector3 endPos; 

    // depressed: whether the pressure plate is activated
    bool depressed;


	void Start ()
    {
        startPos = this.transform.position;
        endPos   = startPos + difference;

        triggered = false;
        depressed = false;
	}
	
	void Update ()
    {
        //if resetAutomatically is true, the pressurePlate will only be deactivated after a certain time from removing pressure from it
        if (resetAutomatically)
        {
            internalReset -= Time.deltaTime;
            if(internalReset <= 0)
                depressed = false;
        }

        //move down if depressed, else move up
        if (depressed)
            this.transform.position = Vector3.MoveTowards(this.transform.position, endPos, depressionSpeed * Time.deltaTime);
        else
        {
            triggered = false;
            this.transform.position = Vector3.MoveTowards(this.transform.position, startPos, depressionSpeed * Time.deltaTime);
        }
	}

    //consider this pressureplate activated as long as anything is on it
    void OnTriggerStay( Collider other)
    {
        if (other.tag != "Weapon")
        {
            depressed = true;
            triggered = true;
            if (resetAutomatically)
                internalReset = resetAfter;
        }
    }
    //deactivate this when anything leaves it
    void OnTriggerExit()
    {
        if (!resetAutomatically)
            depressed = false;
    }
}
