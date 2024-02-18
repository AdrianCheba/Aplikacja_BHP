using UnityEngine;

class RoomManager : MonoBehaviour
{
    internal bool CorrectRoom
    {
        get => _correctRoom;
    }
    [SerializeField]
    bool _correctRoom;
    internal int WallsHitedMore
    {
        get => _wallsHitedMore;
    }
    internal int _wallsHitedMore;

    internal int WallsMissed
    {
        get=> _wallsMissed;
    }
    int _wallsMissed;

    [SerializeField]
    Transform[] _walls;

    [SerializeField]
    GameObject _door;

    int _wallsHitedOnes;
    readonly string WallTag = "Wall";


    void Update()
    {
        if (!_door.activeSelf)
            foreach (Transform wall in _walls)
            {
                wall.tag = WallTag;
            }
    }

    internal void CheckWalls()
    {
        foreach(Transform wall in _walls)
        {
            if (wall.GetComponent<WallManager>().IsHitCorrectly)
                _wallsHitedOnes++;
            else if(!wall.GetComponent<WallManager>().IsHitCorrectly)
                _wallsHitedMore++;
            else if(!wall.GetComponent<WallManager>().IsHitOnes)
                _wallsMissed++;
        }

        if (_wallsHitedOnes == 6)
            _correctRoom = true;
        else
            _correctRoom = false;
    }
}
