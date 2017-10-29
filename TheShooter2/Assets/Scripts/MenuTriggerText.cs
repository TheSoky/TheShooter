﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTriggerText : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Projectile") {
            SceneManager.LoadScene(0);
        }
    }
}