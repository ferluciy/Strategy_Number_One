using Abstractions;
using System;
using UnityEngine;
using Zenject;

namespace Strategy
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/"
+ nameof(Vector3Value), order = 0)]
public class Vector3Value : ScriptableObjectValueBase<Vector3>
    {

}
}