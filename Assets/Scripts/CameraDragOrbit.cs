using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class CameraDragOrbit : MonoBehaviour
{

    public Transform target;
    public GameObject window;

    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public float yMinLimit = -20.0f;
    public float yMaxLimit = 80.0f;

    public float distanceMin = 0.5f;
    public float distanceMax = 15f;
    public float smoothTime = 2f;

    public float rotationXAxis = 0.0f;
    public float rotationYAxis = 0.0f;
    public float velocityX = 0.0f;
    public float velocityY = 0.0f;

    public bool enable = true;

    public Quaternion rotation;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationXAxis = angles.x;
        rotationYAxis = angles.y;
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target)
        {
            if (window.GetComponent<ClickBool>().click)//(Input.GetMouseButton(0))
            {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.0002f;
                velocityY -= ySpeed * Input.GetAxis("Mouse Y") * 0.0002f;
            }

            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);

            Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            rotation = toRotation;

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            /*RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
                distance -= hit.distance;
            }*/
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 postion = rotation * negDistance + target.position;

            if (enable)
            {
                transform.rotation = rotation;
                transform.position = postion;
            }
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        }

    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;

        return Mathf.Clamp(angle, min, max);
    }
}
