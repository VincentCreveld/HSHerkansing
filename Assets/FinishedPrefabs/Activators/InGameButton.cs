using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButton : ActivatorObjects
{
    public List<InGameButton> theOtherButtons;
    public bool pushable;

    // Use this for initialization
    void Start()
    {
        theOtherButtons = new List<InGameButton>();
        GameObject[] possibleButtons;
        possibleButtons = GameObject.FindGameObjectsWithTag(gameObject.tag);
        foreach(GameObject mebbeButton in possibleButtons)
        {
            if (mebbeButton.GetComponent<InGameButton>() != null && mebbeButton.GetComponent<InGameButton>() != this)
            {
                theOtherButtons.Add(mebbeButton.GetComponent<InGameButton>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger got pressed
        if (Input.GetKeyDown(KeyCode.E) && pushable)
        {
            triggered = !triggered;
            foreach(InGameButton button in theOtherButtons)
                button.triggered = triggered;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            pushable = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            pushable = false;
    }
}
