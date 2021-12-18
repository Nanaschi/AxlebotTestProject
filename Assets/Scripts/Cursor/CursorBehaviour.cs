using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent (typeof(CircleCollider2D))] 
public class CursorBehaviour : MonoBehaviour
{
    private float _radiusOfTheZone; 

    private void Awake()
    {
        _radiusOfTheZone = transform.localScale.x / 2;
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

    public void SetRadiusOfTheZone(float newRadius)
    {
        transform.localScale = new Vector2(newRadius, newRadius);
    }

}
