using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    PlayerController player;
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score:" + score;
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        //We can win based on Score or killing all enemies
        if (score >= player.MaxScore) // || gameManager.EnemyCount<=0
        {
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}




