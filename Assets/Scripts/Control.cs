using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public static float[] motorControlValue;

	// Use this for initialization
	void Start () {
        motorControlValue = new float[10];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up"))
        {
            motorControlValue[1] = 1.0F;
            motorControlValue[2] = 1.0F;
            motorControlValue[3] = 1.0F;
            motorControlValue[4] = 1.0F;
        }
        else if (Input.GetKey("down"))
        {
            motorControlValue[1] = -1.0F;
            motorControlValue[2] = -1.0F;
            motorControlValue[3] = -1.0F;
            motorControlValue[4] = -1.0F;
        }
        else if (Input.GetKey("right"))
        {
            motorControlValue[1] = 1.0F;
            motorControlValue[2] = 1.0F;
            motorControlValue[3] = -1.0F;
            motorControlValue[4] = -1.0F;
        }
        else if (Input.GetKey("left"))
        {
            motorControlValue[1] = -1.0F;
            motorControlValue[2] = -1.0F;
            motorControlValue[3] = 1.0F;
            motorControlValue[4] = 1.0F;
        }
        else
        {
            motorControlValue[1] = 0.0F;
            motorControlValue[2] = 0.0F;
            motorControlValue[3] = 0.0F;
            motorControlValue[4] = 0.0F;
        }

        if (Input.GetKey("q"))
        {
            motorControlValue[5] = -1f;
        }
        else if (Input.GetKey("a"))
        {
            motorControlValue[5] = 1f;
        }
        else
        {
            motorControlValue[5] = -.15f;
        }

        if (Input.GetKey("w"))
        {
            motorControlValue[6] = 1f;
        }
        else if (Input.GetKey("s"))
        {
            motorControlValue[6] = -1f;
        }
        else
        {
            motorControlValue[6] = .1f;
        }

        if (Input.GetKey("e"))
        {
            motorControlValue[7] = -1f;
        }
        else if (Input.GetKey("d"))
        {
            motorControlValue[7] = 1f;
        }
        else
        {
            motorControlValue[7] = -.01f;
        }
    }
}
