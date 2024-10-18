using UnityEngine;
using System;

[CreateAssetMenu(fileName = "LifeEvent", menuName = "Events/Life Event")]
public class LifeEvent : ScriptableObject
{
    public Action<int> OnLifeChanged;  
    public void Raise(int newLife)
    {
        if (OnLifeChanged != null)
        {
            OnLifeChanged(newLife);  
        }
    }
}
