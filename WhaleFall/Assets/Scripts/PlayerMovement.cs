using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public GameObject pDashEffect;
    public GameObject pDashEffect_Links;
    [SerializeField] private float playerSpeed = 5.0f; //Beispielwerte können nach Ausprobieren gerne geändert werden
    [SerializeField] private float jumpPower = 15.0f;
    [SerializeField] private float superJumpForce = 30.0f;
    public float cooldownTime_sJump = 5f;
    [SerializeField] private float dashDistance = 10f;
    public float cooldownTime_Dash = 5f;

    private bool canSuperJump = true;
    private Rigidbody2D _playerRigidbody;
    public float lastSuperJumpTime;
    public float lastDashTime;

    private bool facingRight = true;

    public WeaponSystem WeaponSystem;

    public AudioSource dashSound;
    public AudioSource jumpSFX;
    public AudioSource sJumpSFX;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
        lastDashTime = Time.time - cooldownTime_Dash;
        lastSuperJumpTime = Time.time - cooldownTime_sJump;

    }
    private void Update()
    {
        ChangeLookDirection();
        MovePlayer();

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }

        else if (Input.GetKey(KeyCode.Return) && IsGrounded())
        {
            SJump();
        }

        else if (Input.GetKey(KeyCode.W))
        {
            WeaponSystem.Fire();
        }

        else if (CanMove(transform.right, dashDistance) && facingRight)
        {
            handleDash();
        }

        else if (CanMove(-transform.right, dashDistance) && !facingRight)
        {
            handleDash();
        }

    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }
    private void Jump() { _playerRigidbody.velocity = new Vector2(0, jumpPower); _playerRigidbody.gravityScale = 4; jumpSFX.Play(); }

    private bool IsGrounded()
    {

        return (_playerRigidbody.velocity.y == 0f);
    }

    private void SJump()
    {
        if (canSuperJump && (Time.time - lastSuperJumpTime) > cooldownTime_sJump)
        {

            _playerRigidbody.velocity = new Vector2(0, superJumpForce);
            _playerRigidbody.gravityScale = 5;
            
            sJumpSFX.Play();

            lastSuperJumpTime = Time.time;
        }
    }

    private void ChangeLookDirection()
    {
        if (facingRight && Input.GetAxisRaw("Horizontal") < 0 || !facingRight && Input.GetAxisRaw("Horizontal") > 0)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            Vector3 position = transform.position;
            scale.x *= -1;
            transform.localScale = scale;

            position.x += scale.x * 0.5f;
            transform.position = position;
        }
    }

    private bool CanMove(Vector2 dir, float distance)
    {
        return (Physics2D.Raycast(transform.position, dir, distance).collider == null);
    }

    private void handleDash()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && (Time.time - lastDashTime) > cooldownTime_Dash)
        {
            dashSound.Play();
            if (facingRight)
            {
                Vector3 beforeDashPosition = transform.position - new Vector3(0f, 5.5f, 0f);
                GameObject dashEffectObject = Instantiate(pDashEffect, beforeDashPosition, Quaternion.identity);
                float dashEffectWidth = 2.5f;
                dashEffectObject.transform.localScale = new Vector3(dashDistance / dashEffectWidth, 1f, 1f);
                transform.position += transform.right * dashDistance;

            }
            else
            {
                Vector3 beforeDashPosition = transform.position - new Vector3(0f, 5.5f, 0f);
                Vector3 dashEndPosition = beforeDashPosition - transform.right * dashDistance; // speichere die Endposition des Dashs
                GameObject dashEffectObject = Instantiate(pDashEffect_Links, dashEndPosition, Quaternion.identity);
                float dashEffectWidth = 2.5f;
                dashEffectObject.transform.localScale = new Vector3(dashDistance / dashEffectWidth, 1f, 1f);
                transform.position -= transform.right * dashDistance;
            }
            lastDashTime = Time.time;
        }
    }
}