using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loseWindow;
    public static GameManager instance;
    private void Start()
    {
        instance = this;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Lose()
    {
        loseWindow.SetActive(true);
    }
}
