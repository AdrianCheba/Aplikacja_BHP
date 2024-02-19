using TMPro;
using UnityEngine;

class ResultsUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] _resultsText;

    [SerializeField]
    Canvas _ui;

    [SerializeField]
    ResultsManager _resultsManager;

    internal void ShowResults()
    {
        _ui.enabled = false;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        float timeSinceLoad = Time.timeSinceLevelLoad;
        int minutes = Mathf.FloorToInt(timeSinceLoad / 60);
        int seconds = Mathf.FloorToInt(timeSinceLoad % 60);

        if(seconds >= 10) 
            _resultsText[0].text = "Operating time " + "0" + minutes + ":" + seconds;
        else
            _resultsText[0].text = "Operating time " + "0" + minutes + ":" + "0" + seconds;
 

        _resultsText[1].text = "Correctly neutralized doors : " + _resultsManager.CorrectlyNeutralizedDoors;
        _resultsText[2].text = "Correctly neutralized rooms : " + _resultsManager.CorrectRooms;
        _resultsText[3].text = "No measurement taken : " + _resultsManager.NoMeasurements;
        _resultsText[4].text = "Too high gun's ring value to neutralized doors : " + _resultsManager.TooHighNeutralization;
        _resultsText[5].text = "Too low gun's ring value to neutralized doors : " + _resultsManager.TooLowNeutralization;
        _resultsText[6].text = "Invalid ring value in rooms : " + _resultsManager.InvalidRingValue;
        _resultsText[7].text = "Missed walls in rooms : " + _resultsManager.MissedWalls;
        _resultsText[8].text = "Walls hited many times : " + _resultsManager.WallsHitedManyTimes;
    }

}
