using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody PlayerRb;
    public float JumpForce = 10;
    public float GravityModifier;
    public bool IsOnGround;
    public bool GameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            PlayerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
            Debug.Log("Game over!");
        }
    }
}
