using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BombPrefab;
    [SerializeField] private Vector3 spawnDirection = Vector3.forward;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float initialVelocity = 5f;
    [SerializeField] private float bombLifetime = 15f;

    private void Start()
    {
        StartCoroutine(SpawnBombs());
    }

    private IEnumerator SpawnBombs()
    {
        while (true)
        {
            GameObject bomb = Instantiate(BombPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = spawnDirection.normalized * initialVelocity;
            }
            StartCoroutine(DestroyBombAfterTime(bomb, bombLifetime));
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator DestroyBombAfterTime(GameObject bomb, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bomb);
    }
}