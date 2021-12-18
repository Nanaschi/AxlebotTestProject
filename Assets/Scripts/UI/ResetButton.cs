using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace UI {
    public class ResetButton : MonoBehaviour, IPointerDownHandler
    {

        public event Action OnResetButtonClicked;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnResetButtonClicked?.Invoke();
        }
    }

}
