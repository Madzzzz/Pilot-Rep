using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {

    Transform player;

    [HideInInspector]
    public float rotationX;
    [HideInInspector]
    public float rotationY;
    [HideInInspector]
    public float targetRotationX;
    [HideInInspector]
    public float targetRotationY;

    private float xRotV;
    private float yRotV;

    public float dampSpeed;
    public float mouseSpeed;
    private float actualMouseSpeed;

    void Start () {

        player = transform.root;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        actualMouseSpeed = mouseSpeed;
    }	
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (Cursor.visible == false)
            {
                Cursor.lockState = CursorLockMode.None;
                actualMouseSpeed = 0;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                actualMouseSpeed = mouseSpeed;
            }

            Cursor.visible = !Cursor.visible;
        }

        if (Input.GetMouseButton(1))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            actualMouseSpeed = 0;

        }

        if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            actualMouseSpeed = mouseSpeed;
        }

        rotationX += Input.GetAxis("Mouse X") * actualMouseSpeed;
        rotationY -= Input.GetAxis("Mouse Y") * actualMouseSpeed;

        rotationY = Mathf.Clamp(rotationY, -60, 60);

        targetRotationX = Mathf.SmoothDamp(targetRotationX, rotationX, ref xRotV, dampSpeed);
        targetRotationY = Mathf.SmoothDamp(targetRotationY, rotationY, ref yRotV, dampSpeed);

        transform.localEulerAngles = new Vector3(targetRotationY, 0, 0);
        player.localEulerAngles = new Vector3(0, targetRotationX, 0);

    }
}
