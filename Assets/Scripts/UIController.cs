using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject LevelCompleteUI;
    [SerializeField] private GameObject ButtonsUI;
    [SerializeField] private GameObject NextLevelBtn;

    [SerializeField] private Button restartBtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] private TextMeshProUGUI scoreText;

    int score = 0;

    private void Awake()
    {
       restartBtn.onClick.AddListener(ReloadScene);
       quitBtn.onClick.AddListener(QuitGame);
    }

    private void Start()
    {
        RefreshUI();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.Instance.soundMusic.Play();
    }

    public void GameOverActiveUI()
    {
        GameOverUI.SetActive(true);
        ButtonsUI.SetActive(true); 
    }

    public void LevelCompleteActiveUI()
    {
        LevelCompleteUI.SetActive(true);

        NextLevelBtn.SetActive(true);
        ButtonsUI.SetActive(true);
    }

    public void IncrementScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score: " + score;
    }

}
