using UnityEngine;
using System.Collections;

public class SmoothFollowCShap : MonoBehaviour
{


    /*
    This camera smoothes out rotation around the y-axis and height.
    Horizontal Distance to the target is always fixed.
          
    There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.
          
    For every of those smoothed values we calculate the wanted value and the current value.
    Then we smooth it using the Lerp function.
    Then we apply the smoothed values to the transform's position.
    */
    public Camera mainCamera;

    public Transform target;

    public float cameraAngle = 60f;

    public float height = 5.0f;

    public float offsetAngele = 30f;

    private void Start()
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);
        Vector3 screenCenter = new Vector3(Screen.width/2,Screen.height/2,screenPos.z);
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(screenCenter);
        target.position = worldPos;
        //transform.position -= new Vector3(target.position.x-worldPos.x,target.position.y-worldPos.y,0);
    }

    private void Update()
    {
       
    }

    void LateUpdate()
    {
        float xzValue = height / Mathf.Tan(cameraAngle*Mathf.Deg2Rad);

        float x = target.transform.position.x - xzValue * Mathf.Cos((90f-offsetAngele) * Mathf.Deg2Rad);

        float y = target.transform.position.y + height;

        float z = target.transform.position.z - xzValue * Mathf.Sin(offsetAngele * Mathf.Deg2Rad);

        transform.position = new Vector3(x,y,z); 
    }
}