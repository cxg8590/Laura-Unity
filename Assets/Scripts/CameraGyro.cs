using UnityEngine;
using System.Collections;

public class CameraGyro : MonoBehaviour
{

    //public CamManager target;
    private bool gyroBool;
    private Gyroscope gyro;
    private Quaternion rotFix;

    private GameObject camParent;
    public ScreenOrientation currentOrientation;

    private bool initialized = false;
    private Vector3 inititialRotation = new Vector3(90, 180, 90);



    private void init()
    {
        if (!initialized)
        {
            Transform originalParent = transform; // check if this transform has a parent
            camParent = new GameObject("camParent"); // make a new parent
            camParent.transform.position = transform.position; // move the new parent to this transform position
            transform.parent = camParent.transform; // make this transform a child of the new parent
            camParent.transform.parent = originalParent; // make the new parent a child of the original parent
            //camParent.transform.position = new Vector3(camParent.transform.position.x, -72, camParent.transform.position.z);
            camParent.transform.position = new Vector3(camParent.transform.position.x, camParent.transform.position.y, camParent.transform.position.z);

            gyroBool = SystemInfo.supportsGyroscope;

            if (gyroBool)
            {

                gyro = Input.gyro;
                gyro.enabled = true;

            }
            else
            {
                print("NO GYRO");
            }

            initialized = true;
        }
    }

    private void updateScreenOrientation()
    {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            camParent.transform.eulerAngles = inititialRotation;
            rotFix = new Quaternion(0f, 0f, 0.7071f, 0.7071f);
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            camParent.transform.eulerAngles = inititialRotation;
            rotFix = new Quaternion(0f, 0f, -0.7071f, 0.7071f);
        }
        else if (Screen.orientation == ScreenOrientation.Portrait)
        {
            camParent.transform.eulerAngles = inititialRotation;
            rotFix = new Quaternion(0f, 0f, 1f, 0f);
        }
        if (Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            camParent.transform.eulerAngles = inititialRotation;
            rotFix = new Quaternion(0f, 0f, 0f, 1f);
        }


    }

    void Update()
    {
        init();
        if (currentOrientation != Screen.orientation)
        {
            currentOrientation = Screen.orientation;
            updateScreenOrientation();
        }

        if (gyroBool)
        {
            //Quaternion camRot = gyro.attitude * rotFix;
            Quaternion camRot = new Quaternion(gyro.attitude.x, gyro.attitude.y, -gyro.attitude.z, -gyro.attitude.w);
            transform.localRotation = camRot;
            //target.SetRotation(transform.rotation);
        }
        else
        {
            //transform.rotation(Quaternion.identity);
            transform.rotation = Quaternion.identity;
        }

    }

    public bool LookingAtObject(Transform obj)
    {
        Vector3 direction = obj.position - this.transform.position;

        float ang = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float angleCurrent = this.transform.eulerAngles.z;
        float checkAngle = 0;

        if(angleCurrent > 0 && angleCurrent <=90)
        {
            checkAngle = ang - 90;
        }
        if (angleCurrent > 90 && angleCurrent <= 360)
        {
            checkAngle = ang +270;
        }

        if(angleCurrent <= checkAngle + 15.5f && angleCurrent >= checkAngle - 15.5f)
        {
            Debug.Log("true");
            return true;
        }
        else
        {
            Debug.Log("false");
            return false;
        }
    }
}