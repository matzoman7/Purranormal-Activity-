using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToUpgrades()
    {
        SceneManager.LoadScene("UpgradesScene");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
