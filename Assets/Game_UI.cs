using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public enum UiMenu {StartMenu, InGameDetail, PauseMenu, EndGameMenu}
public class Game_UI : MonoBehaviour
{
    public static Game_UI Instance;

    [SerializeField] private List<GameObject> uiList;
    [Header("In game score info")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [Header("Final score info")]
    [SerializeField] private TextMeshProUGUI finalScoreText;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
        DisplayUI(UiMenu.StartMenu);
    }
    private void Update()
    {
        SetScoreText();
    }
    private void DisplayUI(UiMenu menuToDisplay)
    {
        foreach (GameObject menu in uiList)
        {
            menu.SetActive(false);
        }
        uiList[(int)menuToDisplay].SetActive(true);
    }
    public void LoadEndGameMenu()
    {
        DisplayUI(UiMenu.EndGameMenu);
        finalScoreText.text = scoreText.text;
        Time.timeScale = 0;
    }
    public void StartButton()
    {
        Time.timeScale = 1;
        DisplayUI(UiMenu.InGameDetail);
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
        DisplayUI(UiMenu.InGameDetail);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    private void SetScoreText()
    {
        scoreText.text = "Score: " + GameManager.instance.Score.ToString();
    }
}
