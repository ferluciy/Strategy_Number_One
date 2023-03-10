using Abstractions;
using System;
using UnityEngine;
using Zenject;

namespace Strategy
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" +
nameof(SelectableValue), order = 0)]
public class SelectableValue : ScriptableObjectValueBase<ISelecatable>
    {

}
}