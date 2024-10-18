using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] private LifeEvent lifeEvent;  
    [SerializeField] private Text lifeText;  

    private void OnEnable()
    {
        lifeEvent.OnLifeChanged += UpdateLifeUI; 
    }

    private void OnDisable()
    {
        lifeEvent.OnLifeChanged -= UpdateLifeUI; 
    }

    private void UpdateLifeUI(int newLife)
    {
        lifeText.text = "Vida: " + newLife.ToString();  
    }
}
