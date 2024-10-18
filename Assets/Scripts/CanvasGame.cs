using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasGame : MonoBehaviour
{
    [SerializeField] private GameTime gameTime;
    [SerializeField] private Text timeText;
    [SerializeField] private Text vidaText;
    [SerializeField] private Button testButton;
    [SerializeField] private PlayerHUE player; // Referencia al jugador para obtener la vida
    private float elapsedTime; // Tiempo transcurrido
    private bool isTimerRunning; // Bandera para saber si el temporizador está corriendo

    private void Start()
    {
        elapsedTime = 0f;
        isTimerRunning = true;

        testButton.onClick.AddListener(OnTestButtonClicked);

        UpdateTimeText();
        UpdateVidaText();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimeText();
        }

        // Actualizar la vida en el texto
        UpdateVidaText();
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
