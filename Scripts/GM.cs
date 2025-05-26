using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public static GM Instance;
    public static int totalScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CountPoints(int Score)
    {
        totalScore = Score;
        Debug.Log("totalScore: " + totalScore);
    }
}

