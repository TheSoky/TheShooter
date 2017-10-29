using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private float StartingTime = 20.0f;
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    private Text TimerText;
    [SerializeField]
    private Canvas GameplayCanvas;
    [SerializeField]
    private Canvas EndGameCanvas;
    [SerializeField]
    private Text EndScoreText;

    private float _timer;
    private int _score;
    private bool _isPlaying = true;

    private void Awake() {
        _isPlaying = true;
        GameplayCanvas.enabled = true;
        EndGameCanvas.enabled = false;
        _timer = StartingTime;
        _score = 0;
        UpdateTimer(0.0f);
        UpdateScore(0);
        Time.timeScale = 1;
    }

    private void Start() {
        GameManager.GM.SetMouseEnabled(false);
    }

    public void Update() {
        if (_isPlaying) {
            UpdateTimer(-Time.deltaTime);
        }
    }

    public void UpdateTimer(float amount) {
        _timer += amount;
        TimerText.text = "Timer: " + _timer.ToString("00.00");
        if(_timer <= 0.0f) {
            EndGame();
        }
    }

    public void UpdateScore(int amount) {
        _score += amount;
        ScoreText.text = "Score: " + _score.ToString();
    }

    private void EndGame() {
        Time.timeScale = 0;
        _isPlaying = false;
        GameManager.GM.SetMouseEnabled(true);
        GameplayCanvas.enabled = false;
        EndGameCanvas.enabled = true;
        EndScoreText.text = "Your Score is: " + _score.ToString();
        GameManager.GM.CheckAndSaveHS(_score);
    }

}
