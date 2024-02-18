using UnityEngine;

class WallManager : MonoBehaviour
{
    internal bool IsHitCorrectly
    {
        get => _isHitCorrectly;
    }
    [SerializeField]
    bool _isHitCorrectly;

    internal bool IsHitOnes
    {
        get => _isHitOnes;
    }
    [SerializeField]
    bool _isHitOnes;

    internal void HitWall(int ringValue)
    {
        if (ringValue == 0)
        {
            if (!_isHitOnes)
            {
                _isHitOnes = true;
                _isHitCorrectly = true;
            }
            else
                _isHitCorrectly = false;
        }
        else
        {
            _isHitOnes = true;
            _isHitCorrectly = false;
        }
    }
}
