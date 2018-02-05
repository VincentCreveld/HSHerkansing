using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDifficulty : MonoBehaviour
{

    public Axe axe1, axe2, axe3;
    public int difficulty;

    public Vector3 difference;
    public float swingTime1 = 3, swingTime2 = 4, swingTime3 = 5;

    void Start()
    {
        SetAxes(axe1);
        SetAxes(axe2);
        SetAxes(axe3);
        axe1.swingTime = swingTime1;
        axe2.swingTime = swingTime2;
        axe3.swingTime = swingTime3;
        axe1.Prepare();
        axe2.Prepare();
        axe3.Prepare();
    }

    void SetAxes(Axe axe)
    {
        axe.difference = difference;
    }

    // Update is called once per frame
    void Update()
    {

        switch (difficulty)
        {
            case 1:
                axe1.enabled = true;
                axe2.Reset();
                axe3.Reset();
                axe2.gameObject.SetActive(false);
                axe3.gameObject.SetActive(false);
                break;
            case 2:
                axe1.enabled = true;
                axe2.enabled = true;
                axe3.Reset();
                axe2.gameObject.SetActive(true);
                axe3.gameObject.SetActive(false);
                break;
            case 3:
                axe1.enabled = true;
                axe2.enabled = true;
                axe3.enabled = true;
                axe2.gameObject.SetActive(true);
                axe3.gameObject.SetActive(true);
                break;

        }

    }
}
