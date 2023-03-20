using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public Transform playerBody;

    private float XRotation = 0.0f;

    private FixedJoystick LookControl;

    // Start is called before the first frame update
    void Start()
    {
        LookControl = GameObject.Find("Look").GetComponent<FixedJoystick>();

        if (Application.platform != RuntimePlatform.Android || Application.platform != RuntimePlatform.IPhonePlayer)
        {
            LookControl.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity + LookControl.Horizontal;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity + LookControl.Vertical;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(XRotation, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
