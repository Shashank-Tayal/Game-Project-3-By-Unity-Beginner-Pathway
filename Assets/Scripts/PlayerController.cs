using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // By adding rigidbody we can add physics mechanics to the player.
    // "isOnGround" variable helps us to add the delay in pressing the space bar which prevents spamming of it and flying to the space :) .
    // Variables:- 
    private Rigidbody playerRB;
    public InputAction jumpAction;
    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    private bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        jumpAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = true;

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
        }
    }
}
