using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private ScoreEvent scoreEvent;  
    [SerializeField] private Text scoreText;  

    private void OnEnable()
    {
        scoreEvent.OnScoreChange += UpdateScoreUI; 
    }

    private void OnDisable()
    {
        scoreEvent.OnScoreChange -= UpdateScoreUI; 
    }

    private void UpdateScoreUI(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();  
    }
}
