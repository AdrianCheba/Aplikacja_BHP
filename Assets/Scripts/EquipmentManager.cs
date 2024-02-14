using UnityEngine;

class EquipmentManager : MonoBehaviour
{
    [SerializeField]
    Transform[] _equipment;
    internal void PickObject(Vector3 rayPoint, string equipmentName)
    {
        foreach (Transform gameObject in _equipment)
        {
            if(gameObject.name == equipmentName)
                gameObject.transform.position = rayPoint;
        }
    }
}
