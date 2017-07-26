using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {

    public float gearRatio;
    public int motorPort;

    private Rigidbody rb;
    private HingeJoint hj;

    private Vector3 axis, localAngularVelocity, scaledTorque, torque;
    private float maxTorque, maxRpm, maxW;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        hj = GetComponent<HingeJoint>();
        axis = hj.axis;
        maxTorque = 1.67F / gearRatio;
        maxRpm = 100.0F * gearRatio;
        maxW = maxRpm * 2.0F * 3.14159F / 60;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.LogFormat("{0}, {1}",localAngularVelocity, scaledTorque);

    }

    private void FixedUpdate()
    {
        localAngularVelocity = transform.InverseTransformVector(rb.angularVelocity);
        if (Mathf.Abs(rb.angularVelocity.x) < maxW)
            torque = axis.normalized * (Control.motorControlValue[motorPort] * maxTorque - Vector3.Dot(localAngularVelocity,axis) * maxTorque / maxW);
        else
            torque = new Vector3(0,0,0);

        scaledTorque =  torque;

        rb.AddRelativeTorque(scaledTorque);

    }
}
