using System.Collections;
using System.Collections.Generic;
using Circle;
using Environment;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
    {
    [Header("Circle")]
    [SerializeField] CircleMovement _circlePrefab;
    [SerializeField] EndPoint _endPoint;
    [SerializeField] StartingPoint _transform;


    [Header("UI")]
    [SerializeField] private StartButton _startButton;
    [SerializeField] private ResetButton _resetButton;
    [SerializeField] private RestartScreen _restartScreen;
    [SerializeField] private TextMeshProTextData _textMeshProTextData;

        private void OnEnable()
        {
            _startButton.OnButtonClicked += SpawnTheCircle;
            _resetButton.OnResetButtonClicked += ResetTheLevel;


        }

        private void OnDisable()
        {
            _startButton.OnButtonClicked -= SpawnTheCircle;
            _resetButton.OnResetButtonClicked -= ResetTheLevel;
            _circlePrefab.OnVelocityChanged += _textMeshProTextData.UpdateTheGUIText;
    }

         public void SpawnTheCircle()
        {
            _circlePrefab = Instantiate(_circlePrefab, _transform.transform.position, Quaternion.identity);
            _circlePrefab.Initialize(_endPoint);
            _circlePrefab.OnEndPointReached += OpenRestartScreen;
            _circlePrefab.OnVelocityChanged += _textMeshProTextData.UpdateTheGUIText;
        } 


    public void ResetTheLevel()
    {
        print("Reset the level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenRestartScreen()
    {
        _restartScreen.gameObject.SetActive(true);
    }


    }

