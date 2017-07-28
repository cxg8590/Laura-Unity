using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(BoxCollider))]

public class pressStamp2 : MonoBehaviour {
    Vector3 screenPoint;
    Vector3 offSet;
    //float yPos;
    public bool movable = true;
    public bool correct = false;

    //pieces initial x and y
    public float initX;
    public float initY;
    public Vector2 initSize;

    public bool mouseDown = false;

    //cursor postision
    private Vector3 curPosition;
    private Vector3 curScreenPoint;

    //private string
    private string ansString;

    //blank spaces
    public List<GameObject> blanks;

    public int stampNum; //what blank does it corrospond to

    private GameObject currentBlank; //what the current blank it's on is

    public Sprite upSprite;
    public Sprite downSprite;

    public void OnPointerDrag()
    {
        Debug.Log("moving : " + transform.name);
        mouseDown = true;
        if (movable)
        {
            curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            
            curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offSet;
            
            transform.position = curScreenPoint;

            for (int i = 0; i < blanks.Count; i++)
            {
                //if (curPosition.x > 5 || curPosition.x < -5 || curPosition.y > 3 || curPosition.y < -3)
                if (curPosition.x > blanks[i].transform.position.x - .7 && curPosition.x < blanks[i].transform.position.x + .7 && curPosition.y > blanks[i].transform.position.y - .7 && curPosition.y < blanks[i].transform.position.y + .7 && !blanks[i].GetComponent<pressBlank2>().getOccupied())
                {
                    
                    transform.position = new Vector3(blanks[i].transform.position.x, blanks[i].transform.position.y, 48); //snap into position
                }

            }
        }
        //Debug.Log("placed: " + placed);
    }

    public void onRelease()
    {
        mouseDown = false;
        if(blanks == null)
        {
            Debug.Log("no blanks");
            return;
        }
        foreach(GameObject b in blanks)
        {
            Debug.Log("click drag: X: " + curScreenPoint.x + " Y: " + curScreenPoint.y);
            Debug.Log("Blank1 X: " +blanks[0].transform.position.x+ "Blank1 Y: " + blanks[0].transform.position.y);
            float blankHalfX = b.GetComponent<RectTransform>().sizeDelta.x / 2;
            float blankHalfY = b.GetComponent<RectTransform>().sizeDelta.y / 2;
            if ((curScreenPoint.x >= b.transform.position.x- blankHalfX && curScreenPoint.x <= b.transform.position.x + blankHalfX) && (curScreenPoint.y >= b.transform.position.y - blankHalfY && curScreenPoint.y <= b.transform.position.y + blankHalfY) && !b.GetComponent<pressBlank2>().getOccupied())
            {
                Debug.Log("Blank1 X: " + (blanks[0].transform.position.x - blankHalfX) + "Blank1 Y: " + (blanks[0].transform.position.y - blankHalfY));
                Debug.Log("inside blank");
                snap(b.transform.position.x, b.transform.position.y,b);
                return;
            }
        }
        snapBack();
        currentBlank.GetComponent<pressBlank2>().setStampnum(0);
        currentBlank.GetComponent<pressBlank2>().setOccupied(false);
        currentBlank = null;
    }

    public void snap(float xPos, float yPos, GameObject bl)
    {
        currentBlank = bl;
        GetComponent<Image>().sprite = downSprite;
        GetComponent<RectTransform>().pivot = new Vector2(.5f, .5f);
        transform.position = new Vector3(xPos, yPos, transform.position.z);
        GetComponent<RectTransform>().sizeDelta = new Vector2(bl.GetComponent<RectTransform>().sizeDelta.x + 7.7f, bl.GetComponent<RectTransform>().sizeDelta.y + 5.1f);
        bl.GetComponent<pressBlank2>().setOccupied(true);
        bl.GetComponent<pressBlank2>().setStampnum(stampNum);
        transform.GetChild(0).GetComponent<Text>().fontSize = 20;
        bl.GetComponent<pressBlank2>().setOccupied(true);
        //GetComponent<Text>().fontSize = 17;

        //GetComponent<RectTransform>().anchorMin = new Vector2(70, 16);
    }
    public void snapBack()
    {
        Vector3 initPos = new Vector3(initX, initY, 0);
        GetComponent<RectTransform>().sizeDelta = initSize;
        transform.position = initPos;
        GetComponent<Image>().sprite = upSprite;
        transform.GetChild(0).GetComponent<Text>().fontSize = 31;
    }

    public void setBlanks(List<GameObject> bls)
    {
        blanks = bls;
    }

    public string getWord()
    {
        return ansString;
    }
    public void setWord(string st)
    {
        ansString = st;
    }

    // Use this for initialization
    void Start () {
        //this piece's initial position
        initX = this.transform.position.x;
        initY = this.transform.position.y;
        initSize = GetComponent<RectTransform>().sizeDelta;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
