using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [Header("Buttons")]
    private Button button;
    [Header("Scripts")]
    private GameManager gameManager;
    [Header("Intergers")]
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SetDifficulty() {
        Debug.Log("Funni button named" + gameObject.name);
        gameManager.StartGame(difficulty);
    }
}
