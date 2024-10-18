using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasGame : MonoBehaviour
{
    [SerializeField] private GameTime gameTime;
    [SerializeField] private Text timeText;
    [SerializeField] private Text vidaText;
    [SerializeField] private Button testButton;
    [SerializeField] private PlayerHUE player; 
    private float elapsedTime; 
    private bool isTimerRunning; 

    [SerializeField] private ScoreEvent scoreEvent; 
    private int score = 0; 

    private void Start()
    {
        elapsedTime = 0f;
        isTimerRunning = true;

        testButton.onClick.AddListener(OnTestButtonClicked);

        UpdateTimeText();
        UpdateVidaText();

        
        score = 0;
        scoreEvent.Raise(score); 
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimeText();

            
            IncrementScore(1);
        }

        // Actualizar la vida en el texto
        UpdateVidaText();
    }

    // Función que incrementa el score y dispara el evento
    private void IncrementScore(int amount)
    {
        score += amount;
        scoreEvent.Raise(score); // Disparar el evento cuando se actualice el score
    }

    private void UpdateTimeText()
    {
        timeText.text = $"Tiempo: {elapsedTime:F2} segundos";
    }

    private void UpdateVidaText()
    {
        if (player != null)
        {
            vidaText.text = "Vida: " + player.Vida;
        }
    }

    private void OnTestButtonClicked()
    {
        isTimerRunning = false;

        gameTime.Time = elapsedTime;

        SceneManager.LoadScene("FinalScene");
    }
}

