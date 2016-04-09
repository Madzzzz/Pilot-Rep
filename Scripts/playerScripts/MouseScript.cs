using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {

    //Mus-skript, styrer situasjoner når musen skal brukes: bevegelse, døds og pausemeny

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
    public bool powerMenu = false;

    void Start ()
    {
        player = transform.root;
        lockMouse();
        alive = true;
        Time.timeScale = 1.0f;
    }	

    public void loadRot(float rotX, float rotY)
    {
        rotationX = rotX;
        rotationY = rotY;
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
            GameObject.Find("SpaceWalrusControll").GetComponent<PlayMovieTexture>().PauseSpaceWalrus();
            GameObject.Find("OldGameMusic").GetComponent<SoundControll>().StopSound();
            GameObject.Find("OldGameMusic").GetComponent<StayAlive>().show();
            GameObject.Find("Basic_cube").GetComponent<SoundCollision>().Pause();
        }
        else
        {
            escapePressed = false;
            lockMouse();
            GameObject.Find("PauseScreen").GetComponent<PauseMenu>().Unpause();
            GameObject.Find("SpaceWalrusControll").GetComponent<PlayMovieTexture>().UnPauseSpaceWalrus();
            GameObject.Find("OldGameMusic").GetComponent<SoundControll>().StartSound();
            GameObject.Find("OldGameMusic").GetComponent<StayAlive>().noShow();
            GameObject.Find("Basic_cube").GetComponent<SoundCollision>().UnPause();
            Time.timeScale = 1.0f;
        }
    }
    

    public void DeathScreen()
    {
        openMouse();
        escapePressed = true;
        alive = false;
        Time.timeScale = 0.0f;
        GameObject.Find("SpaceWalrusControll").GetComponent<PlayMovieTexture>().PauseSpaceWalrus();
        GameObject.Find("OldGameMusic").GetComponent<SoundControll>().StopSound();
        GameObject.Find("Basic_cube").GetComponent<SoundCollision>().Pause();
    }
	
	void Update () {

        if (Input.GetButtonDown(("Escape")))
        {
            if(powerMenu == false && alive == true)
                PauseUnpause();
        }

        if (escapePressed == false)
        {

            if (Input.GetMouseButton(1))
            {
                openMouse();
                Time.timeScale = 0.3f;
                powerMenu = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                lockMouse();
                Time.timeScale = 1.0f;
                powerMenu = false;
            }

            rotationX += Input.GetAxis("Mouse X") * actualMouseSpeed;
            rotationY -= Input.GetAxis("Mouse Y") * actualMouseSpeed;

            rotationY = Mathf.Clamp(rotationY, -90, 90);

            targetRotationX = Mathf.SmoothDamp(targetRotationX, rotationX, ref xRotV, dampSpeed);
            targetRotationY = Mathf.SmoothDamp(targetRotationY, rotationY, ref yRotV, dampSpeed);

            transform.localEulerAngles = new Vector3(targetRotationY, 0, 0);
            player.localEulerAngles = new Vector3(0, targetRotationX, 0);
        }
    }
}
