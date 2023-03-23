using UnityEngine;

namespace Strategy { 
public class SelectorObjectGame : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private bool _isSelectedCache;
    public void SetSelected(bool isSelected)
    {
            if (this == null)
            {
                return;
                    }
        if (isSelected == _isSelectedCache)
        {
            return;
        }
        _effect.SetActive(isSelected);
        _isSelectedCache = isSelected;
    }
}

}

