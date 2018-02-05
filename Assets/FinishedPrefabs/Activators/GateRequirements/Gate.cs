using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : Activatable
{
    Vector3 endRot;

    Quaternion endRotation, beginRotation;

    public Vector3 rotateGoal;
    public float moveSpeed;
    bool lastActivated;
    public AudioSource openGate = null;
    public Quaternion endDifRot { get; set; }

    // Use this for initialization
    void Start()
    {
        Prepare();
    }

    void Prepare()
    {
        Begin();
        beginRotation = transform.rotation;
        endRotation = Quaternion.Euler(rotateGoal + transform.parent.rotation.eulerAngles);
        lastActivated = activated;
        endDifRot = endRotation;
    }

    // Update is called once per frame
    void Update()
    {
        base.baseUpdate();

            if (activated)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, endRotation, moveSpeed * 10 * Time.deltaTime);
            else
                transform.rotation = Quaternion.RotateTowards(transform.rotation, beginRotation, moveSpeed * 10 * Time.deltaTime);

        if (activated != lastActivated && openGate != null)
        {
            openGate.Play();
            Debug.Log("soundPlayed");
        }
        lastActivated = activated;
    }
}
