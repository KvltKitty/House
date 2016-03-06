using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {
    private bool canInteract;
    private Collider currentObject;
	// Use this for initialization
	void Start () {
        canInteract = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKey(KeyCode.Q))
        {
            if (canInteract)
            {
                currentObject.gameObject.SendMessage("changeTime", false, SendMessageOptions.RequireReceiver);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.E))
        {
            if (canInteract)
            {
                currentObject.gameObject.SendMessage("changeTime", true, SendMessageOptions.RequireReceiver);
            }
        }
    }

    void OnGUI()
    {
        if (canInteract)
        {
            float w = 310.0f;
            float h = 300.0f;
            Rect rect = new Rect((Screen.width - w) / 2, (Screen.height - h) / 8, w, h);
            Rect rect2 = new Rect((Screen.width - 140) / 2, 0, 140, 100); 
            var style = new GUIStyle("label");
            style.fontSize = 35;
            GUI.color = Color.yellow;
            GUI.Label(rect, "<Q> Interact <E>", style);
            GUI.Label(rect2, currentObject.gameObject.GetComponent<Clock>().getTime().ToString());
           
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Clock"))
        {
            canInteract = true;
            currentObject = other;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Clock"))
        {
            canInteract = false;
            currentObject = null;
        }
    }

}
