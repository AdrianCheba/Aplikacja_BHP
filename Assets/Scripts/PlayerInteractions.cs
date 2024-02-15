using TMPro;
using UnityEngine;

class PlayerInteractions : MonoBehaviour
{
    [SerializeField]
    PlayerConfig _playerConfig;

    [SerializeField]
    ShelfManager _shelfManager;

    [SerializeField]
    EquipmentManager _equipmentManager;

    [SerializeField]
    TextMeshProUGUI _informationText;

    LineRenderer _lineRenderer;
    Transform _hitTransform;
    Material[] _materials;
    static readonly int _outlineScale = Shader.PropertyToID("_OutlineScale");

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.SetPosition(0, transform.position);
    }

    void Update()
    {
        if (_hitTransform != null && _materials != null)
        {
            foreach (Material mat in _materials)
                mat.SetFloat(_outlineScale, 1f);
            _hitTransform = null;
        }

        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        _lineRenderer.SetPosition(1, ray.GetPoint(_playerConfig.LaserDistance));

        if (Physics.Raycast(ray, out RaycastHit hit, _playerConfig.LaserDistance))
        {
            if (hit.transform.gameObject.layer == _playerConfig.InteractableLayer)
            {
                _hitTransform = hit.transform;
                Renderer renderer = _hitTransform.GetComponent<Renderer>();
                _materials = renderer.materials;

                foreach (Material mat in _materials)
                    mat.SetFloat(_outlineScale, 1.025f);

                if (Input.GetMouseButtonDown(0))
                {
                    if (!_equipmentManager.IsItemPicked)
                    {
                        if (_hitTransform.CompareTag(_playerConfig.ShelfTag))
                            _shelfManager.ToggleEnable(_hitTransform.name);
                    }
                    else
                        _informationText.text = "To close the cabinet, you must put the item down. Use right mouse button to do this";

                }

                if (Input.GetMouseButton(0))
                    if (_hitTransform.CompareTag(_playerConfig.EquipmentTag))
                        _equipmentManager.PickItem(ray.GetPoint(_playerConfig.LaserDistance), _hitTransform.name);

                if (Input.GetMouseButtonDown(1))
                    if (_hitTransform.CompareTag(_playerConfig.EquipmentTag))
                        if (_equipmentManager.IsItemPicked)
                            _equipmentManager.RestartPickObjectPosition();

            }
        }
    }
}

   

