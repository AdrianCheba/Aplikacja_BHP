using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/PlayerConfig")]
class PlayerConfig : ScriptableObject
{
    [SerializeField]
    internal float LaserDistance = 6f;
    [SerializeField]
    internal int InteractableLayer = 6;
    internal float OutlineScaleValue = 1.025f;
    internal string EquipmentTag = "Equipment";
    internal string ShelfTag = "Shelf";
    internal readonly string InformationText = "To close the cabinet, you must put the item down. Use right mouse button to do this";
}
