using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public int direction = 1;
    public float speed = 1;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * direction * Time.deltaTime);
	}
}
