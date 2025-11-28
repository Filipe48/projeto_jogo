using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int totalScore;
    private Text scoreText;
    
    private int scoreNoInicioDaFase; 
    private string nomeDaUltimaCena; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == nomeDaUltimaCena)
        {
            totalScore = scoreNoInicioDaFase;
        }
        else
        {
            scoreNoInicioDaFase = totalScore;
            nomeDaUltimaCena = scene.name;
        }

        UpdateScoreUI();
    }

    public void RegisterScoreText(Text newTextComponent)
    {
        scoreText = newTextComponent;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
        UpdateScoreUI();
    }

    public void ResetScore()
    {
        totalScore = 0;
        scoreNoInicioDaFase = 0;
        nomeDaUltimaCena = "";
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = totalScore.ToString();
        }
    }
}