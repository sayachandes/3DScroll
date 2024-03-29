using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Enemy;
    public Text scoreText;
    private bool isGameOver;
    private int score;
    private int enemiesSpawned = 1;
    private int enemiesToSpawn = 5;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        StartCoroutine(EnemyI());
        score = 5;
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            SceneManager.LoadScene("Title");
        }

        if(score == 0)
        {
            SceneManager.LoadScene("Clear");
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("GameOver");
    }

    IEnumerator EnemyI()
    {
        while (enemiesSpawned < enemiesToSpawn)
        {
            //enemiesToSpawn‚Ì”‚Ü‚Å“G‚ð¶¬
            Instantiate(Enemy, transform.position, transform.rotation);
            yield return new WaitForSeconds(5.0f);
            enemiesSpawned++;
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Enemy:" + score;
    }

    public void AddScore(int scoreToAdd)
    {
        //ˆø”‚Ì”‚¾‚¯ƒXƒRƒA‚ðŒ¸‚ç‚·
        score -= scoreToAdd;
        UpdateScoreText();
    }
}
