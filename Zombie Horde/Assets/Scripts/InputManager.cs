using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public bool controllerConnected
    {
        get;
        set;
    }
    public float horizontalMovementLeftStick
    {
        get;
        set;
    }

    public float verticalMovementLeftStick
    {
        get;
        set;
    }
    public float horizontalMovementRightStick
    {
        get;
        set;
    }

    public float verticalMovementRightStick
    {
        get;
        set;
    }

    public bool aButtonPressed
    {
        get;
        set;
    }

    public bool bButtonPressed
    {
        get;
        set;
    }

    public bool xButtonPressed
    {
        get;
        set;
    }

    public bool yButtonPressed
    {
        get;
        set;
    }

    public bool lbButtonPressed
    {
        get;
        set;
    }

    public bool rbButtonPressed
    {
        get;
        set;
    }

    public bool rbButtonHeld
    {
        get;
        set;
    }

    public bool quitButtonPressed
    {
        get;
        set;
    }
    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        //Loops though all connected joysticks
        foreach (string name in Input.GetJoystickNames())
        {
            Debug.Log($"ControllerName: {name}");
            //Wireless gamepad = nintendo pro controller/joycons
            if (name.Equals("Wireless Gamepad")||name.Equals("Wireless Controller"))
            {
                controllerConnected = true;
            }
        }

        //Nintendo joycon connected
        if (controllerConnected)
        {
            horizontalMovementLeftStick = Input.GetAxisRaw("LeftStickX-AxisPS4");
            verticalMovementLeftStick = Input.GetAxisRaw("LeftStickY-AxisPS4");
            horizontalMovementRightStick = Input.GetAxisRaw("RightStickX-AxisPS4");
            verticalMovementRightStick = Input.GetAxisRaw("RightStickY-AxisPS4");
            aButtonPressed = Input.GetButtonDown("AButton");
            bButtonPressed = Input.GetButtonDown("BButton");
            xButtonPressed = Input.GetButtonDown("XButton");
            yButtonPressed = Input.GetButtonDown("YButton");
            quitButtonPressed = Input.GetButtonDown("MinusButton");
            lbButtonPressed = Input.GetButtonDown("SLButton");
            rbButtonPressed = Input.GetButtonDown("SRButton");
            rbButtonHeld = Input.GetButton("SRButton");
        }
        //No controller connected so use keyboard
        else
        {
            horizontalMovementLeftStick = Input.GetAxisRaw("Horizontal");
            verticalMovementLeftStick = Input.GetAxisRaw("Vertical");
            aButtonPressed = Input.GetButtonDown("Jump");
            bButtonPressed = Input.GetKeyDown(KeyCode.F);
            xButtonPressed = Input.GetKeyDown(KeyCode.R);
            quitButtonPressed = Input.GetKeyDown(KeyCode.Escape);
            rbButtonPressed = Input.GetKeyDown(KeyCode.LeftShift);
            rbButtonHeld = Input.GetKey(KeyCode.LeftShift);
        }

        if (quitButtonPressed)
        {
            SceneManager.LoadScene("TItle Screen");
        }
    }

}
