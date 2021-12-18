using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Circle { 

[RequireComponent (typeof(Rigidbody2D))]
public class CircleMovement : MonoBehaviour
{
        [SerializeField] private float _accelerationSpeed;
        [SerializeField] private float _startingSpeed;
        [SerializeField] private float _maximumSpeed;

        private Transform _endPoint;

        private CursorBehaviour _cursorBehaviour;
        private float _acceleratedSpeed;
        public float AcceleratedSpeed => _acceleratedSpeed;

        private bool _isInTheCursorZone;
        public event Action OnEndPointReached;
        public event Action<string> OnVelocityChanged;
        public void Initialize(EndPoint endPoint)
        {
            print("I am initialized");
            _endPoint = endPoint.transform;
        }

        public void SetMaximumSpeed(float setMaximumSpeed)
        {
            _maximumSpeed = setMaximumSpeed;
        }
        private void FixedUpdate()
    {
           if (!_isInTheCursorZone) MovingToTheDestination(_accelerationSpeed, _maximumSpeed, _endPoint);
           if (_isInTheCursorZone) MovingAway();
            print(_acceleratedSpeed);
            OnVelocityChanged("Current velocity is " + (Math.Round(_acceleratedSpeed, 4)).ToString());
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
                print("ReachedEndPoint");
                OnEndPointReached?.Invoke(); 
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            LeavingTheCursorZone(collision);
        }

        private void LeavingTheCursorZone(Collider2D collision)
        {
            if (collision.TryGetComponent<CursorBehaviour>(out var cursorBehaviour))
            {
                print("Work here");
                //MovingToTheDestination(-_accelerationSpeed, _maximumSpeed, cursorBehaviour.transform); it works but attracts the ball to the centre
                
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

    }


  
}
