using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
//[RequireComponent(typeof(MeshRenderer))]

public class ClickDrag : MonoBehaviour {

    Vector3 screenPoint;
    Vector3 offSet;
    //float yPos;
    public bool movable = true;
    public bool track;
    public bool station = false;

    //what leads in and out if they are a station in = top and left; out = bottom and right
    public bool leadIn;
    public bool leadOut;

    //pieces initial x and y
    public float initX;
    public float initY;

    public GameObject[] empty;
    public DragDropManager Manager;
    public GameObject choice = null; //make private before we finish //what space the player puts the piece on

    public bool correct = false; //is it in the correct position 
    private bool placed = false;
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

            transform.position = curPosition;

            for (int i = 0; i < empty.Length; i++)
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
                
            }
        }
        //Debug.Log("placed: " + placed);
    }
    void OnMouseUp()
    {
        if (choice)
        {
            //if it has been been placed correctly placed
            if (placed)
            {
                //set the pccupant data of the empty space to this piece
                choice.GetComponent<emptyGrass>().occupied = true;
                choice.GetComponent<emptyGrass>().occupant = gameObject;
                //set track of the empty space to whatever this piece is
                if (track) choice.GetComponent<emptyGrass>().track = 1;
                else choice.GetComponent<emptyGrass>().track = 2;
                //check if correct
                if (Manager.lastCheck())
                {
                    Manager.nextLevel();
                }
            }
            else
            {
                transform.position = new Vector3(initX, initY, 48);
                choice.GetComponent<emptyGrass>().occupied = false;
            }
        }
        else
        {
            //put that thing back where it came from
            transform.position = new Vector3(initX, initY, 48);
        }
    }

    // Use this for initialization
    void Start () {
        //this piece's initial position
        initX = this.transform.position.x;
        initY = this.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        //if this piece has been chosen
        if (choice)
        {
            //but its back at its start position then unchoose it
            if (transform.position.x == initX && transform.position.y == initY)
            {
                choice.GetComponent<emptyGrass>().occupied = false;
                choice = null; 
                Debug.Log("choice should be empty");
            }
        }
	}
}
