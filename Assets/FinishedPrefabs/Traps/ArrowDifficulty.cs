using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDifficulty : MonoBehaviour {

    public ArrowWall leftUnder, leftUp, rightUnder, rightUp;
    public int difficulty, shootingInterval, shotSpeed;

    bool shootingLeft;
    float internalShooting;
    int hardPattern;
	// Use this for initialization
	void Start () {
        shootingLeft = false;
        internalShooting = shootingInterval;
	}

    // Update is called once per frame
    void Update()
    {
        internalShooting -= Time.deltaTime;

        if (internalShooting <= 0)
        {
            if (difficulty == 1)
                SimplePattern();
            else if (difficulty == 2)
                MediumPattern();
            else if (difficulty == 3)
                HardPattern();
            internalShooting = shootingInterval;
        }
    }


    void SimplePattern()
    {
        if(shootingLeft)
        {
            leftUnder.ShootArrow();
            leftUp.ShootArrow();
        }
        else
        {
            rightUnder.ShootArrow();
            rightUp.ShootArrow();
        }
        shootingLeft = !shootingLeft;
    }

    void MediumPattern()
    {
        if (shootingLeft)
        {
            leftUnder.ShootArrow();
            rightUp.ShootArrow();
        }
        else
        {
            leftUp.ShootArrow();
            rightUnder.ShootArrow();
        }
        shootingLeft = !shootingLeft;
    }

    void HardPattern()
    {
        if(hardPattern == 0)
        {
            leftUnder.ShootArrow();
            leftUp.ShootArrow();
            rightUp.ShootArrow();
        }
        else if( hardPattern == 1)
        {
            rightUnder.ShootArrow();
            leftUp.ShootArrow();
            rightUp.ShootArrow();
        }
        else if (hardPattern == 2)
        {
            rightUnder.ShootArrow();
            leftUnder.ShootArrow();
            rightUp.ShootArrow();
        }
        else if (hardPattern == 3)
        {
            rightUnder.ShootArrow();
            leftUnder.ShootArrow();
            leftUp.ShootArrow();
        }
        else if (hardPattern == 4)
        {
            rightUnder.ShootArrow();
            leftUnder.ShootArrow();
            leftUp.ShootArrow();
            rightUp.ShootArrow();
        }
        hardPattern += 1;
        if (hardPattern > 4)
            hardPattern = 0;
    }

    void AlterDifficulty()
    {

    }
}
