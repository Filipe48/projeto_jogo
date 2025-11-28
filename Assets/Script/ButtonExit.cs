using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonExixt : MonoBehaviour
{
    [Tooltip("Nome do Menu Principal")]
    public string menuSceneName = "Menu";

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ExitLevel();
        }
    }

     public void ExitLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}
