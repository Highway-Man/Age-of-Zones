using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniWheel : MonoBehaviour {

    public int motorPort;
    public float gearRatio;
    public int direction;

    private WheelCollider wheel;
    private float maxTorque, maxRpm, magicMotorTorque;
    private Transform visualWheel;


	// Use this for initialization
	void Start () {
        wheel = GetComponent<WheelCollider>();
        maxTorque = 1.67F / gearRatio;
        maxRpm = 100.0F * gearRatio;
        magicMotorTorque = 2.67F;

        visualWheel = GetComponentInChildren<Transform>();
  
    }

    // Update is called once per frame
    void Update () {
        //Debug.LogFormat("{0}, {1}", wheel.motorTorque, wheel.rpm);

        Vector3 position;
        Quaternion rotation;
        wheel.GetWorldPose(out position, out rotation);

        visualWheel.GetChild(0).localEulerAngles = new Vector3(0, 0, -rotation.eulerAngles.x);

    }

    private void FixedUpdate()
    {
        //float torque = 1.0F * (maxTorque - Mathf.Abs(wheel.rpm) * maxTorque / maxRpm);

        //float scaledTorque = Control.motorControlValue[motorPort] * torque;

        wheel.motorTorque = magicMotorTorque * Control.motorControlValue[motorPort] * direction;

        //ApplyLocalPositionToVisuals(wheel);
    }
}
