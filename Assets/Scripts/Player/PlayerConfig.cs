using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/PlayerConfig")]
class PlayerConfig : ScriptableObject
{
    [SerializeField]
    internal float LaserDistance = 6f;
    [SerializeField]
    internal int InteractableLayer = 6;
    [SerializeField]
    internal int PlayerHP = 3;
    [SerializeField]
    internal float PlayerSpeed = 5f;
    [SerializeField]
    internal float JumpHeighy = 2.0f;
    [SerializeField]
    internal float Gravity = -9.8f;

    internal float OutlineScaleValue = 1.025f;
    internal string EquipmentTag = "Equipment";
    internal string ShelfTag = "Shelf";
    internal string DoorTag = "Door";
    internal string WallTag = "Wall";
    internal readonly string InformationText = "To close the cabinet, you must put the item down. Use right mouse button to do this";
    internal readonly string DoorInformationText = "[F] to open door";
}
