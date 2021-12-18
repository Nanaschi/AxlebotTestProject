using System.Collections;
using System.Collections.Generic;
using Circle;
using Environment;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
    {
    [Header("Circle")] //Instead of Player  Manager. Normally it should be devided to avoid "God Class"
    [SerializeField] private CircleMovement _circlePrefab;
    [SerializeField] private EndPoint _endPoint;
    [SerializeField] private StartingPoint _transform;
    [Header("Cursor")] 
    [SerializeField] private CursorBehaviour _cursorBehaviour;

    [Header("UI")] //Instead of UI Manager
    [SerializeField] private StartButton _startButton;
    [SerializeField] private ResetButton _resetButton;
    [Space]
    [SerializeField] private RestartScreen _restartScreen;
    [SerializeField] private TextMeshProTextData _textMeshProTextData;
    [Space]
    [SerializeField] private SliderBehaviour _maximumSpeedSlider;
    [SerializeField] private SliderBehaviour _cursorRadiusSlider;
    [SerializeField] private SliderBehaviour _accelerationSpeedSlider;


    private void OnEnable()
    {
            _startButton.OnButtonClicked += SpawnTheCircle;
            _resetButton.OnResetButtonClicked += ResetTheLevel;

        _cursorRadiusSlider.Slider.onValueChanged.AddListener((v) =>
        {
            _cursorBehaviour.SetRadiusOfTheZone(_cursorRadiusSlider.GetSliderValue());
        });
    }

        private void OnDisable()
        {
            _startButton.OnButtonClicked -= SpawnTheCircle;
            _resetButton.OnResetButtonClicked -= ResetTheLevel;
            _circlePrefab.OnVelocityChanged -= _textMeshProTextData.UpdateTheGUIText;
    }

         public void SpawnTheCircle() // instead of Factory class (because of the small project size)
        {
            _circlePrefab = Instantiate(_circlePrefab, _transform.transform.position, Quaternion.identity);
            _circlePrefab.Initialize(_endPoint);
            _circlePrefab.OnEndPointReached += OpenRestartScreen;
            _circlePrefab.OnVelocityChanged += _textMeshProTextData.UpdateTheGUIText;
            AllowSlidersChangeValues(_circlePrefab);
        } 

    public void ResetTheLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenRestartScreen()
    {
        _restartScreen.gameObject.SetActive(true);
    }


    public void AllowSlidersChangeValues (CircleMovement circlePrefab)
    {
        _maximumSpeedSlider.Slider.onValueChanged.AddListener((v) =>
        {
            circlePrefab.SetMaximumSpeed(_maximumSpeedSlider.GetSliderValue());
        });

        _accelerationSpeedSlider.Slider.onValueChanged.AddListener((v) =>
        {
            circlePrefab.SetAccelerationSpeed(_accelerationSpeedSlider.GetSliderValue());
        });
    }


    }

