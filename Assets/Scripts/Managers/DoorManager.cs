using UnityEngine;

class DoorManager : MonoBehaviour
{
    internal int MeasurementResult
    {
        get => _measurementResult;
        set
        {
            if (_firstCheck && !_areNeutralized)
            {
                _measurementResult = value;

                if (_measurementResult == 0)
                    _areNeutralized = true;

                else if(_measurementResult < 0)
                {
                    BurningDoor();
                    _resultManager.TooHighNeutralization++;
                }
                else
                {
                    BurningDoor();
                    _resultManager.TooLowNeutralization++;
                }
            }
            else if (_areNeutralized)
            {
                _resultManager.TooHighNeutralization++;
                BurningDoor();
            }
            else
            {
                _resultManager.NoMeasurements++;
                BurningDoor();
            }
        }
    }
    int _measurementResult;

    internal bool FirstCheck
    {
        get => _firstCheck;
        set => _firstCheck = value;
    }
    bool _firstCheck;

    internal bool SecondCheck
    {
        get => _secondCheck;
        set => _secondCheck = value;
    }
    bool _secondCheck;

    [SerializeField]
    ResultsManager _resultManager;
    [SerializeField]
    ParticleSystem _particleSystem;
    [SerializeField]
    UIManager _uiManager;

    bool _areNeutralized;
    
    readonly int MeasurementMinValue = 1;
    readonly int MeasurementMaxValue = 10;
    readonly int DefaultLayer = 0;
    readonly string CurrentHPInformation = "Player current HP: ";

    void Start()
    {
        _measurementResult = Random.Range(MeasurementMinValue, MeasurementMaxValue);
    }

    internal void OpenDoor()
    {
        if (_firstCheck)
        {
            if (_secondCheck && _measurementResult == 0)
            {
                gameObject.SetActive(false);
                _resultManager.CorrectlyNeutralizedDoors++;
            }
            else
            {
                _resultManager.NoMeasurements++;
                BurningDoor();
            }
        }
        else
        {
            _resultManager.NoMeasurements++;
            BurningDoor();
        }
    }

    void BurningDoor()
    {
        _resultManager.IncorrectlyNeutralizedDoors++;
        _uiManager.PlayerCurrentHP--;
        StartCoroutine(_uiManager.InformationText(CurrentHPInformation + _uiManager.PlayerCurrentHP));
        _particleSystem.gameObject.SetActive(true);
        _particleSystem.Play();
        gameObject.layer = DefaultLayer;
    }
}
