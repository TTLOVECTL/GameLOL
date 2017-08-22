using UnityEngine;
using System.Collections;

public class SmoothFollowCShap : MonoBehaviour
{
    public Camera mainCamera;

    public Transform target;

    public float cameraAngle = 60f;

    public float height = 5.0f;

    public float offsetAngele = 30f;
    Vector3 screenPos;
    private void Start()
    {
    }

    private void Update()
    {
    }

    void LateUpdate()
    {
        float xzValue = height / Mathf.Tan(cameraAngle * Mathf.Deg2Rad);

        float x = target.transform.position.x - xzValue * Mathf.Cos((90f - offsetAngele) * Mathf.Deg2Rad);

        float y = target.transform.position.y + height;

        float z = target.transform.position.z - xzValue * Mathf.Sin(offsetAngele * Mathf.Deg2Rad);

        transform.position = new Vector3(x, y, z);

        //transform.LookAt(target);
    }
}