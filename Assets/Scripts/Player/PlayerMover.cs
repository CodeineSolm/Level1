using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimations))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _sprite;
    private PlayerAnimations _animations;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else
        {
            Idle();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void MoveLeft()
    {
        _sprite.flipX = true;
        transform.Translate(-_speed * Time.deltaTime, 0, 0);
        _animations.Run(_speed);
    }

    private void MoveRight()
    {
        _sprite.flipX = false;
        transform.Translate(_speed * Time.deltaTime, 0, 0);
        _animations.Run(_speed);
    }

    private void Jump()
    {
        if (_rigidbody.velocity.y != 0)
            return;

        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
        _animations.Jump();
    }

    private void Idle()
    {
        _animations.Idle();
    }
}
