using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TelescopeClick : MonoBehaviour {
    public Image unfound;
    public Sprite found;
    public bool correct = false;
    float alpha = 255;
    void OnMouseDown()
    {
        unfound.sprite = found;
        correct = true;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (correct)
        {
            if (GetComponent<SpriteRenderer>())
            {
                GetComponent<SpriteRenderer>().color = new Color(255 / 255, 255 / 255, 255 / 255, alpha / 255);
            }
            else
            {
                GetComponentInChildren<SpriteRenderer>().color = new Color(255 / 255, 255 / 255, 255 / 255, alpha / 255);
            }
            alpha -= 7;
        }
	}
}
