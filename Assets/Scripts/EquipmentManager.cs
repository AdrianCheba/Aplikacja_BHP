using TMPro;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    internal bool IsItemPicked
    {
        get => _isItemPicked;
        set
        {
            _isItemPicked = value;
        }
    }
    bool _isItemPicked;

    internal Vector3 CurrentItemStartPoint
    {
        get => _currentItemStartPoint;
    }
    Vector3 _currentItemStartPoint;

    internal int EquippedItemCounter
    {
        get => _equippedItemCounter;
        set
        {
            _equippedItemCounter = value;
        }
    }
    int _equippedItemCounter = 0;

    [SerializeField]
    Transform[] _equipment;

    [SerializeField]
    TextMeshProUGUI _informationText;

    Transform _itemParent;
    Transform _currentItem;

    



    internal void PickItem(Vector3 rayPoint, string itemName)
    {
        foreach (Transform gameObject in _equipment)
        {
            if (gameObject.name == itemName)
            {
                if (!_isItemPicked)
                {
                    _currentItemStartPoint = gameObject.position;
                    _currentItem = gameObject;
                    _currentItem.position = rayPoint;
                    _itemParent = _currentItem.parent;
                    _isItemPicked = true;
                    _currentItem.SetParent(null);
                }
                else if (_currentItem.name != itemName && _isItemPicked)
                    _informationText.text = "When selecting another item, the previously selected item must be put back. Use right mouse button to do this";
                else
                {
                    _currentItem.position = rayPoint;
                    _informationText.text = string.Empty;
                }
            }
        }
    }

    internal void RestartPickObjectPosition()
    {
        _currentItem.position = _currentItemStartPoint;
        _currentItem.SetParent(_itemParent);
        _isItemPicked = false;
        _informationText.text = string.Empty;
    }
}
