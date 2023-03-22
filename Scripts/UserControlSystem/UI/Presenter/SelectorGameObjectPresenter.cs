using Abstractions;
using Strategy;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class SelectorGameObjectPresenter : MonoBehaviour
{
    [Inject] private IObservable<ISelectable> _selectedValues;
    private SelectorObjectGame[] _selectors;
    private ISelectable _currentSelectable;
    private void Start()
    {
        _selectedValues.Subscribe(onSelected);
    }
    private void onSelected(ISelectable selectable)
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
