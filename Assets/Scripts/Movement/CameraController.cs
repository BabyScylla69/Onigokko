using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPos;
    public Camera mainCamera;

	public bool canMove { get; private set; } = false;

	[SerializeField, Range(1, 10)] private float lookSpeedX;
	[SerializeField, Range(1, 10)] private float lookSpeedY;

	[SerializeField, Range(1, 180)] private float upperLookLimit;
	[SerializeField, Range(1, 180)] private float lowerLookLimit;

	private float rotationX = 0;

	private PlayerController _pc;

    private void Awake()
    {
		_pc = GetComponent<PlayerController>();
    }

    private void Update()
    {
		mainCamera.transform.position = cameraPos.position;
		mainCamera.transform.rotation = cameraPos.rotation;

		if (canMove)
        {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;

			MouseLook(); 
		}
		else
		{
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
		}
    }

	public void SetMove(bool set)
    {
		canMove = set;
    }

	private void MouseLook()
    {
		rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
		rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
		cameraPos.localRotation = Quaternion.Euler(rotationX, 0, 0);
		_pc.body.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
		_pc.head.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
	}
}
