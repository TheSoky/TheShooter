using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour {
    [SerializeField]
    private Canvas GameplayCanvas;
    [SerializeField]
    private Canvas PauseCanvas;

    private void Start() {
        PauseCanvas.enabled = false;
        GameplayCanvas.enabled = true;
    }

    public void Update() {
        if (Input.GetButtonDown("Cancel")) {
            Time.timeScale = 0;
            GameManager.GM.SetMouseEnabled(true);
            GameplayCanvas.enabled = false;
            PauseCanvas.enabled = true;
        }
    }

    public void Continue() {
        GameManager.GM.SetMouseEnabled(false);
        Time.timeScale = 1;
        GameplayCanvas.enabled = true;
        PauseCanvas.enabled = false;
    }

    public void ToMenu() {
        GameManager.GM.SetMouseEnabled(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        GameManager.GM.SetMouseEnabled(false);
        Time.timeScale = 1;
        Application.Quit();
    }

}
