using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject optionsMenu;

    public bool hardAsteroids; 
   
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
