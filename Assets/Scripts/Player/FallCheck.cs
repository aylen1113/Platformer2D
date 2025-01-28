using UnityEngine;
using UnityEngine.SceneManagement;

public class FallCheck : MonoBehaviour
{
    [SerializeField] private float fallThreshold = -10f; 

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
