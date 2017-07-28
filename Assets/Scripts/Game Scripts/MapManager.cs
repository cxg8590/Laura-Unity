using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapManager : MonoBehaviour {

    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;
    public GameObject piece5;
    public GameObject piece6;
    public GameObject piece7;
    public GameObject piece8;
    public GameObject piece9;

    public Image complete;
    //int fadeIn = 0;

    private int correct = 9;

    // Use this for initialization
    void Start () {
        complete.canvasRenderer.SetAlpha(0.0f);
    }
	
	// Update is called once per frame
	void Update () {
           int posCorrect = 0;
           if (piece1.transform.position == new Vector3(-2, 2))
           {
               posCorrect++;
           }
           if (piece2.transform.position == new Vector3(0, 2))
           {
               posCorrect++;
           }
           if (piece3.transform.position == new Vector3(2, 2))
           {
               posCorrect++;
           }
           if (piece4.transform.position == new Vector3(-2, 0))
           {
               posCorrect++;
           }
           if (piece5.transform.position == new Vector3(0, 0))
           {
               posCorrect++;
           }
           if (piece6.transform.position == new Vector3(2, 0))
           {
               posCorrect++;
           }
           if (piece7.transform.position == new Vector3(-2, -2))
           {
               posCorrect++;
           }
           if (piece8.transform.position == new Vector3(0, -2))
           {
               posCorrect++;
           }
           if (piece9.transform.position == new Vector3(2, -2))
           {
               posCorrect++;
           }
           if (posCorrect == correct)
           {
               victory();
           }
           Debug.Log("poscorrect" + posCorrect);
    }

    void victory()
    {
        /*piece1.GetComponent<ClickDrag>().movable = false;
        piece2.GetComponent<ClickDrag>().movable = false;
        piece3.GetComponent<ClickDrag>().movable = false;
        piece4.GetComponent<ClickDrag>().movable = false;
        piece5.GetComponent<ClickDrag>().movable = false;
        piece6.GetComponent<ClickDrag>().movable = false;
        piece7.GetComponent<ClickDrag>().movable = false;
        piece8.GetComponent<ClickDrag>().movable = false;
        piece9.GetComponent<ClickDrag>().movable = false;*/
        DestroyObject(piece1);
        DestroyObject(piece2);
        DestroyObject(piece3);
        DestroyObject(piece4);
        DestroyObject(piece5);
        DestroyObject(piece6);
        DestroyObject(piece7);
        DestroyObject(piece8);
        DestroyObject(piece9);
        complete.CrossFadeAlpha(1.0f, 1, false);
    }
}
