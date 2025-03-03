using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text highScoreText; 
    private int highScore = 0;
    public Text currentScoreText;
    private int currentScore = 0;
    public Button increaseScoreButton;
    public Button resetCurrentScoreButton;
    public Slider musicSlider;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString(); // Ensure UI is updated at start
        UpdateCurrentScoreUI();

        increaseScoreButton.onClick.AddListener(AddingScore);
        resetCurrentScoreButton.onClick.AddListener(Reset);
    }


    public void AddingScore()
    {
        currentScore += 1;
        UpdateCurrentScoreUI();

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = "High Score: " + highScore.ToString();
    }


    public void increaseButtonScoreOnClick()
    {
        currentScore += 1;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        currentScoreText.text = "Current Score: " + currentScore.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
        UpdateHighScoreUI();

    }

    // Reduce or increase baclground music volume
    public void OnMusicVolumeChange()
    {
        AudioListener.volume = musicSlider.value;
    }

    // Update the high score UI
    // The high score is updated only when the current score is greater than the high score
    // The score is saved in the PlayerPrefs
    void UpdateHighScoreUI()
    {
        
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

    }

    //Reset the current score to 0
    public void Reset()
    {
        currentScore = 0;
        UpdateCurrentScoreUI();
    }

    // Update the current score UI
    public void UpdateCurrentScoreUI()
    {
        currentScoreText.text = "Current score: " + currentScore.ToString();
    }   
}

