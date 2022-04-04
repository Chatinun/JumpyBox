using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float zoomSpeed = 0.005f;
    public Vector3 offset;

    public bool zoomActive;

    public static CameraController instance;

    private void Awake()
    {
        instance = this;
        cam = Camera.main;

        
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Lv6")
        {
            CutsceneStart1();
        }
    }

    void Update()
    {

    }

    void CutsceneStart1()
    {
        Debug.Log("yes1");
        PlayerController.instance.disableInput = true;
        Invoke(nameof(CutsceneStart2), 2f);
        Debug.Log("yes2");
    }

    void CutsceneStart2()
    {
        offset = new Vector3(-6, offset.y, offset.z);
        SawMoving.instance.startTrigger = true;
        Invoke(nameof(CutsceneStart3), 2f);
    }
    void CutsceneStart3()
    {
        offset = new Vector3(2, offset.y, offset.z);
        PlayerController.instance.disableInput = false;

    }

    void FixedUpdate()
    {
        if (!zoomActive)
        {
            Vector3 dessiredPosition = new Vector3(target.position.x, 0, target.position.z) + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, dessiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    void LateUpdate()
    {
        if (zoomActive)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 2, 0.005f);
            //transform.position = new Vector3(target.position.x, target.position.y + 1f, -10);
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y + 1f, -10), zoomSpeed);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, zoomSpeed);
        }
    }

}
