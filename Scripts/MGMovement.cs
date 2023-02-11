using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 14f;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 20f;
    private float dashingTime = 0.35f;

    [SerializeField] private float dashingCooldown = 1000f;
    private float currentCD;
    [SerializeField] private AudioSource dashSoundEffect;
    private bool isFacingRight = false;
    [SerializeField] GameObject dashCollider;

    private enum MovementState { idle, running, jumping, falling, dashing }

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] public Image dashAvailable;
    [SerializeField] public GameObject dashObject;

    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    private void Start()
    {
        dashObject.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

        if (isDashing)
        {
            return;
        }

        if (!canDash) {
            currentCD += 1f;
            updateDashCDImage(dashingCooldown, currentCD);
            if (currentCD >= dashingCooldown) {
                canDash = true;
            }
        }

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (isDashing)
        {
            state = MovementState.dashing;
            anim.SetInteger("state", (int)state);
            return;
        }

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
            isFacingRight = true;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
            isFacingRight = false;
        }
        else
        {
            state = MovementState.idle;
        }



        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        currentCD = 0f;
        isDashing = true;
        updateDashCDImage(dashingCooldown, currentCD);
        dashCollider.SetActive(true);
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        if (isFacingRight)
        {
            rb.velocity = new Vector2(dashingPower, 0f);
        }
        else {
            rb.velocity = new Vector2((-1) * dashingPower, 0f);
        }
        UpdateAnimationState();

        dashSoundEffect.Play();
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        dashCollider.SetActive(false);
        //yield return new WaitForSeconds(dashingCooldown);

    }


    private void updateDashCDImage(float dashingCooldown, float currentCD) {
        dashAvailable.fillAmount = currentCD / dashingCooldown;
    }

}