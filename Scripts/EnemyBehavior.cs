using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;

    // [SerializeField] Rigidbody2D rb;
    public Transform parent;
    public Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        parent = transform.parent;
        rb = parent.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingRight()) {
            // move right
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        } else {
            // move left
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    private bool isFacingRight() {
        return transform.localScale.x > Mathf.Epsilon;
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision) {
        
        // turn
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }*/
    
}
