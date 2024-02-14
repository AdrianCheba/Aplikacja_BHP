using UnityEngine;

class ShelfManager : MonoBehaviour
{
    [SerializeField]
    Transform[] _shelves;


    int _activeShelfID = -1;

    internal void ToggleEnable(string shelfName)
    {
        if (_activeShelfID == -1)
        {
            if (shelfName == _shelves[0].name)
            {
                _shelves[0].GetChild(0).gameObject.SetActive(isActiveAndEnabled);
                _activeShelfID = 0;
            }
            else if (shelfName == _shelves[1].name)
            {
                _shelves[1].GetChild(0).gameObject.SetActive(isActiveAndEnabled);
                _activeShelfID = 1;
            }
            else
            {
                _shelves[2].GetChild(0).gameObject.SetActive(isActiveAndEnabled);
                _activeShelfID = 2;
            }
        }
        else if (shelfName == _shelves[_activeShelfID].name)
        {
            _shelves[_activeShelfID].GetChild(0).gameObject.SetActive(!isActiveAndEnabled);
            _activeShelfID = -1;
        }
        else
            Debug.Log("Only one shelf should be open, current open shelf : " + _activeShelfID);

    }
}
