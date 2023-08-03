using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;
    

    private Vector2 _rawInput;
    private Vector2 _minBounds;
    private Vector2 _maxBounds;
    private Shooter _shooter;

    void Awake()
    {
        _shooter = FindObjectOfType<Shooter>();
    }
    
    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        Vector2 delta = new Vector2(_rawInput.x * moveSpeed * Time.deltaTime, _rawInput.y * moveSpeed * Time.deltaTime);
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, _minBounds.x + paddingLeft, _maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, _minBounds.y + paddingBottom, _maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (_shooter != null)
        {
            _shooter.isFiring = true;
        }
    }
}
