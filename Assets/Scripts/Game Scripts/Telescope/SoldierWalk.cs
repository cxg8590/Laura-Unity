using UnityEngine;
using System.Collections;

public class SoldierWalk : MonoBehaviour {

    private Animator anim;
    bool right = false;

    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
       anim.SetBool("Right", right);
    }

    void changeDirection()
    {
        if (right) { right = false; }
        else { right = true; }
    }
}
