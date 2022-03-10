using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView1stPerson : MonoBehaviour
{
    //UI Objects
    public GameObject fishingLabel;

    //Player variables
    public float moveSpeed;
    public float mouseSensitivity;
    private Camera mainCam;

    private float mouseX;
    private float mouseY;

    //Script variables
    private RaycastHit hit;

    void Start()
    {
        mainCam = Camera.main;        
        mainCam.transform.parent = gameObject.transform;
        mainCam.transform.localPosition = new Vector3(0, 0, 0);
        mainCam.transform.rotation = Quaternion.Euler(0,0,0);

        moveSpeed = 5f;
        mouseSensitivity = 5f;
        mouseX = 0f;
        mouseY = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        mouseY += Input.GetAxis("Mouse X") * mouseSensitivity;
        gameObject.transform.rotation = Quaternion.Euler(0, mouseY, 0);
        mainCam.transform.rotation = Quaternion.Euler(mouseX, mouseY, 0);
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            gameObject.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }


        // if raycast hits, it checks if it hit an object with the tag Player
        if (Physics.Raycast(mainCam.transform.position, transform.forward, out hit, 30) &&
                    hit.collider.gameObject.CompareTag("Fish"))
        {
            fishingLabel.SetActive(true);
            if (Input.GetKey("f"))
            {
                Debug.Log("Started fishing");
            }
        }
        else
        {
            fishingLabel.SetActive(false);
        }
    }
}
