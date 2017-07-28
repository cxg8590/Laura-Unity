using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class CameraLook : MonoBehaviour {

    public Transform target;
    public GameObject window;
    public GameObject window1;
    public GameObject window2;

    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public float yMinLimit = -20.0f;
    public float yMaxLimit = 80.0f;
    public float xMinLimit = -20.0f;
    public float xMaxLimit = 80.0f;

    public float distanceMin = 0.5f;
    public float distanceMax = 15f;
    public float smoothTime = 2f;

    public float rotationXAxis = 0.0f;
    public float rotationYAxis = 0.0f;
    public float velocityX = 0.0f;
    public float velocityY = 0.0f;

    public bool enable = true;
    public bool strafe;

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
            if (window.GetComponent<ClickBool>().click == false && Input.GetMouseButton(0))//(Input.GetMouseButton(0))
            {
                if (strafe)
                {
                    if (window1.GetComponent<ClickBool>().click == false && window2.GetComponent<ClickBool>().click == false)
                    {
                        velocityX += xSpeed * Input.GetAxis("Mouse X") * 0.02f;
                        velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
                    }
                }
                else
                {
                    velocityX += xSpeed * Input.GetAxis("Mouse X") * 0.02f;
                    velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
                }
            
            }

            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;

            if (enable)
            {
                xMinLimit = xMinLimit + transform.rotation.x;
                xMaxLimit = xMaxLimit + transform.rotation.x;
            }

            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            rotationYAxis = ClampAngle(rotationYAxis, xMinLimit, xMaxLimit);

            Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = this.GetComponent<CameraDragOrbit>().rotation * toRotation;

            /*distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
                distance -= hit.distance;
            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 postion = rotation * negDistance + target.position;*/

            if (window.GetComponent<ClickBool>().click == false && Input.GetMouseButton(0))//(Input.GetMouseButton(0))
            {
                transform.rotation = rotation;
            }
            //transform.position = postion;

            /*float centerX = Mathf.Lerp(rotation.x, this.GetComponent<CameraDragOrbit>().rotation.x, Time.deltaTime * smoothTime);
            float centerY = Mathf.Lerp(rotation.y, this.GetComponent<CameraDragOrbit>().rotation.y, Time.deltaTime * smoothTime);
            transform.rotation = Quaternion.Euler(centerX, centerY, 0); */
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
