using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;

    [SerializeField] private int dyingScorePenalty;
    [SerializeField] private string[] levels;
    [HideInInspector] public GameObject player;
    public int score = 0;
    private int currentLevel = 0;

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(gameObject);
    }

    public void Respawn()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.transform.position = LevelManager.instance.spawnPos;
        score -= dyingScorePenalty;

        if (score < 0)
            score = 0;
    }

    public void LoadNextLevel()
    {
        if (currentLevel < levels.Length)
        {
            SceneManager.LoadScene(levels[currentLevel + 1]);
            currentLevel++;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
            Application.Quit();
        }
    }
}
