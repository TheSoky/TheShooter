using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    [SerializeField]
    private Transform ProjectileParent;
    [SerializeField]
    private GameObject Projectile;
    [SerializeField]
    private float Power = 10.0f;
    public int BulletsPerClip = 30;
    [SerializeField]
    private float SecondsBetweenShots = 0.1f;
    [SerializeField]
    private float ReloadTimeInSeconds = 2.5f;
    [SerializeField]
    private AudioClip GunSound;
    [SerializeField]
    private AudioClip ReloadSound;
    [SerializeField]
    private Text AmmoText;
    [SerializeField]
    private List<Transform> Firepoints = new List<Transform>();

    [HideInInspector]
    public int NrOfBullets;
    private AudioSource _audioSource;
    private bool _isReloading = false;

    private void Start() {
        NrOfBullets = BulletsPerClip;
        _audioSource = GetComponent<AudioSource>();
        AmmoText.text = NrOfBullets.ToString() + " / " + BulletsPerClip.ToString();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown ("Reload")) {
            StartCoroutine(Shooting());
        }

    }

    IEnumerator Shooting() {
        while ((Input.GetButton("Fire1") || Input.GetButtonDown("Reload")) && !_isReloading) {
            if (NrOfBullets > 0 && Input.GetButton("Fire1")) {
                foreach (Transform firePoint in Firepoints) {
                    ShootProjectile(firePoint);
                }
                NrOfBullets -= 1;
                _audioSource.PlayOneShot(GunSound);
                yield return new WaitForSeconds(SecondsBetweenShots);
            }
            else if (!_isReloading) {
                _isReloading = true;
                _audioSource.PlayOneShot(ReloadSound);
                yield return new WaitForSeconds(ReloadTimeInSeconds);
                NrOfBullets = BulletsPerClip;
                _isReloading = false;
            }
            else {
                yield return null;
            }
            AmmoText.text = NrOfBullets.ToString() + " / " + BulletsPerClip.ToString();
        }
        yield return new WaitForSeconds(ReloadTimeInSeconds);
        _isReloading = false;
    }

    private void ShootProjectile(Transform firePoint) {
        GameObject projectileClone = Instantiate(Projectile, firePoint.position, Quaternion.identity);
        projectileClone.transform.SetParent(ProjectileParent);

        Rigidbody projectileRigidbody = projectileClone.GetComponent<Rigidbody>();
        projectileRigidbody.AddForce(firePoint.forward * Power, ForceMode.VelocityChange);
    }

}
