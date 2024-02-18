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
                }
            }
        }
    }
    [SerializeField]
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
                }
            }
        }
    }
    [SerializeField]
    int _incorrectlyNeutralizedDoors;

    [SerializeField]
    internal int CorrectlyNeutralizedDoors;
    [SerializeField]
    internal int NoMeasurements;
    [SerializeField]
    internal int TooHighNeutralization;
    [SerializeField]
    internal int TooLowNeutralization;
    [SerializeField]
    internal int CorrectRooms;
    [SerializeField]
    internal int InvalidRingValue;
    [SerializeField]
    internal int MissedWalls;
    [SerializeField]
    internal int WallsHitedManyTimes;

    [SerializeField]
    RoomManager[] _roomManager;
}
