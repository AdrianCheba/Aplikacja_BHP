using UnityEngine;

class ResultsManager : MonoBehaviour
{
    internal int AchievedRooms
    {
        get => _achievedRooms;
        set
        {
            _achievedRooms = value;
            if(_achievedRooms + IncorrectlyNeutralizedDoors == _roomManager.Length)
            {
                foreach (RoomManager room in _roomManager)
                {
                    room.CheckWalls();
                    _resultsUI.gameObject.SetActive(true);
                    _resultsUI.ShowResults();
                }
            }
        }
    }
    int _achievedRooms;

    internal int IncorrectlyNeutralizedDoors
    {
        get => _incorrectlyNeutralizedDoors;
        set
        {
            _incorrectlyNeutralizedDoors = value;
            if (_achievedRooms + IncorrectlyNeutralizedDoors == _roomManager.Length)
            {
                foreach (RoomManager room in _roomManager)
                {
                    room.CheckWalls();
                    _resultsUI.gameObject.SetActive(true);
                    _resultsUI.ShowResults();
                }
            }
        }
    }
    int _incorrectlyNeutralizedDoors;
    internal int CorrectlyNeutralizedDoors;
    internal int NoMeasurements;
    internal int TooHighNeutralization;
    internal int TooLowNeutralization;
    internal int CorrectRooms;
    internal int InvalidRingValue;
    internal int MissedWalls;
    internal int WallsHitedManyTimes;

    [SerializeField]
    RoomManager[] _roomManager;

    [SerializeField]
    ResultsUI _resultsUI;
}
