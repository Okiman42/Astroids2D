using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject optionsMenu;

    public bool hardAsteroids;
    public Button hardButton;
    private bool hasRun = false;

    private void FixedUpdate()
    {
        if (!hasRun && PlayerPrefs.GetInt("hasNoLife", 0) == 1)
        {
            hasRun = true;
            hardButton.interactable = true;
        }
    }

    public void Classic()
    {
        SceneManager.LoadScene("Astroids");
        hardAsteroids = false;
    }

    public void Startmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Play()
    {
        SceneManager.LoadScene("PlayOption");
    }

    public void Options()
    {
        this.Main.SetActive(false);
        this.optionsMenu.SetActive(true);
    }

    public void Back()
    {
        this.optionsMenu.SetActive(false);
        this.Main.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Hard()
    {
        SceneManager.LoadScene("CrazyAstroids");
        hardAsteroids = true;
    }

}
