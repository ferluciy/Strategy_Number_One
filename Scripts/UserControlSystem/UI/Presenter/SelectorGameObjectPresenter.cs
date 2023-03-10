using Abstractions;
using Strategy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorGameObjectPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    private SelectorObjectGame[] _selectors;
    private ISelecatable _currentSelectable;
    private void Start()
    {
        _selectable.OnNewValue += onSelected;
        onSelected(_selectable.CurrentValue);
    }
    private void onSelected(ISelecatable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;
        setSelected(_selectors, false);
        _selectors = null;

    if (selectable != null)
        {
            _selectors = (selectable as
            Component).GetComponentsInParent<SelectorObjectGame>();
            setSelected(_selectors, true);
        }
        static void setSelected(SelectorObjectGame[] selectors, bool value)
        {
            if (selectors != null)
            {
                for (int i = 0; i < selectors.Length; i++)
                {
                    selectors[i].SetSelected(value);
                }
            }
        }
    }
}
