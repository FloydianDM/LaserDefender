using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;

    private Vector2 _offset = new Vector2(0f, 1f);
    private Material _material;

    void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }
    
    void Update()
    {
        _offset = moveSpeed * Time.deltaTime;
        _material.mainTextureOffset += _offset;
    }
}
