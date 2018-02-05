using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWall : MonoBehaviour
{
    //The Arrow Prefab
    public GameObject Arrow;

    //shootingInterval: the amount of time between arrow shots
    //arrowSpeed, the flight speed of the arrow
    //arrowDistance: how far the arrow flies max
    //AmountOfholes: amount of holes that fire arrows
    //holeinterval: the distance in y
    public float arrowSpeed, arrowDistance, disFromCenter;

    //arrowRot: the rotation of the arrow
    //holeRot: the rotation of the holes
    //correctTarget: the end destination of the arrow.
    public Vector3 arrowRot, correctTarget;



    void Start()
    {
        RaycastHit hit = new RaycastHit();
        if (transform.parent.rotation.eulerAngles.y == 0)
            Physics.Raycast(transform.position, Vector3.forward, out hit);
        else if (transform.parent.rotation.eulerAngles.y == 90)
            Physics.Raycast(transform.position, Vector3.right, out hit);
        else if (transform.parent.rotation.eulerAngles.y == 180)
            Physics.Raycast(transform.position, Vector3.back, out hit);
        else if (transform.parent.rotation.eulerAngles.y == 270)
            Physics.Raycast(transform.position, Vector3.left, out hit);
        else
            Debug.Log("Raycast Failed");

        arrowDistance = hit.distance;

        correctTarget = transform.rotation * new Vector3(0, 0, -arrowDistance);

        arrowRot = transform.rotation.eulerAngles;

    }


    //Creates an arrow and attaches the script that makes it move and destory itself
    public void ShootArrow()
    {
        Vector3 tempArrow, localAlteration;
        localAlteration = new Vector3(-disFromCenter - 0.02f, -disFromCenter, 0);
        tempArrow = transform.position + (transform.parent.rotation * localAlteration);

        CreateArrow(tempArrow, localAlteration);

        localAlteration = new Vector3(disFromCenter - 0.02f, -disFromCenter, 0);
        tempArrow = transform.position + (transform.parent.rotation * localAlteration);

        CreateArrow(tempArrow, localAlteration);

        localAlteration = new Vector3(-disFromCenter - 0.02f, disFromCenter, 0);
        tempArrow = transform.position + (transform.parent.rotation * localAlteration);

        CreateArrow(tempArrow, localAlteration);

        localAlteration = new Vector3(disFromCenter - 0.02f, disFromCenter, 0);
        tempArrow = transform.position + (transform.parent.rotation * localAlteration);

        CreateArrow(tempArrow, localAlteration);
    }

    void CreateArrow( Vector3 tempArrow, Vector3 localAlteration)
    {
        GameObject arrow; 
        arrow = Instantiate(Arrow, tempArrow, Quaternion.Euler(arrowRot));
        WallArrow attached = arrow.GetComponent<WallArrow>();
        attached.goalPosition = attached.transform.position - correctTarget;
        attached.speed = arrowSpeed;
    }
}
