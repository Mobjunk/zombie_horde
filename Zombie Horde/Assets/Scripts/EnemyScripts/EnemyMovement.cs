using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    PlayerHealth playerHealth => PlayerHealth.instance;
    public ParticleSystem dust;
    public Rigidbody2D rb2d;
    public Transform target;
    public float speed;
    public float minimumDistance;
    public float maximumDistance;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth.playerAlive = true;
        rb2d.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   if (playerHealth.playerAlive == true)
        {
            if (Vector2.Distance(this.transform.position, target.position) > minimumDistance && Vector2.Distance(this.transform.position, target.position) < maximumDistance)
            {
                Vector3 diff = target.position - transform.position;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

                rb2d.velocity = rb2d.transform.rotation * new Vector2(speed, 0);
                CreateDust();
            }
            else if (target)
            {
                rb2d.velocity = new Vector2(0, 0);
            }
        } 
       
    }

    public void CreateDust()
    {
        dust.Play();
    }
}
