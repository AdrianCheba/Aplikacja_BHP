using System.Collections;
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
    TextMeshProUGUI _ring;

    [SerializeField]
    Transform _panel;

    [SerializeField]
    Image _crossHair;

    internal bool IsPause
    {
        get => _isPause;
    }
    bool _isPause;

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

}
