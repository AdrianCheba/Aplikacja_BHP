using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

class PlayerInteractions : MonoBehaviour
{
    [SerializeField]
    PlayerConfig _playerConfig;

    [SerializeField]
    ShelfManager _shelfManager;

    [SerializeField]
    EquipmentManager _equipmentManager;

    [SerializeField]
    UIManager _uiManager;
    
    InputManager _inputManager;
    LineRenderer _lineRenderer;
    Transform _hitTransform;
    Material[] _materials;
    static readonly int _outlineScale = Shader.PropertyToID("_OutlineScale");

    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Scene1")) 
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.SetPosition(0, transform.position);
        }
        _inputManager = GetComponent<InputManager>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(_uiManager.IsPause)
            return;

        if (_hitTransform != null && _materials != null)
        {
            foreach (Material mat in _materials)
                mat.SetFloat(_outlineScale, 1f);
            _hitTransform = null;
            _uiManager.SetDoorInteractionText(string.Empty);
        }

        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
            _lineRenderer.SetPosition(1, ray.GetPoint(_playerConfig.LaserDistance));

        if (Physics.Raycast(ray, out RaycastHit hit, _playerConfig.LaserDistance))
        {
            if (hit.transform.gameObject.layer == _playerConfig.InteractableLayer)
            {
                _hitTransform = hit.transform;
                Renderer renderer = _hitTransform.GetComponent<Renderer>();
                _materials = renderer.materials;

                foreach (Material mat in _materials)
                    mat.SetFloat(_outlineScale, _playerConfig.OutlineScaleValue);

                if (_hitTransform.CompareTag(_playerConfig.DoorTag))
                {
                    _uiManager.SetDoorInteractionText(_playerConfig.DoorInformationText);

                    if(_inputManager.Gameplay.Measurement.triggered)
                        _uiManager.SetMeasurementResultText(_hitTransform.GetComponent<DoorManager>().MeasurementResult.ToString());
                }

                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    if (_hitTransform.CompareTag(_playerConfig.ShelfTag))
                        if (!_equipmentManager.IsItemPicked)
                        {
                            _shelfManager.ToggleSwitch(_hitTransform.name);
                        }
                        else
                            _uiManager.InformationText(_playerConfig.InformationText);
                };

                if (Mouse.current.leftButton.isPressed)
                    if (_hitTransform.CompareTag(_playerConfig.EquipmentTag))
                        _equipmentManager.PickItem(ray.GetPoint(_playerConfig.LaserDistance), _hitTransform.name);

                if (Mouse.current.rightButton.wasPressedThisFrame)
                    if (_hitTransform.CompareTag(_playerConfig.EquipmentTag))
                        if (_equipmentManager.IsItemPicked)
                            _equipmentManager.RestartPickObjectPosition();

            }
        }
    }
}

   

