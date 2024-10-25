using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    private float horizontal;
    private float PlayerSpeed = 6f;
    private float PlayerJump = 12f;
    private bool FacingRight = true;

    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask Ground;



    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // If button jump is down then

        if (Input.GetButtonDown("Jump")&& Grounded())
        {
            RB.velocity = new Vector2(RB.velocity.x, PlayerJump);

        }
        if(Input.GetButtonDown("Jump")&& RB.velocity.y > 0f)
        {
            RB.velocity = new Vector2(RB.velocity.x, RB.velocity.y * 0.5f);
        }

        PlayerFlip(); //calls flip function where player turns 
        
    }
    private void FixedUpdate()
    {
        RB.velocity = new Vector2(horizontal * PlayerSpeed, RB.velocity.y);
    }

    private void PlayerFlip()
    {
        if (FacingRight && horizontal < 0f || FacingRight && horizontal > 0f)
        {
            FacingRight = !FacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x = -1f;
            transform.localScale = localScale;
        }

    }

    private bool Grounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, Ground);
    }
}
