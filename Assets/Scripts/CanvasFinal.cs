using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasFinal : MonoBehaviour
{
    [SerializeField] private Button backMenu;

    [SerializeField] private Text timeText;
    [SerializeField] private GameTime gameTime;


    private void Start()
    {
        backMenu.onClick.AddListener(OnbackMenuButtonClicked);
        UpdateTimeText();
    }

    private void OnbackMenuButtonClicked()
    {
        SceneManager.LoadScene("StartScene");
    }
    private void UpdateTimeText()
    {
        if (timeText != null && gameTime != null)
        {
            timeText.text = $"Tiempo transcurrido: {gameTime.Time:F2} segundos";
        }
    }

}
