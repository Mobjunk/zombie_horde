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
        private set;
    }
    public float horizontalMovementLeftStick
    {
        get;
        private set;
    }

    public float verticalMovementLeftStick
    {
        get;
        private set;
    }
    public float horizontalMovementRightStick
    {
        get;
        private set;
    }

    public float verticalMovementRightStick
    {
        get;
        private set;
    }

    public bool pressedAttack
    {
        get;
        private set;
    }

    public bool pressedReload
    {
        get;
        private set;
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
        }
        //No controller connected so use keyboard
        else
        {
            horizontalMovementLeftStick = Input.GetAxisRaw("Horizontal");
            verticalMovementLeftStick = Input.GetAxisRaw("Vertical");
            pressedAttack = Input.GetMouseButtonDown(0);
            pressedReload = Input.GetKeyDown(KeyCode.R);
        }
    }

}
