using UnityEngine;
using System.Collections;

public class roadMove : MonoBehaviour
{
    public GameObject next;
    private Vector3 startPos;
    private float nextPos;

    private float currentZ;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        nextPos = next.transform.position.z;
        currentZ = startPos.z;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(startPos.x, startPos.y, currentZ);
        transform.position = newPos;
        if (currentZ <= nextPos)
        {
            currentZ = startPos.z;
        }
        else
        {
            currentZ-= (float).5;
        Debug.Log("CurrentZ: " + currentZ);
        }
    }
}