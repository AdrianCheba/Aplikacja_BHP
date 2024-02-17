using UnityEngine;

class DoorManager : MonoBehaviour
{  
    internal int MeasurementResult
    {
        get => _measurementResult; 
        set => _measurementResult = value; 
    }
    int _measurementResult; 

    readonly int _measurementMinValue = 1;
    readonly int _measurementMaxValue = 9;

    void Start()
    {
        _measurementResult = Random.Range(_measurementMinValue, _measurementMaxValue);
    }
}
