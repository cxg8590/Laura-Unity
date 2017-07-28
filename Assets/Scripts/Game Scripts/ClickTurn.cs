using UnityEngine;
using System.Collections;

public class ClickTurn : MonoBehaviour {

    Vector3 screenPoint;
    Vector3 offSet;
    public bool movable = true;
    Quaternion fromRot;
    Quaternion toRot;

    void OnMouseDown()
    {
        if (movable)
        {
            Vector3 scanPos = gameObject.transform.position;
            screenPoint = Camera.main.WorldToScreenPoint(scanPos);

            offSet = scanPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        }
    }

    void OnMouseDrag()
    {
        if (movable)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offSet;

            //rotate only on x

            /*if (curPosition.x > 5 || curPosition.x < -5 || curPosition.y > 3 || curPosition.y < -3)
            {
                transform.position = curPosition;
            }
            else
            {
                transform.position = new Vector3(Mathf.Round(curPosition.x), Mathf.Round(curPosition.y));
            }*/
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
