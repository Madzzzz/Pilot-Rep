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
    public bool escapePressed = false;
    public bool alive;

    void Start () {

        player = transform.root;
        lockMouse();
        alive = true;
        Time.timeScale = 1.0f;
    }	

    void lockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        actualMouseSpeed = mouseSpeed;
    }

    void openMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        actualMouseSpeed = 0;
    }

    public void PauseUnpause()
    {
            escapePressed = !escapePressed;

            if (Time.timeScale == 1.0)
            {
                openMouse();
                Time.timeScale = 0.0f;
                GameObject.Find("PauseScreen").GetComponent<PauseMenu>().Pause();
            }
            else
            {
                lockMouse();
                Time.timeScale = 1.0f;
                GameObject.Find("PauseScreen").GetComponent<PauseMenu>().Unpause();
            }
        
    }

    public void DeathScreen()
    {
        openMouse();
        escapePressed = true;
        Time.timeScale = 0.0f;
    }
	
	void Update () {

        if (Input.GetButtonDown(("Escape")))
        {
            PauseUnpause();
        }

        if (escapePressed == false)
        {

            if (Input.GetMouseButton(1))
                openMouse();

            if (Input.GetMouseButtonUp(1))
                lockMouse();

            rotationX += Input.GetAxis("Mouse X") * actualMouseSpeed;
            rotationY -= Input.GetAxis("Mouse Y") * actualMouseSpeed;

            rotationY = Mathf.Clamp(rotationY, -60, 60);

            targetRotationX = Mathf.SmoothDamp(targetRotationX, rotationX, ref xRotV, dampSpeed);
            targetRotationY = Mathf.SmoothDamp(targetRotationY, rotationY, ref yRotV, dampSpeed);

            transform.localEulerAngles = new Vector3(targetRotationY, 0, 0);
            player.localEulerAngles = new Vector3(0, targetRotationX, 0);
        }
    }
}
