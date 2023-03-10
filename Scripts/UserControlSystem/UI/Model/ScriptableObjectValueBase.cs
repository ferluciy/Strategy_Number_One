using System;
using UnityEngine;

namespace Strategy
{
public abstract class ScriptableObjectValueBase<T> : ScriptableObject
{
    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;
    public void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }
}

}