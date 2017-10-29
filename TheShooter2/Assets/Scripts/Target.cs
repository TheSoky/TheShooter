using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    [SerializeField]
    private int ScoreValue = 1;
    [SerializeField]
    private float TimeValue = 0.0f;
    [SerializeField]
    private AudioClip HitSound;
    [SerializeField]
    private float DestroyTime = 1.0f;
    [SerializeField]
    private AnimationClip DissappearClip;

    private Animation _animation;
    private AudioSource _audioSource;
    private Collider _collider;
    private LevelManager _levelManager;

    private void Awake() {
        _audioSource = GetComponent<AudioSource>();
        _collider = GetComponent<Collider>();
        _animation = GetComponent<Animation>();
    }
    private void Start() {
        _levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Projectile") {
            _audioSource.PlayOneShot(HitSound);
            _collider.enabled = false;
            _animation.Play(DissappearClip.name);
            _levelManager.UpdateScore(ScoreValue);
            _levelManager.UpdateTimer(TimeValue);
            Invoke("DestroyTarget", DestroyTime);
        }
    }

    private void DestroyTarget() {
        Destroy(gameObject);
    }

}
