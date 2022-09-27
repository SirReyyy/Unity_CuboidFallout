using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D playerBody;
    public float moveSpeed = 1.8f;

    void Awake() {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        if(Input.GetAxisRaw("Horizontal") > 0.0f) {
            playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);
        }
        if(Input.GetAxisRaw("Horizontal") < 0.0f) {
            playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y);
        }
    }

    public void PlatformMove(float x) {
        playerBody.velocity = new Vector2(x, playerBody.velocity.y);
    }
}
