using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MouseOrbitImproved2 : MonoBehaviour
{

    public Transform target;
    private float distance = 25.0f;
    private float xSpeed = 700.0f;
    private float ySpeed = 700.0f;
    Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);

    private float yMinLimit = -10000f;
    private float yMaxLimit = 10000f;

    private float distanceMin = 10f;
    private float distanceMax = 1250f;

    float x = 0.0f;
    float y = 0.0f;

    bool gamescreen = true;
    private Vector3 dragOrigin;
    private float dragSpeed = .1f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            dragOrigin = Input.mousePosition;

            return;
        }
        if (!Input.GetMouseButton(2) && (!Input.GetMouseButton(1) && Input.GetAxis("Mouse ScrollWheel") == 0)) return;
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

        transform.Translate(move, Space.World);

        if (Input.GetMouseButton(1) || Input.GetAxis("Mouse ScrollWheel") != 0)
        {

            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
            Camera cam = gameObject.GetComponent<Camera>();
            //            cam.nearClipPlane = -10;
            cam.orthographicSize = distance;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}