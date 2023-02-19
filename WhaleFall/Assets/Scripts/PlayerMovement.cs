using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f; //Beispielwerte können nach Ausprobieren gerne geändert werden
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private float superJumpForce = 7f;
    [SerializeField] private float cooldownTime_sJump  = 5f;

    private bool canSuperJump = true;
    private Rigidbody2D _playerRigidbody;
    private float lastSuperJumpTime;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
    }
    private void Update()
    {
        MovePlayer();

        if (Input.GetKey(KeyCode.Space) && IsGrounded()){
            Jump();
        }

        else if(Input.GetKey(KeyCode.Return) && IsGrounded()){
            SJump();
        }
    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }
    private void Jump() {_playerRigidbody.velocity = new Vector2( 0, jumpPower); _playerRigidbody.gravityScale = 1;}

    private bool IsGrounded()
    {
        
       return (_playerRigidbody.velocity.y == 0f);
    }

    private void SJump(){
        if (canSuperJump && (Time.time - lastSuperJumpTime) > cooldownTime_sJump){
            
                _playerRigidbody.velocity = new Vector2( 0, superJumpForce);
                _playerRigidbody.gravityScale = 2;
                lastSuperJumpTime = Time.time;
            }
    }

    

   
}
