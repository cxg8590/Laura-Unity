using UnityEngine;
using System.Collections;

public class Autoplay : MonoBehaviour {
    //use this script to make a videotexture autoplay

	// Use this for initialization
	void Start () {
        Renderer r = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)r.material.mainTexture;

        movie.Play();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
