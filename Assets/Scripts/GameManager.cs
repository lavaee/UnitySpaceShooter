using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject Player;
    PlayerInput playerInput;
    PlayerShooting playerShooting;
    EnemySpawner enemySpawner;

    public ShipStats Kamikaze;
    public ShipStats EnemyHealth;

    public TextMeshProUGUI WaveText, ScoreText, HighScoreText;
    public GameObject DeathScreen, HealthPowerUp, FirePowerUp;

    public float entranceSpeed;
    public int WaveNumber = 0;
    [HideInInspector] public int CurrentNumberOfShips;
    [HideInInspector] public int Score = 0, HighScore;

    public static GameManager instance;
    int difficultyIndex = 1;
    public float timer;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        Initialization();
        StartCoroutine(PlayerEnterance());
    }

    public void UpdateNumberOfShips()
    {
        CurrentNumberOfShips--;
        //print(CurrentNumberOfShips);
        if (CurrentNumberOfShips == 0)
        {
            print(CurrentNumberOfShips);
            IncrementWave();
            StartCoroutine(SpawnNewEnemies());
            SpawnPowerUps();
            difficultyIndex++;
        }
    }

    void IncrementWave()
    {
        Kamikaze.MovementSpeed *= (int)1.05f;
        WaveNumber++;
        UpdateUI();
    }

    public void ShowDeathScreen()
    {
        DeathScreen.SetActive(true);
    }

    void UpdateUI()
    {
        WaveText.text = "Wave " + WaveNumber;
        WaveText.gameObject.GetComponent<Animator>().Play("Text");
    }

    void Initialization()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.text = "High Score: " + HighScore;
        enemySpawner = GetComponent<EnemySpawner>();
        Player = GameObject.FindGameObjectWithTag("Player");
        playerInput = Player.GetComponent<PlayerInput>();
        playerShooting = Player.GetComponent<PlayerShooting>();
    }

    IEnumerator SpawnNewEnemies()
    {
        yield return new WaitForSeconds(3);

        enemySpawner.SpawnColumn(Random.Range(2, 4));

        if (difficultyIndex % 1 == 0)
        {
            enemySpawner.SpawnRandom(Random.Range(1, difficultyIndex / 2));
        }

        if (difficultyIndex % 4 == 0 || difficultyIndex > 15)
        {
            enemySpawner.SpawnFlock();
        }

        if (difficultyIndex % 2 == 0 || difficultyIndex <= 5)
        {
            enemySpawner.SpawnKamikaze(Random.Range(2, 3));
        }

        if (difficultyIndex % 3 == 0 || difficultyIndex > 10)
        {
            enemySpawner.SpawnInterceptor(Random.Range(difficultyIndex / 2, (difficultyIndex / 2 ) + 1));
        }

        yield return null;
    }

    IEnumerator PlayerEnterance()
    {
        while (playerInput.transform.position.y < -30f)
        {
            Player.transform.position += new Vector3(0f, Time.deltaTime * entranceSpeed, 0f);
            yield return null;
        }

        IncrementWave();
        StartCoroutine(SpawnNewEnemies());

        //yield return new WaitForSeconds(timer);

        playerInput.enabled = true;
        playerInput.transform.position = new Vector3(0,-30,0);
        //playerShooting.enabled = true;
        yield return null;
    }

    public void UpdateScore(int _score)
    {
        Score += _score;
        if (Score >= HighScore)
        {
            HighScore = Score;
        }

        HighScoreText.text = "High Score: " + HighScore;
        ScoreText.text = "Score: " + Score;
    }

    void SpawnPowerUps()
    {
        if (difficultyIndex % 2 == 0)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 100f, 0);

            Instantiate(HealthPowerUp, randomPosition, HealthPowerUp.transform.rotation);
        }

        if (difficultyIndex % 3 == 0)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 100f, 0);

            Instantiate(FirePowerUp, randomPosition, FirePowerUp.transform.rotation);
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
    }
}
