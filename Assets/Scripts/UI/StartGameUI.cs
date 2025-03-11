using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : MonoBehaviour
{
    [SerializeField] private GameObject startCanvas; 
    [SerializeField] private Button okButton;

    private void Start()
    {
        startCanvas.SetActive(true);  
        Time.timeScale = 0;          
        okButton.onClick.AddListener(CloseCanvas);
    }

    private void CloseCanvas()
    {
        startCanvas.SetActive(false); 
        Time.timeScale = 1;           
    }
}
