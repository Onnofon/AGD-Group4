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
    public GameObject player;
    public AudioSource jump;

    void Start()
    {
        player = GameObject.Find("Player");
        maincamera.SetActive(true);
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

        //jump
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

        //menu
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            //SceneManager.LoadScene("Menu");
            
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
