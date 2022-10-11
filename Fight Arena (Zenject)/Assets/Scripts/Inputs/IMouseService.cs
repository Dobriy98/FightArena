using System;
using UnityEngine;

namespace Inputs
{
    public interface IMouseService
    {
        event Action<Vector3> OnEnvironmentRightClick;
        event Action OnEnvironmentLeftClick;
    }
}