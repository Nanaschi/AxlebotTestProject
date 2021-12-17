using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


    public class StartButton : MonoBehaviour, IPointerDownHandler
    {

        public event Action OnButtonClicked; 

        public void OnPointerDown(PointerEventData eventData)
        {
            OnButtonClicked?.Invoke();
            gameObject.SetActive(false);
        }
    }

