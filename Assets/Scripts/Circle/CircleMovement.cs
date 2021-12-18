using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Circle { 

[RequireComponent (typeof(Rigidbody2D))]
public class CircleMovement : MonoBehaviour
{

        private Transform _endPoint;
        private CursorBehaviour _cursorBehaviour;

        [SerializeField] private float _accelerationSpeed;
        [SerializeField] private float _startingSpeed;
        [SerializeField] private float _maximumSpeed;


        private float _acceleratedSpeed;
        public float AcceleratedSpeed => _acceleratedSpeed;

        private bool _isInTheCursorZone;

        public event Action OnEndPointReached;
        public event Action<string> OnVelocityChanged;
        public void Initialize(EndPoint endPoint)
        {
            _endPoint = endPoint.transform;
        }

    
        private void FixedUpdate()
    {
           if (!_isInTheCursorZone) MovingToTheDestination(_accelerationSpeed, _maximumSpeed, _endPoint);
           if (_isInTheCursorZone) MovingAway();
            OnVelocityChanged?.Invoke("Current speed is " + (Math.Round(_acceleratedSpeed, 3)).ToString());
            ReachedEndPoint();
    }

    private void MovingToTheDestination(float accelerationSpeed, float maximumSpeed, Transform finalDestination)
    {
            
            if (transform.position != finalDestination.position)
            {
                _acceleratedSpeed += _startingSpeed * accelerationSpeed;
                _acceleratedSpeed = Mathf.Clamp(_acceleratedSpeed, _startingSpeed, maximumSpeed);
                transform.position = Vector2.MoveTowards(transform.position, finalDestination.position, _acceleratedSpeed);
            } 
    }
        public void MovingAway()
        {
            _acceleratedSpeed += _startingSpeed * _accelerationSpeed;
            transform.position = Vector2.MoveTowards(transform.position, _cursorBehaviour.transform.position, -_acceleratedSpeed);
        }



        private void ReachedEndPoint()
        {
            if (transform.position == _endPoint.position)
            {
                OnEndPointReached?.Invoke(); 
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<CursorBehaviour>(out var cursorBehaviour))
            {
              _cursorBehaviour = cursorBehaviour;
              _isInTheCursorZone = true;
            }
        }


        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<CursorBehaviour>(out var cursorBehaviour))
            {
                _cursorBehaviour = null;
                _isInTheCursorZone = false;
            }
        }



        public void SetMaximumSpeed(float setMaximumSpeed)
        {
            _maximumSpeed = setMaximumSpeed;
        }


        public void SetAccelerationSpeed(float maximumAccelerationSpeed)
        {
            _accelerationSpeed = maximumAccelerationSpeed;
        }

    }


  
}
