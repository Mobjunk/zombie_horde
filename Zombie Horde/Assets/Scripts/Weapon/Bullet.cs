using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 2.5f;
    [SerializeField] private Rigidbody2D rigidBody;
    
    private void Awake()
    {
        Destroy(gameObject, _lifeTime);//Makes sure missed bullets automatically get destroyed after _lifeTime seconds
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Initialize(GunData gun)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get mouse position
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward); // set rotation to mouse position
        transform.rotation = rot; //rotates game object to correct position
        transform.eulerAngles = new Vector3(0,0, transform.eulerAngles.z); //remove x and y rotation along the x and y axis
        rigidBody.velocity = transform.up * gun.bulletMovementSpeed; 
    }
}