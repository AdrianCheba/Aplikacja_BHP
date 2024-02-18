using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _informationText;

    [SerializeField]
    TextMeshProUGUI _doorInteractionText;

    [SerializeField]
    TextMeshProUGUI _measurementResultText;

    [SerializeField]
    TextMeshProUGUI _ring;

    [SerializeField]
    Transform _nextLevelScreen;
    
    [SerializeField]
    Transform _deathScreen;

    [SerializeField]
    Image _crossHair;

    [SerializeField]
    PlayerConfig _playerConfig; 
    
    [SerializeField]
    RawImage _deviceScreen;

    internal int PlayerCurrentHP
    {
        get => _playerCurrentHP;
        set 
        { 
            _playerCurrentHP = value;
            if (_playerCurrentHP == 0)
                ShowDeathlScreen();

        }
    }
    int _playerCurrentHP;

    internal bool IsPause
    {
        get => _isPause;
    }
    bool _isPause;

    private void Start()
    {
        _playerCurrentHP = _playerConfig.PlayerHP;
    }

    internal IEnumerator InformationText(string text)
    {
        _informationText.text = text;
        yield return new WaitForSeconds(3f);
        _informationText.text = string.Empty;
    }

    internal IEnumerator SetMeasurementResultText(string text)
    {
        _measurementResultText.text = text;
        yield return new WaitForSeconds(3f);
        _measurementResultText.text = string.Empty;
    }

    internal void SetDoorInteractionText(string text)
    {
        _doorInteractionText.text = text;
    }

    internal void SetCrossHairActie(bool value)
    {
        _crossHair.gameObject.SetActive(value);
    }

    internal void SetRingText(string text) 
    {
        _ring.text = text;
    }

    internal void ShowNextLevelScreen()
    {
        _nextLevelScreen.gameObject.SetActive(true);
        Cursor.visible = true;
        _isPause = true;
    }  
    
    internal void ShowDeathlScreen()
    {
        _isPause = true;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _crossHair.gameObject.SetActive(false);
        _deviceScreen.gameObject.SetActive(false);
        _deathScreen.gameObject.SetActive(true);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
