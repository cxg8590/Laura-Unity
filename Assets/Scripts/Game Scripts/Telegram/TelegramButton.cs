using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TelegramButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image lever;
    public Image lightBulb;
    public Sprite onLight;
    public Sprite offLight;
    public Sprite upImage;
    public Sprite downImage;
    public GameObject manager;
    private bool pressed;
    private bool playing;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        lightBulb.sprite = onLight;
        lever.sprite = upImage;
        Debug.Log(this.gameObject.name + " Was down.");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        lightBulb.sprite = offLight;
        lever.sprite = downImage;
        Debug.Log(this.gameObject.name + " Was up.");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
