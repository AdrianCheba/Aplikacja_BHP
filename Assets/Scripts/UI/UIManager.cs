using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _informationText;

    [SerializeField]
    TextMeshProUGUI _doorInteractionText;
    
    [SerializeField]
    TextMeshProUGUI _measurementResultText;

    [SerializeField]
    Transform _panel;

    internal bool IsPause
    {
        get => _isPause;
    }
    bool _isPause;

    internal void InformationText(string text)
    {
        _informationText.text = text;
        Invoke(nameof(CleanInformation), 3f);
    }

    internal void SetDoorInteractionText(string text)
    {
        _doorInteractionText.text = text;
    }

    internal void SetMeasurementResultText(string text) 
    {
        _measurementResultText.text = text;
    }

    internal void GoToNextLevel()
    {
        _panel.gameObject.SetActive(true);
        Cursor.visible = true;
        _isPause = true;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void CleanInformation() { _informationText.text = string.Empty; }
}
