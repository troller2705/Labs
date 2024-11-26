using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    //GAME PROPERTIES
    [SerializeField] private int maxLives = 3;
    private int _lives;

    public int lives
    {
        get => _lives;
        set
        {
            if (value < 0)
            {
                GameOver();
                return;
            }
            if (_lives > value)
            {
                Respawn();
            }
            _lives = value;
            Debug.Log($"{_lives} lives left");
        }
    }

    private int _score;

    public int score
    {
        get => _score;
        set
        {
            if (value > 0) return;

            _score = value;
            Debug.Log($"Current score: {_score}");
        }
    }
    //GAME PROPERTIES

    //Player Controller Information
    [SerializeField] private PlayerController playerPrefab;

    [HideInInspector] public PlayerController PlayerInstance => _playerInstance;
    private PlayerController _playerInstance;
    //Player Controller Information

    private Transform currentCheckpoint;

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
            return;
        }

        Destroy(gameObject);
    }

    private void Start()
    {
        if (maxLives <= 0) maxLives = 3;

        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    SceneManager.LoadScene("Menu");
                    break;
                case "Menu":
                    SceneManager.LoadScene("Level1");
                    break;
                case "GameOver":
                    SceneManager.LoadScene("Menu");
                    break;
            }
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void Respawn()
    {
        _playerInstance.transform.position = currentCheckpoint.position;
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        _playerInstance = Instantiate(playerPrefab, spawnLocation.position, Quaternion.identity);
        currentCheckpoint = spawnLocation;
    }

    public void UpdateCheckpoint(Transform updatedCheckpoint)
    {
        currentCheckpoint = updatedCheckpoint;
    }
}
