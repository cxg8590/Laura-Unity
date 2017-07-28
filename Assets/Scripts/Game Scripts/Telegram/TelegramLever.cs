using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TelegramLever : MonoBehaviour {

    public Button down;
    public Image lever;
    public Sprite upImage;
    public Sprite downImage;
    public GameObject lightbulb; //corrosponding light
    // Use this for initialization
    void Start () {
        lever.sprite = upImage;
	}
	
	// Update is called once per frame
	void Update () {
	    if(down == true)
        {
            lever.sprite = downImage;
            //lightbulb.GetComponent<Image>().sou
        }
        else
        {
            lever.sprite = upImage;
        }
	}
}
