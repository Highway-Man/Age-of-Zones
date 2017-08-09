using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScript : MonoBehaviour {


    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
    float forward, sideways;
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up"))
            forward = 1;
        else if (Input.GetKey("down"))
            forward = -1;
        else
            forward = 0;

        if (Input.GetKey("left"))
            sideways = -1;
        else if (Input.GetKey("right"))
            sideways = 1;
        else
            sideways = 0;
	}

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(1*sideways, 0, 1*forward));
    }
}
