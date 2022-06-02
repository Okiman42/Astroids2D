using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables
    public Player player;
    public GameOverScreen GameOverScreen;
    public MainMenu _mainMenu;


    public ParticleSystem explotion;

    public Text scoreText;
    public Text lifeText;
   

    private bool _gameOver;
    public bool HardAstroids;

    public float respawnTime = 3.0f;
    public float respawnInvulnerabilityTime = 3.0f;

    public int currentLives = 3;
    public int currentScore;
    public int resetScore = 0;


    #endregion
        
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "Astroids")
        {
            this.HardAstroids = false;
        }
       else if (sceneName == "HardAstroids")
        {
            this.HardAstroids = true;
        }

        lifeText.text = "x " + currentLives;

    }

    private void Update()
    {

        // Resets Highscore
        if (Input.GetKey(KeyCode.L))
        {
            PlayerPrefs.SetInt("highscore", resetScore);
        }

    }
 
    public void AsteroidDestroyed(Asteroid asteroid)
    {
        //Particle effect
        this.explotion.transform.position = asteroid.transform.position;
        this.explotion.Play();

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        #region Points devider
        //Makes it so that you can get double the points in hard mode to make it rewarding to play.
        if (sceneName == "CrazyAstroids")
        {
            if (asteroid.size < 0.75f)
            {
                currentScore += 200;
                HandleScore();
            }
            else if (asteroid.size < 1.2f)
            {
                currentScore += 100;
                HandleScore();
            }
            else
            {
                this.currentScore += 50;
                HandleScore();
            }
        }
        else
        { 
            if (asteroid.size < 0.75f)
            {
                currentScore += 100;
                HandleScore();
            }
            else if (asteroid.size < 1.2f)
            {
                currentScore += 50;
                HandleScore();
            }
            else
            {
                this.currentScore += 25;
                HandleScore();
            }
        }
        #endregion
    }

    public void PlayerDied()
    {
        this.explotion.transform.position = this.player.transform.position;
        this.explotion.Play();

        this.currentLives--;
        lifeText.text = "x " + currentLives;

        if (this.currentLives <= 0){
            GameOver();
        } else
        {
            Invoke(nameof(Respawn), respawnTime);
        }

    }

    private void HandleScore()
    {
        scoreText.text = "" + currentScore;
    }

    private void Respawn()
    {
        // Reset values of "Player" to respawn
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        this.player.shouldShoot = false;

        //Invun
        Invoke(nameof(TurnOnShoot), respawnInvulnerabilityTime);
        Invoke(nameof(TurnOnCollisions), respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void TurnOnShoot()
    {
        this.player.shouldShoot = true;
    }


    private void GameOver()
    {
        // If the "currentScore" is greater than "highscore", then current score
        // will become the highscore. It's being saved as "PlayerPrefs"
        if (currentScore > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", currentScore);

            if (currentScore > 10000 && PlayerPrefs.GetInt("hasNoLife", 0) == 0)
                PlayerPrefs.SetInt("hasNoLife", 1);
        }

        GameOverScreen.Setup(currentScore);

    }


}
