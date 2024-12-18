using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private GameObject player;
    public float horizontalInput;
    public bool playerIsOnGround = false;
    private float playerSpeed = 5.0f;
    private float jumpForce = 5.0f;

    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        startPos = player.transform.position;
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

        if (player.transform.position.y < -2)
        {
            player.transform.position = startPos;
        }
    }

    private void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(horizontalInput * playerSpeed, playerRigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cube"))
        {
            playerIsOnGround = true;
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
