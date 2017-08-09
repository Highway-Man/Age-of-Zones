using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {

    public float gearRatio;
    public int motorPort;
    public int direction;
    public int limit, offset;

    private Rigidbody rb;
    private HingeJoint hj;

    private Vector3 axis, localAngularVelocity, scaledTorque, torque;
    private float maxTorque, maxRpm, maxW, localRotation;

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
        //Debug.LogFormat("{0}, {1}",localAngularVelocity, Time.fixedDeltaTime);
        Debug.LogFormat("ang: {0}", localRotation);
    }

    private void FixedUpdate()
    {
        localRotation = hj.angle+offset;
        if (localRotation > 180)
            localRotation = localRotation-360;

        localAngularVelocity = transform.InverseTransformVector(rb.angularVelocity);
        float localAngularVelocityScalar = Vector3.Dot(localAngularVelocity, axis);
            torque = axis.normalized * (Control.motorControlValue[motorPort]*direction * maxTorque - localAngularVelocityScalar * maxTorque / maxW);

        if (localRotation > limit)
        {
            scaledTorque = axis.normalized * -maxTorque;
        }
        else if (localRotation < -limit)
            scaledTorque = axis.normalized * maxTorque;
        else
            scaledTorque = torque;


        rb.AddRelativeTorque(scaledTorque);

    }
}
