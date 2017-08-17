using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressLever : MonoBehaviour {

    public GameObject lever;
    private float length;
    private float buttonHeight; //current height of the button
    private Vector3 startPos; //starting position of button
    private bool moving = false; //is the button moving
    private bool returning = false; //is it returning to position

	// Use this for initialization
	void Start () {
        length = lever.GetComponent<RectTransform>().rect.height - GetComponent<RectTransform>().rect.height;//lever area height
        startPos = gameObject.transform.position;
        buttonHeight = startPos.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            if (gameObject.transform.position.y < (startPos.y - length)) returning = true;
            if (!returning)
            {
                Debug.Log("going down");
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, buttonHeight, gameObject.transform.position.z);
                buttonHeight -= 10;
            }
            else
            {
                Debug.Log("going up");
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, buttonHeight, gameObject.transform.position.z);
                buttonHeight += 10;
                if(gameObject.transform.position.y >= startPos.y)
                {
                    gameObject.transform.position = startPos;
                    returning = false;
                    moving = false;
                }
            }
        }
    }

    public void onPress()
    {
        Debug.Log("length: " + length);
        moving = true;
    }
}
