using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public void ToMenu() {
        GameManager.GM.SetMouseEnabled(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void LoadTraining() {
        SceneManager.LoadScene(1);
    }

    public void LoadFirstLevel() {
        SceneManager.LoadScene(2);
    }

    public void LoadNextLevel() {
        if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ExitGame() {
        Application.Quit();
    }

}
