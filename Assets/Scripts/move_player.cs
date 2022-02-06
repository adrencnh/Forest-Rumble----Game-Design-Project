using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player : MonoBehaviour
{

    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // WASD is method of movement
        if (Input.GetKey(KeyCode.A)){
            transform.Translate(Vector2.left*speed*Time.deltaTime);
        } else if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector2.right*speed*Time.deltaTime);
        }
    }
}
