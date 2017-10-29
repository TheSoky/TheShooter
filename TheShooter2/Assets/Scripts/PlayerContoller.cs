using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour {

    [SerializeField]
    private float MovementSpeed = 3.0f;
    [SerializeField]
    private Transform FPSCamera;
    [SerializeField]
    private float Gravity = -9.81f;
    [SerializeField]
    private GameObject[] Weapon;

    private CharacterController _characterController;

    private void Awake() {
        _characterController = GetComponent<CharacterController>();
        Weapon[0].SetActive(true);
        for (int i = 1; i < Weapon.Length; i++) {
            Weapon[i].SetActive(false);
        }
    }

    private void Update() {
        Vector3 movementZ = Input.GetAxisRaw("Vertical") * Vector3.forward * MovementSpeed * Time.deltaTime;
        Vector3 movementX = Input.GetAxisRaw("Horizontal") * Vector3.right * MovementSpeed * Time.deltaTime;

        Vector3 movement = FPSCamera.TransformDirection(movementX + movementZ);
        movement.y = Gravity * Time.deltaTime;
        _characterController.Move(movement);

        if (Input.GetButtonDown("Weapon1")) {
            for (int i = 0; i < Weapon.Length; i++) {
                Weapon[i].SetActive(false);
            }
            Weapon[0].SetActive(true);
        }

        if (Input.GetButtonDown("Weapon2")) {
            for (int i = 0; i < Weapon.Length; i++) {
                Weapon[i].SetActive(false);
            }
            Weapon[1].SetActive(true);
        }

        if (Input.GetButtonDown("Weapon3")) {
            for (int i = 0; i < Weapon.Length; i++) {
                Weapon[i].SetActive(false);
            }
            Weapon[2].SetActive(true);
        }

        if (Input.GetButtonDown("Weapon4")) {
            for (int i = 0; i < Weapon.Length; i++) {
                Weapon[i].SetActive(false);
            }
            Weapon[3].SetActive(true);
        }



    }

}
