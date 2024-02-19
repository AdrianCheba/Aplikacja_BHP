using UnityEngine;

class ItemSlotManager : MonoBehaviour
{
    [SerializeField]
    EquipmentManager _equipmentManager;

    [SerializeField]
    Transform[] _acceptableEquipment;

    [SerializeField]
    UIManager _uiManager;

    static readonly string InformationText = "This item does not belong here";

    private void OnTriggerEnter(Collider other)
    {
        foreach (Transform item in _acceptableEquipment) 
        {
            if (item.name == other.name)
            {       
                _equipmentManager.IsItemPicked = false;
                _equipmentManager.EquippedItemCounter++;
                other.gameObject.SetActive(false);
                StartCoroutine(_uiManager.InformationText(string.Empty));
                break;
            }
            else
                StartCoroutine(_uiManager.InformationText(InformationText));
        }
    }
}
