using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {
    /// <summary>
    /// return a random number from range
    /// </summary>
    /// <param name="v2"></param>
    /// <returns>float</returns>
    public static float RandomValue(this Vector2 v2) {
        return Random.Range(v2.x, v2.y);
    }
}

public class TargetSpawner : MonoBehaviour {

    [SerializeField]
    private float SpawnInterval = 2.5f;
    [SerializeField]
    private GameObject TargetToSpawn;
    [Space(5.0f)]

    [SerializeField]
    private Vector2 XRange = new Vector2(-10.0f, 10.0f);
    [SerializeField]
    private Vector2 ZRange = new Vector2(-16.0f, 16.0f);

    private bool _isSpawning;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            _isSpawning = true;
            StartCoroutine(SpawnTarget());
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            _isSpawning = false;
        }
    }

    private IEnumerator SpawnTarget() {
        while (_isSpawning) {
            Vector3 spawnPosition = new Vector3(XRange.RandomValue(), 0.0f, ZRange.RandomValue());

            GameObject targetClone = Instantiate(TargetToSpawn, spawnPosition, Quaternion.identity);
            targetClone.transform.SetParent(transform);
            yield return new WaitForSeconds(SpawnInterval);
        }
    }

}
