using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player : MonoBehaviour
{
    
    public float speed = 3.0f;
    
    [SerializeField] private LayerMask platformsLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
            SoundManagerScript.PlaySound("playerJump");
            float jumpVelocity = 7f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        // WASD is method of movement
        if (Input.GetKey(KeyCode.A)){
            if (IsGrounded()){
                rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
            } else {
                // change this to change degree to which you can move mid air
                float control_in_air = 1f;
                rigidbody2d.velocity += new Vector2(-speed * control_in_air * Time.deltaTime, 0);
                rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -speed, +speed) , rigidbody2d.velocity.y);
            }
        } else {
            if (Input.GetKey(KeyCode.D)){
                if (IsGrounded()){
                    rigidbody2d.velocity = new Vector2(+speed, rigidbody2d.velocity.y);
                } else {
                    // change this to change degree to which you can move mid air
                    float control_in_air = 1f;
                    rigidbody2d.velocity += new Vector2(+speed * control_in_air * Time.deltaTime, 0);
                    rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -speed, +speed), rigidbody2d.velocity.y);
                }
            } else {
                // no keys are pressed 
                if (IsGrounded()){
                  rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);

                }
            }
        }
    }
    
    bool IsGrounded(){
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        // Debug.Log(raycastHit2d.collider); // Uncomment previous comment to show when the player is standing on the ground
        return (raycastHit2d.collider != null);
    }
}
