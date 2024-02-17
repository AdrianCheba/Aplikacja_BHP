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
    UIManager _uiManager;

    Vector3 _currentItemStartPoint;
    Transform _itemParent;
    Transform _currentItem;

    static readonly string InformationText = "When selecting another item, the previously selected item must be put back. Use right mouse button to do this";

    private void Update()
    {
        if(_equippedItemCounter == 9)
        {
            _uiManager.GoToNextLevel();
        }
    }


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
                    _uiManager.InformationText(InformationText);
                else
                {
                    _currentItem.position = rayPoint;
                }
            }
        }
    }

    internal void RestartPickObjectPosition()
    {
        _currentItem.position = _currentItemStartPoint;
        _currentItem.SetParent(_itemParent);
        _isItemPicked = false;
    }
}
