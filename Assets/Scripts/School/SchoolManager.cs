using UnityEngine;
using System.Collections;

public class SchoolManager : MonoBehaviour {

    public GameObject chalk;
    public Camera cam;
    public GameObject vid;
    //public MovieTexture
    private Animator camMove;
    public AnimationClip clip;
    // Use this for initialization
    void Start () {
        camMove = cam.GetComponent<Animator>();
        //vid.GetComponent<Renderer>().material.mainTexture;
	}
	
	// Update is called once per frame
	void Update () {
        if (chalk.GetComponent<Chalkboard>().onClick)
        {
            camMove.SetBool("Playing", true);
        }
	}
}
