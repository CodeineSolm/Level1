using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
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
            Stay();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void MoveLeft()
    {
        _sprite.flipX = true;
        _animator.SetFloat("Speed", _speed);
        transform.Translate(-_speed * Time.deltaTime, 0, 0);
    }

    private void MoveRight()
    {
        _sprite.flipX = false;
        _animator.SetFloat("Speed", _speed);
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    private void Jump()
    {
        if (_rigidbody.velocity.y != 0)
            return;
        
        _animator.SetTrigger("Jump");
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
    }

    private void Stay()
    {
        _animator.SetFloat("Speed", 0);
    }
}
