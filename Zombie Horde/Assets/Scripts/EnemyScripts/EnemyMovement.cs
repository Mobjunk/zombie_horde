using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
    public Tilemap backgroundTilemap;
    public Tile[] slowTiles;
    PlayerHealth playerHealth => PlayerHealth.instance;
    public ParticleSystem dust;
    public Rigidbody2D rb2d;
    public Transform target;
    public float speed;
    public float slowSpeed;
    public float minimumDistance;
    public float maximumDistance;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.playerAlive = true;
        rb2d.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   if (PlayerHealth.playerAlive == true)
        {
            if (Vector2.Distance(this.transform.position, target.position) > minimumDistance && Vector2.Distance(this.transform.position, target.position) < maximumDistance)
            {
                Vector3 diff = target.position - transform.position;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

                Move();
                CreateDust();
            }
            else if (target)
            {
                rb2d.velocity = new Vector2(0, 0);
            }
        } 
       
    }

    private void Move()
    {
        Vector3Int gridPosition = backgroundTilemap.WorldToCell(this.transform.position);
        TileBase tile = backgroundTilemap.GetTile(gridPosition);
        if (tile != null)
        {
            foreach (var slowTile in slowTiles)
            {
                if (slowTile.name == tile.name)
                {
                    rb2d.velocity = rb2d.transform.rotation * new Vector2(slowSpeed, 0);
                    return;
                }
            }
        }
        rb2d.velocity = rb2d.transform.rotation * new Vector2(speed, 0);
    }

    public void CreateDust()
    {
        dust.Play();
    }
}
