using UnityEngine;

[CreateAssetMenu(fileName = "GameTime", menuName = "ScriptableObjects/GameTime", order = 1)]
public class GameTime : ScriptableObject
{
    [SerializeField] private float time;

    public float Time
    {
        get { return time; }
        set { time = value; }
    }
}
