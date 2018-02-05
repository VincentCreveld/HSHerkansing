using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorObjects : MonoBehaviour
{
    //triggered: true when the activator is in use
    //resetAutomatically: true if the Activator should reset after a certain time
    public bool triggered, resetAutomatically;
    //resetAfter: the time after which the Activator should reset
    public float resetAfter;
    //internalReset: time tracker for reset duration
    protected float internalReset;
}
