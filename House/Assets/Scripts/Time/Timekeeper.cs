using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Timekeeper : MonoBehaviour {
    private DateTime _houseTime;    //current time in the house
    private DateTime _startTime;    //start time of game
    private float minuteOffset;     //how many minutes offset from real world time the game world should be
    private GameObject[] clocks;    //array that stores all the GameObjects tagged as "Clock" in the scene 

	// Use this for initialization
	void Start ()
    {
        //initializes minute offset to 0
        minuteOffset = 0.0f;

        //this function call returns an array of all GameObjects with the tag "Clock" and stores it in the clocks array
        clocks = GameObject.FindGameObjectsWithTag("Clock");

        //sets _startTime and _houseTime to the current real world time
        _startTime = DateTime.Now;
        _houseTime = _startTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //gets current time in House by adding the minutes to offset to the minutes of the current time
        _houseTime = DateTime.Now.AddMinutes(minuteOffset);

        //sets all clocks in the house
        setHouseClocks();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 160, 20), _houseTime.ToString());     
    }

    //iterates through all clock objects inside the house and sends a message to their set time function, passing in the current house time as a parameter
    public void setHouseClocks()
    {
        foreach (GameObject obj in clocks)
        {
            obj.SendMessage("setTime", _houseTime);
        }
    }

    //this function simply returns the current time in the house
    public DateTime getHouseTime()
    {
        return _houseTime;
    }

    //function that increments or decrements the minute offset based on player input
    public void setTime(bool clockWise)
    {
        if (clockWise)
        {
            minuteOffset += (20.0f * Time.deltaTime);
        }
        else
        {
            minuteOffset -= (20.0f * Time.deltaTime);
        }
    }
}
