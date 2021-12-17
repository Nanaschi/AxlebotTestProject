using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent (typeof(CircleCollider2D))] 
public class CursorBehaviour : MonoBehaviour
{
    private CircleCollider2D _circleCollider2D;

    private void Awake()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        print(RadiusOfTheZone());
    }

    private void FixedUpdate()
    {
        ZoneFollowingCursor();
    }

    private void ZoneFollowingCursor()
    {
        Vector2 _mousePos = Input.mousePosition;
        _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        transform.position = _mousePos;
    }

    public float RadiusOfTheZone()
    {
        return (transform.localScale.x)/2;
    }

}
