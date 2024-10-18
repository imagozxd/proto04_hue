using System;
using UnityEngine;
[CreateAssetMenu(fileName = "Handler", menuName = "ScriptableObject/HandlerData", order = 1)]

public class HandlerEventoSO : ScriptableObject
{
    public event Action OnVoidEvent;
    public void Raise()
    {
        OnVoidEvent?.Invoke();
    }
}
