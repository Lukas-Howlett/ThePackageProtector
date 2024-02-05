using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button mainMenuButton;

    void Start()
    {
        mainMenuButton.onClick.AddListener(GoToMainMenuScene);
    }

    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
