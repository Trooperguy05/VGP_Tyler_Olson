using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("GameObjects")]
    public List<GameObject> targets;
    public GameObject titleScreen;
    [Header("Floats")]
    private float spawnRate = 1.0f;
    [Header("Intergers")]
    private int score;
    [Header("Booleans")]
    public bool isGameActive;
    [Header("TextMeshPro")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    [Header("Buttons")]
    public Button restartButton;

    IEnumerator SpawnTargets() {
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "score: " + score;
    }

    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty) {
        isGameActive = true;
        StartCoroutine(SpawnTargets());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }
}
