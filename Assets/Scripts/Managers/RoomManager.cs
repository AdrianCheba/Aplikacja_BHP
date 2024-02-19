using UnityEngine;

class RoomManager : MonoBehaviour
{
    [SerializeField]
    Transform[] _walls;

    [SerializeField]
    ResultsManager _resultsManager;

    int _wallsHitedOnes;
    bool _achievedRoom;
    readonly string WallTag = "Wall";
    readonly string UntaggedTag= "Untagged";
    readonly string PlayerTag= "Player";

    internal void CheckWalls()
    {
        foreach(Transform wall in _walls)
        {
            if (wall.GetComponent<WallManager>().IsHitCorrectly)
                _wallsHitedOnes++;
            
            if(wall.GetComponent<WallManager>().IsHitManyTimes)
                _resultsManager.WallsHitedManyTimes++;

            if(wall.GetComponent<WallManager>().IsHitOnes == false)
                _resultsManager.MissedWalls++;

            if (wall.GetComponent<WallManager>().InvalidRingValue)
                _resultsManager.InvalidRingValue++;
        }

        if (_wallsHitedOnes == 6)
            _resultsManager.CorrectRooms++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
            foreach (Transform wall in _walls)
            {
                wall.tag = WallTag;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PlayerTag))
            foreach (Transform wall in _walls)
            {
                wall.tag = UntaggedTag;
                if (!_achievedRoom)
                {
                    _achievedRoom = true;
                    _resultsManager.AchievedRooms++;
                }
            }
    }
}
