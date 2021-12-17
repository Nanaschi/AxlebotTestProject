using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Circle
{
    [RequireComponent(typeof (CircleMovement))]
    public class CircleInitializer : MonoBehaviour
    {
        private CircleMovement _circleMovement;
        public CircleMovement CircleMovement => _circleMovement;


        public static event Action OnCircleSpawn;

        private void OnEnable()
        {
            OnCircleSpawn?.Invoke();
        }
        public void Initialize(EndPoint endPoint)
        {
            print("Circle awakes!");
            _circleMovement = GetComponent <CircleMovement>();
            _circleMovement.Initialize(endPoint);
        }
    }
}