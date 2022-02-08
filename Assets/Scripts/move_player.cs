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
            float jumpVelocity = 7f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        // WASD is method of movement
        if (Input.GetKey(KeyCode.A)){
            transform.Translate(Vector2.left*speed*Time.deltaTime);
        } else if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector2.right*speed*Time.deltaTime);
        }
    }

    bool IsGrounded(){
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
        return (raycastHit2d.collider != null);
    }
}
