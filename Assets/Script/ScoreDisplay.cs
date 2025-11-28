using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    void Start()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.RegisterScoreText(GetComponent<Text>());
        }
        else
        {
            Debug.LogError("ScoreManager não encontrado! Comece o jogo pela cena inicial.");
        }
    }
}