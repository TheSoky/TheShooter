using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private Canvas ControlsCanvas;
    [SerializeField]
    private Text HSText;

    private void Update() {
        if (Input.GetAxisRaw("Cancel") == 1) {
            Application.Quit();
        }
    }

    private void Start() {
        GameManager.GM.SetMouseEnabled(false);
        ControlsCanvas.enabled = false;
        HSText.text = ("Highscore: " + GameManager.GM.GetHighScore().ToString("000."));
    }

    public void SwitchControls() {
        ControlsCanvas.enabled = !ControlsCanvas.enabled;
    }

}
