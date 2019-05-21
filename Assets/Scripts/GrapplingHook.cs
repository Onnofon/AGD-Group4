using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrapplingHook : MonoBehaviour
{
    public Camera cam;
    public RaycastHit hit;

    public LayerMask cullingmask;
    public int Maxdistance;

    public bool IsFlying;
    public Vector3 loc;

    public float speed = 10;
    public Transform hand;

    public Transform CC;
    public LineRenderer LR;

    public float shotDelay = 0.3333f;
    private float timeStamp;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
                Findspot();

            if (IsFlying)
                Flying();

            if (Input.GetKey(KeyCode.Space) && IsFlying)
            {
                IsFlying = false;
                LR.enabled = false;
            }
        
    }


    public void Findspot()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Maxdistance, cullingmask))  //&& Grapple == true)
        {
            IsFlying = true;
            loc = hit.point;
            LR.enabled = true;
            LR.SetPosition(1, loc);

        }
        else
        {
           
            LR.enabled = false;
            LR.SetPosition(1, loc);
        }
    }

    public void Flying()
    {
        transform.position = Vector3.Lerp(transform.position, loc, speed * Time.deltaTime / Vector3.Distance(transform.position, loc));
        LR.SetPosition(0, hand.position);

        if (Vector3.Distance(transform.position, loc) < 0.5f)
        {
            IsFlying = false;
            LR.enabled = false;
        }

    }
}
