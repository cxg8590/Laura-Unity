using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraDragDrop : MonoBehaviour {

    public float horizontalResolution = 1920;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = horizontalResolution / currentAspect / 200;
    }
}
