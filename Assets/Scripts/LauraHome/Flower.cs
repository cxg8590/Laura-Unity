using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        Debug.Log("Clicked");
        anim.SetBool("clicked", true);
    }
    void destroy()
    {
        DestroyObject(this.gameObject);
    }
}
