using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // warningTime: Time the player has from triggering the trap to it activating
    // protrudeTime: The time the spikes remain up
    // resetTime: The time it takes after the trap is done for it to be capable of being activated again
    // extendTime: The time it costs for the spikes to extend to their full length
    // internal_: The tracking of aforementioned times
    public float   protrudeTime ,timeToExtend;
    float  internalProtrude, speed;
    public AudioSource extend;

    // inProgress: becomes true when the trap is activated
    // dangerous: is true when protrudeTime is non-zero, if the player is inside the spikes, they take damage.
    bool inProgress, dangerous;

    // difference: The amount the spikes should move
    public Vector3 difference;

    // startPos: spike start position
    // currentGoal: The location the spikes should be at the moment
    Vector3 startPos, currentGoal;

    void Start()
    {
        startPos = transform.position;
        currentGoal = startPos;
        speed = Vector3.Distance(Vector3.zero, difference) / timeToExtend;
        internalProtrude = 0;
    }

    void Update()
    {
        CheckReturn();
        transform.position = Vector3.MoveTowards(transform.position, currentGoal, speed * Time.deltaTime);
    }

    //Extends the spikes
    public void Extend()
    {
        internalProtrude = protrudeTime;
        currentGoal = startPos + difference;
        extend.Play();

    }

    void CheckReturn()
    {
        if (internalProtrude > 0)
        {
            internalProtrude -= Time.deltaTime;
            if (internalProtrude <= 0)
            {
                //internalProtude has run out, so go back to startPos and become safe
                internalProtrude = 0;
                currentGoal = startPos;
            }

        }
    }
}
