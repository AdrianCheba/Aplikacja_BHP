using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _informationText;

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

    internal void GoToNextLevel()
    {
        _panel.gameObject.SetActive(true);
        _isPause = true;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    void CleanInformation() { _informationText.text = string.Empty; }
}
