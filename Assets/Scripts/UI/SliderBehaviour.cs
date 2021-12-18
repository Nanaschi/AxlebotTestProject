using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace UI
{
    [RequireComponent(typeof(Slider))]
    public class SliderBehaviour : MonoBehaviour
    {
        private Slider _slider;
        public Slider Slider => _slider;
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

        private void OnEnable()
        {
            VisualValueReperesentation();
        }

        private void OnValidate()
        {
            _slider = GetComponent<Slider>();
        }

        private void VisualValueReperesentation()
        {
            _slider.onValueChanged.AddListener((sliderValue) =>
            {
                _textMeshProUGUI.text = (Math.Round(sliderValue, 3)).ToString();
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
}