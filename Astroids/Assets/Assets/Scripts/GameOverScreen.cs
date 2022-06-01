using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    public MainMenu _mainMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
    }

    public void Setup(int score)
    {
        // Activating the Gameover screen and shows score
        gameObject.SetActive(true);
        this.scoreText.text = score.ToString() + " POINTS";
        this.highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
    }

    public void RestartGame()
    {

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        SceneManager.LoadScene(currentScene.name);
        if (sceneName == "Astroids")
        {
            SceneManager.LoadScene("Astroids");
        }
        else if (sceneName == "CrazyAstroids")
        {
            SceneManager.LoadScene("CrazyAstroids");
        }
    }

}
