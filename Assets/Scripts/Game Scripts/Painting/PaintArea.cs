using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PaintArea : MonoBehaviour {

	// Use this for initialization
    private int currentColor;
    private bool filled = false;
    public int color;
    public GameObject manager;
    void Start () {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;

    }
	
	// Update is called once per frame
	void Update () {
        if (manager != null)
        {
            currentColor = manager.GetComponent<PaintManager>().getColor();
        }
	}

    public void onClick()
    {
        Debug.Log("clicked color: " + currentColor);
        if (currentColor == color)
        {
            GetComponent<Image>().material = null;
            filled = true;
            //manager.GetComponent<PaintManager>().check();
        }
    }

    public bool getFilled()
    {
        return filled;
    }
}
