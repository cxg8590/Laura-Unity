using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    public Transform[] Transforms;
    public int id;
    public int currentIndex;
    public bool moving;

    void Awake()
    {
        SnapToPosition(0);
    }

    public void SnapToPosition(int index)
    {
        this.currentIndex = index;
        this.transform.position = this.Transforms[index].position;
        this.transform.rotation = this.Transforms[index].rotation;
    }

    public IEnumerator moveUp(int index, float time, int inter)
    {
        for(int i = 0; i < inter; i++)
        {
            if (index + i < Transforms.Length)
            {
                yield return StartCoroutine(this.MoveToPosition(index + i, time));
            }
            else
            {
                yield return StartCoroutine(this.MoveToPosition(0, time));
            }
        }
    }

    public IEnumerator moveDown(int index, float time, int inter)
    {
        for (int i = 0; i < inter; i++)
        {
            if (index - i > 0)
            {
                yield return StartCoroutine(this.MoveToPosition(index - i, time));
            }
            else
            {
                yield return StartCoroutine(this.MoveToPosition(0, time));
            }
        }
    }

    public IEnumerator MoveToPosition(int index, float time)
    {
        moving = true;
        if (this.currentIndex == index)
        {
            yield break;
        }
        Vector3 startPosition = this.transform.position;
        Quaternion startRotation = this.transform.rotation;
        Vector3 endPosition = this.Transforms[index].position;
        Quaternion endRotation = this.Transforms[index].rotation;

        this.currentIndex = index;
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            float a = elapsedTime / time;
            this.transform.position = Vector3.Lerp(startPosition, endPosition, a);
            this.transform.rotation = Quaternion.Slerp(startRotation, endRotation, a);

            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
        }
        moving = false;
    }
}
