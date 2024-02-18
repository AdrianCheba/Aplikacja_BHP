using UnityEngine;

class ResultsManager : MonoBehaviour
{
    internal int IncorrectlyNeutralizedDoors
    {
        get => _incorrectlyNeutralizedDoors;
        set => _incorrectlyNeutralizedDoors = value;
    }
    [SerializeField]
    int _incorrectlyNeutralizedDoors;

    internal int CorrectlyNeutralizedDoors
    {
        get => _correctlyNeutralizedDoors;
        set => _correctlyNeutralizedDoors = value;
    }
    [SerializeField]
    int _correctlyNeutralizedDoors;

    internal int NoMeasurements 
    {
        get => _noMeasurements; 
        set => _noMeasurements = value;
    }
    [SerializeField]
    int _noMeasurements;

    internal int TooHighNeutralization
    {
        get => _tooHighNeutralization;
        set => _tooHighNeutralization = value;
    }
    [SerializeField]
    int _tooHighNeutralization;

    internal int TooLowNeutralization
    {
        get => _tooLowNeutralization;
        set => _tooLowNeutralization = value;
    }
    [SerializeField]
    int _tooLowNeutralization;
}
