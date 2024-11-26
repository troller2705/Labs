using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private int _lives;

    public int lives
    {
        get => _lives;
        set
        {
            if (value > 0)
            {

            }
            if (_lives > value)
            {

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string sceneName = (SceneManager.GetActiveScene().name == "Level1") ? "Menu" : "Level1" ;
            SceneManager.LoadScene(sceneName);
        }
    }
}
