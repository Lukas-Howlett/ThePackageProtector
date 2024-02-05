using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{

    public Button quitButton;

    void Start()
    {
        quitButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        Application.Quit();
    }
}