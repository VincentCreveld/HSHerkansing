using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDifficulty : MonoBehaviour {

    public Spikes spike1, spike2, spike3, spike4, spike5, spike6, spike7, spike8, spike9;
    public List<float> extendInterval;
    float internalExtend;
    int simpleTrack, mediumTrack, hardTrack;
    public int difficulty;

	// Use this for initialization
	void Start () {
        internalExtend = extendInterval[difficulty];
        simpleTrack = 1;
        mediumTrack = 1;
        hardTrack = 1;
	}
	
	// Update is called once per frame
	void Update () {
        internalExtend -= Time.deltaTime;
        if (internalExtend <= 0)
        {
            if (difficulty == 1)
                SimplePattern();
            else if (difficulty == 2)
                MediumPattern();
            else if (difficulty == 3)
                HardPattern();
            internalExtend = extendInterval[difficulty-1];
        }
	}

    void SimplePattern()
    {
        if(simpleTrack == 1)
        {
            spike1.Extend();
            spike2.Extend();
            spike3.Extend();
            spike4.Extend();
            spike5.Extend();
            spike6.Extend();
        }
        else if( simpleTrack == 2 || simpleTrack == 4)
        {
            spike1.Extend();
            spike2.Extend();
            spike3.Extend();
            spike7.Extend();
            spike8.Extend();
            spike9.Extend();
        }
        else
        {
            spike4.Extend();
            spike5.Extend();
            spike6.Extend();
            spike7.Extend();
            spike8.Extend();
            spike9.Extend();
        }
        simpleTrack += 1;
        if (simpleTrack > 4)
            simpleTrack = 1;
    }

    void MediumPattern()
    {
        if(mediumTrack == 1 || mediumTrack == 3)
        {
            spike1.Extend();
            spike3.Extend();
            spike5.Extend();
            spike7.Extend();
            spike9.Extend();
        }
        else if (mediumTrack == 2 || mediumTrack == 4 || mediumTrack == 5)
        {
            spike2.Extend();
            spike4.Extend();
            spike6.Extend();
            spike8.Extend();
        }
        mediumTrack += 1;
        if (mediumTrack > 5)
            mediumTrack = 1;
    }

    void HardPattern()
    {
        if( hardTrack == 1)
        {
            spike1.Extend();
            spike3.Extend();
            spike4.Extend();
            spike6.Extend();
            spike7.Extend();
            spike8.Extend();
            spike9.Extend();
        }
        else if(hardTrack == 2)
        {
            spike1.Extend();
            spike2.Extend();
            spike3.Extend();
            spike4.Extend();
            spike6.Extend();
            spike7.Extend();
            spike8.Extend();
            spike9.Extend();
        }
        else if (hardTrack == 3)
        {
            spike1.Extend();
            spike2.Extend();
            spike3.Extend();
            spike6.Extend();
            spike7.Extend();
            spike8.Extend();
            spike9.Extend();
        }
        else if (hardTrack == 4)
        {
            spike1.Extend();
            spike2.Extend();
            spike3.Extend();
            spike5.Extend();
            spike6.Extend();
            spike7.Extend();
            spike8.Extend();
            spike9.Extend();
        }
        else if (hardTrack == 5)
        {
            spike1.Extend();
            spike2.Extend();
            spike3.Extend();
            spike6.Extend();
            spike7.Extend();
            spike8.Extend();
            spike9.Extend();
        }
        else if (hardTrack == 6)
        {
            spike1.Extend();
            spike2.Extend();
            spike3.Extend();
            spike4.Extend();
            spike6.Extend();
            spike7.Extend();
            spike8.Extend();
            spike9.Extend();
        }
        else if (hardTrack == 7)
        {
            spike1.Extend();
            spike2.Extend();
            spike3.Extend();
            spike4.Extend();
            spike7.Extend();
            spike8.Extend();
            spike9.Extend();
        }
        else if (hardTrack == 8)
        {
            spike1.Extend();
            spike2.Extend();
            spike3.Extend();
            spike4.Extend();
            spike5.Extend();
            spike7.Extend();
            spike8.Extend();
            spike9.Extend();
        }
        else if (hardTrack == 9)
        {
            spike1.Extend();
            spike2.Extend();
            spike3.Extend();
            spike4.Extend();
            spike5.Extend();
            spike7.Extend();
            spike8.Extend();
        }
        else if (hardTrack == 10)
        {
            spike1.Extend();
            spike2.Extend();
            spike3.Extend();
            spike4.Extend();
            spike5.Extend();
            spike7.Extend();
            spike6.Extend();
        }
        else if (hardTrack == 11)
        {
            spike1.Extend();
            spike9.Extend();
            spike3.Extend();
            spike4.Extend();
            spike5.Extend();
            spike7.Extend();
            spike6.Extend();
        }
        else if (hardTrack == 12)
        {
            spike1.Extend();
            spike9.Extend();
            spike3.Extend();
            spike4.Extend();
            spike5.Extend();
            spike7.Extend();
            spike6.Extend();
            spike8.Extend();
        }
        hardTrack += 1;
        if (hardTrack > 12)
            hardTrack = 1;
    }

     void AlterDifficulty()
    {

    }
}
