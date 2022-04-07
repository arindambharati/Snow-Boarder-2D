using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject LevelCompleteUI;
    [SerializeField] private GameObject ButtonsUI;
    [SerializeField] private GameObject NextLevelBtn;

    [SerializeField] private Button restartBtn;
    [SerializeField] private Button quitBtn;
    

    private void Awake()
    {
       restartBtn.onClick.AddListener(ReloadScene);
       quitBtn.onClick.AddListener(QuitGame);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
