using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject exitButton;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook = -85f;
    public float maxXLook = 85f;
    private float camCurXRot;
    public float lookSensitivity = 0.1f;

    [HideInInspector]
    public bool canLook = true;
    private Vector2 mouseDelta;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    private void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnSetting(InputAction.CallbackContext context)
    {
        canLook = false;
        Cursor.lockState = CursorLockMode.Confined;
        settingPanel.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void OnExitSetting()
    {
        canLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        settingPanel.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }
}
