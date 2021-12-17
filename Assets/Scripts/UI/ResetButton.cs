using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetButton : MonoBehaviour, IPointerDownHandler
{

    public event Action OnResetButtonClicked;

    public void OnPointerDown(PointerEventData eventData)
    {
        print("OnResetButtonClicked");
        OnResetButtonClicked?.Invoke();
    }


}
