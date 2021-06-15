using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _firstTarget;
    [SerializeField] private Transform _secondTarget;
    [SerializeField] private float _speed;

    private SpriteRenderer _sprite;
    private Transform _currentTarget;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _currentTarget = _firstTarget;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);

        if (transform.position == _firstTarget.position)
        {
            _currentTarget = _secondTarget;
        }
        else if (transform.position == _secondTarget.position)
        {
            _currentTarget = _firstTarget;
        }

        if (_currentTarget == _firstTarget)
        {
            _sprite.flipX = false;
        }
        else if (_currentTarget == _secondTarget)
        {
            _sprite.flipX = true;
        }
    }
}
