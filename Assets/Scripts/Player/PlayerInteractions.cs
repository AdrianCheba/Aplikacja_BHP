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

    [SerializeField]
    RoomManager _roomManager;
    
    InputManager _inputManager;
    LineRenderer _lineRenderer;
    Transform _hitTransform;
    Material[] _materials;

    internal int RingValue
    {
        get => _ringValue;
        set => _ringValue = Mathf.Clamp(value, 0, 9);
    }
    int _ringValue;

    static readonly int _outlineScale = Shader.PropertyToID("_OutlineScale");

    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        Cursor.visible = false;
        RingValue = 0;
        _uiManager.SetRingText(RingValue.ToString());

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Scene1"))
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.SetPosition(0, transform.position);
        }
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public bool IsScrollUp()
    {
        float value = _inputManager.Gameplay.MouseScroll.ReadValue<float>();
        return value > 0.1f;
    }   
    public bool IsScrollDown()
    {
        float value = _inputManager.Gameplay.MouseScroll.ReadValue<float>();
        return value < -0.1f;
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
        
        if (IsScrollUp())
        {
            RingValue++;
            _uiManager.SetRingText(RingValue.ToString());
        }
        else if (IsScrollDown())
        {
            RingValue--;
            _uiManager.SetRingText(RingValue.ToString());
        }

        if (Physics.Raycast(ray, out RaycastHit hit, _playerConfig.LaserDistance))
        {          
            if (hit.transform.CompareTag(_playerConfig.WallTag))
            {
                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    hit.transform.GetComponent<WallManager>().HitWall(_ringValue);
                }
            }

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

                    if (_inputManager.Gameplay.Measurement.triggered)
                    {
                        if (!_hitTransform.GetComponent<DoorManager>().FirstCheck)
                            _hitTransform.GetComponent<DoorManager>().FirstCheck = true;
                        else
                            _hitTransform.GetComponent <DoorManager>().SecondCheck = true;

                        StartCoroutine(_uiManager.SetMeasurementResultText(_hitTransform.GetComponent<DoorManager>().MeasurementResult.ToString()));
                    }

                    if (_inputManager.Gameplay.OpenDoor.triggered)
                    {
                        _hitTransform.GetComponent<DoorManager>().OpenDoor();
                    }
                }

                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    if (_hitTransform.CompareTag(_playerConfig.ShelfTag))
                        if (!_equipmentManager.IsItemPicked)
                        {
                            _shelfManager.ToggleSwitch(_hitTransform.name);
                        }
                        else
                            StartCoroutine(_uiManager.InformationText(_playerConfig.InformationText));

                    if (_hitTransform.CompareTag(_playerConfig.DoorTag))
                        _hitTransform.GetComponent<DoorManager>().MeasurementResult -= RingValue;
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

   

