using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpControl : prosCodeParser {

    //Header Code


    const int ilArm = 1, olArm = 2, alDrive = 3, flDrive = 4, fourbar = 5, claw = 6, frDrive = 7, arDrive = 8, orArm = 9, irArm = 10;
    const int armEnc = 1;
    

    //End Header Code

    void lDriveSet(int control)
    {
        motorSet(flDrive, control);
        motorSet(alDrive, -control);
    }
    void rDriveSet(int control)
    {
        motorSet(frDrive, -control);
        motorSet(arDrive, control);
    }
    void chainbarSet(int control)
    {
        motorSet(olArm, control);
        motorSet(ilArm, -control);
        motorSet(orArm, -control);
        motorSet(irArm, control);
    }
    void chainbarControl(int target)
    {
        int last, command, deltaMax = 10;
        last = motorGet(olArm);
        if (target - last > deltaMax)
            command = last + deltaMax;
        else if (target - last < -deltaMax)
            command = last - deltaMax;
        else
            command = target;
        chainbarSet(command);
    }
    void clawSet(int control)
    {
        motorSet(claw, control);
    }
    int clawPosition = 1;
    int time = 0;
    int last = 1;
    void closeClaw(int close)
    {
        if (close != last)
            time = 0;
        if (close==1 && time < 350)
            clawSet(127);
        else if (close==1)
            clawSet(30);
        else if (time < 500)
            clawSet(-127);
        else
            clawSet(-15);
        time += 25;
        last = close;
    }
    void fourbarSet(int control)
    {
        motorSet(fourbar, control);
    }

    int fourbarLast;
    int chainbarLast = 0;
    public IEnumerator operatorControl()
    {
        //prepChainbar();
        //autonomous();
        while (true)
        {
            //set drive motors with a deadband of 5
            if (abs(joystickGetAnalog(1,3)) > 5)
                lDriveSet(joystickGetAnalog(1,3));
            else
                lDriveSet(0);
            if (abs(joystickGetAnalog(1,2)) > 5)
                rDriveSet(joystickGetAnalog(1,2));
            else
                rDriveSet(0);

            //set intake motors
            if (joystickGetDigital(1,6,JOY_UP))
                clawPosition = 1;
            else if (joystickGetDigital(1,6,JOY_DOWN))
                clawPosition = 0;
            closeClaw(clawPosition);

            
            //set lift motors; apply holding power of 12
            if (joystickGetDigital(1,5,JOY_UP))
            {
                chainbarControl(100);
                chainbarLast = 1;
            }
            else if (joystickGetDigital(1,5,JOY_DOWN))
            {
                chainbarControl(-100);
                chainbarLast = -1;
            }
            //else if (encoderGet(armEnc) < 100)
            //    chainbarControl(-12);
            else
                chainbarControl(0);

            if (joystickGetDigital(1, 7, JOY_UP))
            {
                fourbarSet(127);
                fourbarLast = 127;
            }
            else if (joystickGetDigital(1, 7, JOY_DOWN))
            {
                fourbarSet(-127);
                fourbarLast = -127;
            }
            else if (fourbarLast > 0)
                fourbarSet(35);
            else
                fourbarSet(0);

            if (joystickGetDigital(1, 8, JOY_DOWN))
                encoderReset(armEnc);

            //auton practice without competition switch
            //		if(joystickGetDigital(1,8,JOY_UP))
            //			standardAuton();

            //print encoder value to terminal
            printf("%d, ", encoderGet(armEnc));

            
            yield return new WaitForSeconds(25 / 1000);
        }
    }
}
