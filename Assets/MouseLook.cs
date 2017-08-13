using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public enum RotationAxes {
        mouseXandY = 0,
        mouseX = 1,
        mouseY = 2
    }

    public RotationAxes axes = RotationAxes.mouseXandY;
    public float horizontalSpeed = 9.0f;
    public float verticalSpeed = 9.0f;

    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float _rotationX = 0;

    // Use this for initialization
    void Start () {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(axes == RotationAxes.mouseX)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X") * horizontalSpeed,0);
        }
        else if(axes == RotationAxes.mouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * verticalSpeed; //increment vertical angle based on mouse
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert); //clamp vertical angle between max and min limits

            float rotationY = transform.localEulerAngles.y; //keep same Y angle (no horizontal rotation)

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); //create new vector from rotaton values
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * verticalSpeed; //increment vertical angle based on mouse
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert); //clamp vertical angle between max and min limits

            float delta = Input.GetAxis("Mouse X") * horizontalSpeed;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); //create new vector from rotaton values
        }
	}
}
