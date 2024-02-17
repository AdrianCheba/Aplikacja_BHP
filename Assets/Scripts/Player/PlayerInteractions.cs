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
    int _ringValue;
    static readonly int _outlineScale = Shader.PropertyToID("_OutlineScale");

    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        Cursor.visible = false;
        _ringValue = 0;
        _uiManager.SetRingText(_ringValue.ToString());

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Scene1"))
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.SetPosition(0, transform.position);
            _uiManager.SetCrossHairActie(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            _uiManager.SetCrossHairActie(true);
        }
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
            _ringValue++;
            _uiManager.SetRingText(_ringValue.ToString());
        }
        else if (IsScrollDown())
        {
            _ringValue--;
            _uiManager.SetRingText(_ringValue.ToString());
        }

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
                        StartCoroutine(_uiManager.SetMeasurementResultText(_hitTransform.GetComponent<DoorManager>().MeasurementResult.ToString()));
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
                        _hitTransform.GetComponent<DoorManager>().MeasurementResult -= _ringValue;
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

   

