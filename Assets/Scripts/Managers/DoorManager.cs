using UnityEngine;

class DoorManager : MonoBehaviour
{
    internal int MeasurementResult
    {
        get => _measurementResult; 
        set 
        { 
            _measurementResult = value; 
        }

    }
    int _measurementResult;

    void Start()
    {
        _measurementResult = Random.Range(1, 9);
    }
}
