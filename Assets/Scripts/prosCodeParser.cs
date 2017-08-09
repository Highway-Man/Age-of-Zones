using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prosCodeParser : MonoBehaviour {

    public static string[,] computerControls;
    public const int JOY_UP = 1, JOY_RIGHT = 2, JOY_DOWN = 3, JOY_LEFT = 4;
    private void Start()
    {
        computerControls = new string[10, 5];
        computerControls[3, 1] = "i";
        computerControls[3, 2] = "k";
        computerControls[2, 1] = "o";
        computerControls[2, 2] = "l";
        computerControls[6, 1] = "r";
        computerControls[6, 3] = "f";
        computerControls[5, 1] = "q";
        computerControls[5, 3] = "a";
        computerControls[7, 1] = "w";
        computerControls[7, 3] = "s";
        computerControls[8, 3] = "d";

        OpControl userCode = GetComponent<OpControl>();
        
        StartCoroutine(userCode.operatorControl());
    }

    public float abs(float val)
    {
        return Mathf.Abs(val);
    }

    public void motorSet(int port, int control)
    {
        Control.motorControlValue[port] = (float) (control / 127f);
    }

    public int motorGet(int port)
    {
        return (int) (Control.motorControlValue[port] * 127);
    }

    public int encoderGet(int port)
    {
        return Control.encoderCount[port];
    }

    public void encoderReset(int port)
    {
        Control.encoderCount[port] = 0;
    }

    public int joystickGetAnalog(int controller, int axis)
    {
        if (Input.GetKey(computerControls[axis, 1]))
            return 127;
        else if (Input.GetKey(computerControls[axis, 2]))
            return -127;
        else
            return 0;
    }

    public bool joystickGetDigital(int controller, int group, int direction)
    {
        if (Input.GetKey(computerControls[group, direction]))
             return true;
        else
            return false;
    }

    public void print(string message)
    {
        Debug.Log(message);
    }
    public void printf(string formated, int x)
    {
        Debug.LogFormat("{0}", x);
    }
    public void printf(string formated, int x, int y)
    {
        Debug.LogFormat("{0}, {1}", x, y);
    }
    public void printf(string formated, float x)
    {
        Debug.LogFormat("{0}", x);
    }
    public void printf(string formated, int x, float y)
    {
        Debug.LogFormat("{0}, {1}", x, y);
    }
    public void printf(string formated, float x, float y)
    {
        Debug.LogFormat("{0}, {1}", x, y);
    }

    public delegate void function();
    public void taskCreate(function taskFunction, int stackSize, int parameter, int priority)
    {
        //start task :(
    }

    public IEnumerator delay(int ms)
    {
        yield return new WaitForSeconds(ms / 1000);
    }

    //IEnumerator CodeLoop()
    //{
    //    OpControl userCode = new OpControl();
    //    userCode.operatorControl();
    //    yield return null;
    //}



}
