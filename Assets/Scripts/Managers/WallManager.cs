using System.Net.NetworkInformation;
using UnityEngine;

class WallManager : MonoBehaviour
{
    internal bool IsHitCorrectly
    {
        get => _isHitCorrectly;
    }
    bool _isHitCorrectly;

    internal bool IsHitOnes
    {
        get => _isHitOnes;
    }
    bool _isHitOnes;
    
    internal bool IsHitManyTimes
    {
        get => _isHitManyTimes;
    }
    bool _isHitManyTimes;

    internal bool InvalidRingValue
    {
        get => _invalidRingValue;
    }
    bool _invalidRingValue;

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
            {
                _isHitCorrectly = false;
                _isHitManyTimes = true;
            }
        }
        else
        {
            _isHitOnes = true;
            _isHitCorrectly = false;
            _invalidRingValue = true;
        }
    }
}
