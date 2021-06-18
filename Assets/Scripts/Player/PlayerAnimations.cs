using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Hurt()
    {
        _animator.SetTrigger("Hurt");
    }

    public void Run(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }

    public void Idle()
    {
        _animator.SetFloat("Speed", 0);
    }

    public void Jump()
    {
        _animator.SetTrigger("Jump");
    }
}
