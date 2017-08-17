using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaintManager : MonoBehaviour {

    private int currentColor = 7; //0=white, 1=black, 2=brown, 3=yellow, 4=green, 5=red 
    public GameObject[] paintAreas; //all areas on painting
    public GameObject background;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (check())
        {
            Debug.Log("You Win!");
            background.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
	}

    public void setColor(int col)
    {
        currentColor = col;
    }
    public int getColor()
    {
        return currentColor;
    }

    public bool check()
    {
        bool win = true;

        foreach (GameObject area in paintAreas)
        {
            if (!area.GetComponent<PaintArea>().getFilled())
            {
                win = false;
            }
        }

        return win;
    }
}
