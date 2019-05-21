using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterController : MonoBehaviour
{
    //vars
    public bool onGround;
    private Rigidbody rb;
    public float speed = 7.0f;
    public float jumpTakeOffSpeed = 5f;
    public bool keyFound;
    public int sprint = 12;
    public GameObject maincamera;
    public GameObject targetcamera;
    public GameObject player;
    public GameObject teleports;
    public AudioSource jump;

    void Start()
    {
        player = GameObject.Find("Player");
        maincamera.SetActive(true);
        targetcamera.SetActive(false);
        teleports.SetActive(false);
        onGround = true;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //movement
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        //springen
        if (onGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jump.Play();
                rb.velocity = new Vector3(0f, jumpTakeOffSpeed, 0f);
                onGround = false;
            }
        }

        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprint;
        } else
        {
            speed = 7;
        }
        //cheats
        if (Input.GetKey(KeyCode.G))
        {
            teleports.SetActive(true);
        }
        if (Input.GetKey(KeyCode.H))
        {
            teleports.SetActive(false);
        }
        //teleports
        if (Input.GetKeyDown("1"))
        {
            player.transform.position = new Vector3(0f, 5.4f, 65.66f);
        }
        if (Input.GetKeyDown("2"))
        {
            player.transform.position = new Vector3(0f, 9.02f, 152.2f);
        }
        if (Input.GetKeyDown("3"))
        {
            player.transform.position = new Vector3(0f, 18.74f, 117.62f);
        }
        if (Input.GetKeyDown("4"))
        {
            player.transform.position = new Vector3(0f, 18.74f, 85.14f);
        }
        if (Input.GetKeyDown("5"))
        {
            player.transform.position = new Vector3(0f, 27.25f, 53.4f);
        }
        if (Input.GetKeyDown("6"))
        {
            player.transform.position = new Vector3(0f, 41.38f, 27.62f);
        }

        //menu
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");
            
        }
        //target camera
        if (Input.GetKey(KeyCode.E))
        {
            maincamera.SetActive(false);
            targetcamera.SetActive(true);

        }
        else
        {
            maincamera.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
