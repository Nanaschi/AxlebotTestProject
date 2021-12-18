using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Circle
{
    [RequireComponent(typeof (CircleMovement))]
    public class CircleInitializer : MonoBehaviour 
        //this class exists just in case in the future Circle has many components in addition to CircleMovement
    {
        private CircleMovement _circleMovement;

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