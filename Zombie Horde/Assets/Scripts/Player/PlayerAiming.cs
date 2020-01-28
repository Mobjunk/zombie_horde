using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    public static PlayerAiming instance;
    InputManager inputManager => InputManager.instance;
    PlayerMovement playerMovement => PlayerMovement.instance;
    public Camera _camera;
    public Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        

       
   

        if (inputManager.controllerConnected)
        {

        }
        else LookAtMouse();


    }

    void LookAtMouse()
    {
        mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - playerMovement.rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        playerMovement.rb.rotation = angle;

    }
}
