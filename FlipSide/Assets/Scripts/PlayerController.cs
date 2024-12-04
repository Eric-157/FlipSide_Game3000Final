using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private GameObject player;
    public float horizontalInput;
    public bool playerIsOnGround = false;
    private float playerSpeed = 5.0f;
    private float jumpForce = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W) && playerIsOnGround)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            playerIsOnGround = false;
        }
    }

    private void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(horizontalInput * playerSpeed, playerRigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerIsOnGround = true;
        }
    }
}
