using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/PlayerConfig")]
class PlayerConfig : ScriptableObject
{
    [SerializeField]
    internal float LaserDistance = 8f;
    [SerializeField]
    internal int InteractableLayer = 6;
    internal string EquipmentTag = "Equipment";
    internal string ShelfTag = "Shelf";
}
