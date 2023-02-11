using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Enemy moves towards player at a constant velocity and flips when the player is on its left/right
 * 
 */ 

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    [SerializeField] public float jumpPower = 5f;
    [SerializeField] private LayerMask jumpableGround;
    private BoxCollider2D coll;
    [SerializeField] public float jumpInterval = 1.5f;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        distance = Vector2.Distance(transform.position, player.transform.position);
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        //Debug.Log("X Velocity:" + rb.velocity.x);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);  
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        //Debug.Log("X Velocity:" + rb.velocity.x);

        if ((player.transform.position.x - transform.position.x) < 0) 
        {
            sprite.flipX = true;
        }
        else {
            sprite.flipX = false;
        }

        if (IsGrounded()) {
            //StartCoroutine(jumpWait());
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Limit"))
        {
            Destroy(this.gameObject);
        }

        /*if (collision.gameObject.CompareTag("Player")) {

            Vector2 vec = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            rb.AddForce(-4 * vec);
        }*/
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    /*
    private IEnumerator jumpWait()
    {
        yield return new WaitForSeconds(jumpInterval);
    }*/




}
