using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f; //Beispielwerte können nach Ausprobieren gerne geändert werden
    [SerializeField] private float jumpPower = 15.0f;
    [SerializeField] private float superJumpForce = 30.0f;
    [SerializeField] private float cooldownTime_sJump  = 5f;
    [SerializeField] private float dashDistance = 10f;

    private bool canSuperJump = true;
    private Rigidbody2D _playerRigidbody;
    public float lastSuperJumpTime;

    private bool facingRight = true;

    public WeaponSystem WeaponSystem;

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
        ChangeLookDirection();
        MovePlayer();

        if (Input.GetKey(KeyCode.Space) && IsGrounded()){
            Jump();
        }

        else if(Input.GetKey(KeyCode.Return) && IsGrounded()){
            SJump();
        }

        else if (Input.GetKey(KeyCode.W))
        {
            WeaponSystem.Fire();
        }

        else if(CanMove(transform.forward, dashDistance)){
            handleDash();
        }
    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }
    private void Jump() {_playerRigidbody.velocity = new Vector2( 0, jumpPower); _playerRigidbody.gravityScale = 4;}

    private bool IsGrounded()
    {
        
       return (_playerRigidbody.velocity.y == 0f);
    }

    private void SJump(){
        if (canSuperJump && (Time.time - lastSuperJumpTime) > cooldownTime_sJump)
        {
            
            _playerRigidbody.velocity = new Vector2( 0, superJumpForce);
            _playerRigidbody.gravityScale = 5;

            lastSuperJumpTime = Time.time;
        }
    }

    private void ChangeLookDirection()
    {
        if (facingRight && Input.GetAxisRaw("Horizontal") < 0 || !facingRight && Input.GetAxisRaw("Horizontal") > 0)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private bool CanMove(Vector2 dir, float distance){
        return (Physics2D.Raycast(transform.position, dir, distance).collider == null);
    }

    private void handleDash(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            
            transform.position += transform.forward * dashDistance;
        }
    }

   
}
