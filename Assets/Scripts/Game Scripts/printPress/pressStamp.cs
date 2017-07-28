using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(BoxCollider))]

public class pressStamp : MonoBehaviour {
    Vector3 screenPoint;
    Vector3 offSet;
    //float yPos;
    public bool movable = true;
    public bool correct = false;

    //pieces initial x and y
    public float initX;
    public float initY;

    public bool mouseDown = false;

    //cursor postision
    private Vector3 curPosition;
    private Vector3 curScreenPoint;

    //private string
    private string ansString;

    //blank spaces
    List<GameObject> blanks;

    public void OnPointerDrag()
    {
        mouseDown = true;
        if (movable)
        {
            curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            
            curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offSet;
            
            transform.position = curScreenPoint;

            /*for (int i = 0; i < empty.Length; i++)
            {
                //if (curPosition.x > 5 || curPosition.x < -5 || curPosition.y > 3 || curPosition.y < -3)
                if (curPosition.x > empty[i].transform.position.x - .7 && curPosition.x < empty[i].transform.position.x + .7 && curPosition.y > empty[i].transform.position.y - .7 && curPosition.y < empty[i].transform.position.y + .7 && !empty[i].GetComponent<emptyGrass>().occupied)
                {
                    placed = true;
                    transform.position = new Vector3(empty[i].transform.position.x, empty[i].transform.position.y, 48); //snap into position
                    if (choice != empty[i] && choice) choice.GetComponent<emptyGrass>().occupied = false;
                    choice = empty[i];
                    break;
                }
                else
                {
                    placed = false;
                }

            }*/
        }
        //Debug.Log("placed: " + placed);
    }

    /*public void onRelease()
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
            if((curScreenPoint.x >= b.transform.position.x && curScreenPoint.x <= b.transform.position.x + 70) && (curScreenPoint.y >= b.transform.position.y - 16 && curScreenPoint.y <= b.transform.position.y))
            {
                Debug.Log("inside blank");
                snap(b.transform.position.x, b.transform.position.y,b);
                return;
            }
        }
        Vector3 initPos = new Vector3(initX, initY, 0);
        transform.position = initPos;
        //snap(79, 124);
    }*/

    public void snap(float xPos, float yPos, GameObject bl)
    {
        GetComponent<RectTransform>().pivot = new Vector2(0,1);
        transform.position = new Vector3(xPos, yPos, transform.position.z);
        GetComponent<RectTransform>().sizeDelta = new Vector2(70,36);
        bl.GetComponent<pressBlank>().setPlaced(this.gameObject);
        //GetComponent<Text>().fontSize = 17;
        
        //GetComponent<RectTransform>().anchorMin = new Vector2(70, 16);
    }

    public void setBlanks(List<GameObject> bls)
    {
        blanks = bls;
        Debug.Log("setting blanks");
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
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
