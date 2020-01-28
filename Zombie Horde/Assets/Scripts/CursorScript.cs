using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    PlayerAiming playerAiming => PlayerAiming.instance;
    Rigidbody2D rb;
    Vector3 mousePosition;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(mousePosition.x,mousePosition.y,transform.position.z);
    }
}
