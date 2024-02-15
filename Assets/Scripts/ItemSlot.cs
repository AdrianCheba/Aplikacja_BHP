using System.Collections;
using UnityEngine;

class ItemSlot : MonoBehaviour
{
    [SerializeField]
    EquipmentManager _equipmentManager;

    [SerializeField]
    Transform[] _acceptableEquipment;

    Vector3 _itemStartPosition;

    private void OnTriggerEnter(Collider other)
    {
        foreach (Transform item in _acceptableEquipment)
            if(other.name == item.name)
            {
                _equipmentManager.IsItemPicked = false;
                _itemStartPosition = _equipmentManager.CurrentItemStartPoint;
                _equipmentManager.EquippedItemCounter++;
                other.gameObject.SetActive(false);
            }
    }
}
