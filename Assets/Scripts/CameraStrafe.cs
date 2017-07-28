using UnityEngine;
using System.Collections;

public class CameraStrafe : MonoBehaviour {

    public GameObject window1;
    public GameObject window2;
    public Transform center;

    private int dist = 50;//how far away from center you are

    private Vector3 start;
    private Vector3 end;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (window1.GetComponent<ClickBool>().click)
        {
            //strafe left
            start = center.position;
            end = Vector3.left * dist;
            this.transform.position = Vector3.Lerp(start, end, 50.0f);
        }
        else if (window2.GetComponent<ClickBool>().click)
        {
            //strafe right
            start = center.position;
            end = Vector3.right * dist;
            this.transform.position = Vector3.Lerp(start, end, 1.0f);
        }
        else
        {
            //lerp back to center
           this.transform.position = Vector3.Lerp(end, start, 1.0f);
        }

    }
}
