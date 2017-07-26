using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour {

    private Rigidbody slave;
    public Rigidbody master;
    private HingeJoint hj;
    private Vector3 axis;


	// Use this for initialization
	void Start () {
        slave = GetComponent<Rigidbody>();
        hj = GetComponent<HingeJoint>();
        axis = hj.axis;
        axis *= -2;
        axis += new Vector3(1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        slave.transform.localEulerAngles = Vector3.Scale(master.transform.localEulerAngles, axis);

    }
}
