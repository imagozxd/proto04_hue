using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasStart : MonoBehaviour
{
    [SerializeField] private Button playButton; 
    [SerializeField] private Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();

    }
}
