using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

    private float _highScore = 0.0f;
    private bool MouseEnabled = false;

    private static GameManager instance = null;
    public static GameManager GM {
        get {
            return instance;
        }
    }

    private void Awake() {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        Cursor.visible = false;
        MouseEnabled = false;

        LoadHS();
    }

    private void Update() {
        if (!MouseEnabled) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void SaveHS() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/HighScore.dat");

        PlayerHighScore data = new PlayerHighScore {
            HighScore = _highScore
        };

        bf.Serialize(file, data);
        file.Close();
    }

    private void LoadHS() {
        if(File.Exists(Application.persistentDataPath + "/HighScore.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/HighScore.dat",FileMode.Open);
            PlayerHighScore data = (PlayerHighScore)bf.Deserialize(file);
            file.Close();

            _highScore = data.HighScore;
        }
        else {
            _highScore = 0.0f;
        }
    }

    public void CheckAndSaveHS(float score) {
        if(score > _highScore) {
            _highScore = score;
            SaveHS();
        }
    }

    public float GetHighScore() {
        LoadHS();
        return _highScore;
    }

    public void SetMouseEnabled(bool status) {
        MouseEnabled = status;
    }

}
[Serializable]
class PlayerHighScore {
    public float HighScore;
}
