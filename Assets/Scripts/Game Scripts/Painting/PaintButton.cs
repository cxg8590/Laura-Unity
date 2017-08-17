using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PaintButton : MonoBehaviour {

    public GameObject manager;
    public int colorNum;

	// Use this for initialization
	void Start () {
        //GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
        //Debug.Log(name + " alpha: "+ GetComponent<Image>().color.a);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Click()
    {
        Debug.Log("Clicked: " + name);
        manager.GetComponent<PaintManager>().setColor(colorNum);
    }
}
