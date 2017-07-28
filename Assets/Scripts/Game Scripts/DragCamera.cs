using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Camera))]
public class DragCamera : MonoBehaviour {

    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public bool dragging = true;
    public bool reverse = false;

    public float top = 10f;
    public float bottom = -20f;
    public float right = 20f;
    public float left = -10f;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float lt = Screen.width * 0.2f;
        float rt = Screen.width - (Screen.width * 0.2f);

        if (mousePosition.x < lt)
        {
            dragging = true;
        }
        else if (mousePosition.x > rt)
        {
            dragging = true;
        }
        dragging = true;
        if (dragging)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            if (reverse)
            {
                pos.x = pos.x * -1;
                pos.y *= -1;
            }
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);
            transform.Translate(move, Space.World);
            LockToBounds();
        }
	}

    private void LockToBounds()
    {
        //if (manager == null) return;
        Vector2 min = new Vector2(left, bottom);
        Vector2 max = new Vector2(right, top);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        transform.position = pos;
    }
}


