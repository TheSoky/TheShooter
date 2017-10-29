using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTarget : MonoBehaviour {

    [SerializeField]
    private AudioClip ScoreSound;
    private AudioSource _audiosource;

    private void Awake() {
        _audiosource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Projectile") {
            _audiosource.PlayOneShot(ScoreSound);
        }
    }
}
