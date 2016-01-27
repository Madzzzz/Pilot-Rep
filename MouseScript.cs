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

        rotationX = 90;
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
        if (Time.timeScale == 1.0)
        {
            escapePressed = true;
            openMouse();
            Time.timeScale = 0.0f;
            GameObject.Find("PauseScreen").GetComponent<PauseMenu>().Pause();
        }
        else
        {
            escapePressed = false;
            lockMouse();
            GameObject.Find("PauseScreen").GetComponent<PauseMenu>().Unpause();
            Time.timeScale = 1.0f;
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
            {
                openMouse();
                Time.timeScale = 0.3f;
            }

            if (Input.GetMouseButtonUp(1))
            {
                lockMouse();
                Time.timeScale = 1.0f;
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
}
