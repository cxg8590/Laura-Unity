using UnityEngine;
using System.Collections;

public class CamerControlls : MonoBehaviour {

    public CameraMove MyCameraMoverLeft;
    public CameraMove MyCameraMoverRight;
    int perspective = 0;
    public float speed = 2f;

    // Use this for initialization
    void Start()
    {
        CameraMove[] CameraMoves = this.GetComponents<CameraMove>();
        foreach(CameraMove cm in CameraMoves)
        {
            if (cm.id == 1) { MyCameraMoverRight = cm; }
            else if(cm.id == 2) { MyCameraMoverLeft = cm; }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //this.MyCameraMoverRight.currentIndex = this.MyCameraMoverLeft.currentIndex;
        perspective = this.MyCameraMoverRight.currentIndex;
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (this.MyCameraMoverRight.moving == false)
            {
                if (perspective < MyCameraMoverRight.Transforms.Length - 1) perspective++;
                else { perspective = 0; }
                StartCoroutine(this.MyCameraMoverRight.moveUp(perspective, speed, 2));
                this.MyCameraMoverLeft.currentIndex = this.MyCameraMoverRight.currentIndex;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (this.MyCameraMoverLeft.moving == false)
            {
                if (perspective > 0) perspective--;
                else { perspective = MyCameraMoverLeft.Transforms.Length - 1; }
                StartCoroutine(this.MyCameraMoverLeft.moveDown(perspective, speed, 2));
                this.MyCameraMoverRight.currentIndex = this.MyCameraMoverLeft.currentIndex;
            }
        }
    }
}
