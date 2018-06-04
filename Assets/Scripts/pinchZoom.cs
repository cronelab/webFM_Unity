using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinchZoom : MonoBehaviour {

    public float perspectiveZoomSpeed = .2f;
    public float orthoZoomSpeed = .2f;

    public Camera cam;
    public GameObject brain;
    public float rotSpeed = 1;
    public float screenRes1;// = 1920;
    public float screenRes2;// = 1080;
    public float screenRes1_1;// = screenRes1 / 4f;
    public float screenRes1_2;
    public float screenRes2_1;
    public float screenRes2_2;
    private void Start()
    {
        screenRes1 = 1920;
        screenRes2 = 1080;
        screenRes1_1 = screenRes1 / 4;
        screenRes1_2 = screenRes1 * (3 / 4);
        screenRes2_1 = screenRes2 / 4;
        screenRes2_2 = screenRes2 * (3 / 4);

        cam = this.GetComponent<Camera>();
        brain = GameObject.Find("PY18N002");
        print(Screen.width);
        print(Screen.height);

    }
    private void Update()
    {
        if (Screen.orientation.ToString() == "Portrait")
        {
            screenRes1 = Screen.height;
            screenRes2 = Screen.width;
        }
        else if (Screen.orientation.ToString() == "Landscape")
        {
            screenRes1 = Screen.height;
            screenRes2 = Screen.width;
        }
        screenRes1_1 = screenRes1 / 4f;
        screenRes1_2 = screenRes1 * (3 / 4f);
        screenRes2_1 = screenRes2 / 4f;
        screenRes2_2 = screenRes2 * (3 / 4f);

        if (Input.touchCount == 1)
        {
            Touch touchZero = Input.GetTouch(0);

            if (touchZero.position.x > screenRes2_2 && touchZero.position.y > screenRes1_1 && touchZero.position.y < screenRes1_2)
            {
                brain.transform.Rotate(-Vector3.forward, rotSpeed);
            }
            else if (touchZero.position.x < screenRes2_1 && touchZero.position.y > screenRes1_1 && touchZero.position.y < screenRes1_2)
            {
                brain.transform.Rotate(Vector3.forward, rotSpeed);
            }
            else if (touchZero.position.y > screenRes1_2 && touchZero.position.x < screenRes2_2 & touchZero.position.x > screenRes2_1)
            {
                brain.transform.Rotate(-Vector3.left, rotSpeed);
            }
            else if (touchZero.position.y < screenRes1_1 && touchZero.position.x < screenRes2_2 & touchZero.position.x > screenRes2_1)
            {
                brain.transform.Rotate(Vector3.left, rotSpeed);
            }
        }

        if (Input.touchCount == 2)
        {

           
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if (cam.orthographic)
            {
                cam.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
                cam.orthographicSize = Mathf.Max(cam.orthographicSize, .1f);
            }
            else
            {
                cam.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, .1f, 179.9f);
            }
            //Debug.Log(touchOne.position);

        }

    }

}
