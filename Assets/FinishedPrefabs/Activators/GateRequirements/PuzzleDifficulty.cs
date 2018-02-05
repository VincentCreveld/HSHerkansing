using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDifficulty : MonoBehaviour {
    public Gate gate1, gate2;
    public int DifLowerThan;
    Quaternion endRot1, endRot2;
    public float moveSpeed = 20;
    public int difficulty = 3;

    // Use this for initialization
    void Start () {
        endRot1 = gate1.endDifRot;
        endRot2 = gate2.endDifRot;
        gate1.moveSpeed = moveSpeed;
        gate2.moveSpeed = moveSpeed;
	}

    // Update is called once per frame
    void Update()
    {
        if (difficulty < DifLowerThan)
        {
            gate1.enabled = false;
            gate1.transform.rotation = Quaternion.RotateTowards(gate1.transform.rotation, endRot1, moveSpeed * 10 * Time.deltaTime);
            gate2.enabled = false;
            gate2.transform.rotation = Quaternion.RotateTowards(gate2.transform.rotation, endRot2, moveSpeed * 10 * Time.deltaTime);
        }
        else
        {
            gate2.enabled = true;
            gate1.enabled = true;
        }
    }
}
