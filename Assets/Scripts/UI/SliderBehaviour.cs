using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class SliderBehaviour : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    private float _sliderValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        VisualValueReperesentation();
    }

    private void Update()
    {
        print(GetSliderValue());
    }

    private void VisualValueReperesentation()
    {
        var Fdds = _slider.onValueChanged;
        
        _slider.onValueChanged.AddListener((sliderValue) =>
        {
            _textMeshProUGUI.text = (Math.Round(sliderValue, 2)).ToString();
        });
    }

    public float GetSliderValue()
    {
        return _slider.value;
    }

    public float SetMaxVaalue(int maxValue)
    {
        _slider.maxValue = maxValue;
        return 2;
    }

    public void SetHealth(int currentHealth)
    {
        _slider.value = currentHealth;
    }

}
