using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : ActivatorObjects
{
    public Vector3 endRot, beginRot;
    Quaternion goalRot;
    public Transform handle;
    public GameObject player;
    public float angleSpeed;

    public bool pullable;

    // Use this for initialization
    void Start()
    {
        handle.rotation = Quaternion.Euler(beginRot);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1f && Input.GetKeyDown(KeyCode.E))
        {
            triggered = !triggered;
        }

        if (triggered)
            goalRot = Quaternion.Euler(endRot);
        else
            goalRot = Quaternion.Euler(beginRot);

        handle.rotation = Quaternion.RotateTowards(handle.rotation, goalRot, angleSpeed * Time.deltaTime);
    }


}
