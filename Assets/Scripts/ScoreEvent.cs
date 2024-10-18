using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ScoreEvent", menuName = "Events/Score Event")]
public class ScoreEvent : ScriptableObject
{
    public Action<int> OnScoreChange;  
    public void Raise(int newScore)
    {
        if (OnScoreChange != null)
        {
            OnScoreChange(newScore);  
        }
    }
}
