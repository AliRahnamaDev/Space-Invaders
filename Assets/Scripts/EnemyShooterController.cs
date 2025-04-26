using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShooterController : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    
    [SerializeField]public int numberOfShooters = 3;
    
    private List<Transform> aliveEnemies = new List<Transform>();

    public float EnemyFireRate;
    void Start()
    { 
        StartCoroutine(ShootRoutine());
    }

    void Update()
    {
        
    }
    
    //Coroutine for Enemy FireRate
    IEnumerator ShootRoutine()
    {
        float fireRate = Random.Range(2, EnemyFireRate);
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            UpdateAliveEnemies();
            ShootFromRandomEnemies();
        }
    }

    
    void UpdateAliveEnemies()
    {
        aliveEnemies.Clear();
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                aliveEnemies.Add(child);
            }
        }
    }

    //Choose Enemies To Shoot
    void ShootFromRandomEnemies()
    {
        if (aliveEnemies.Count == 0) return;

        int shots = Math.Min(numberOfShooters, aliveEnemies.Count);
        List<Transform> selectedEnemies = new List<Transform>();

        while (selectedEnemies.Count < shots)
        {
            int index = Random.Range(0, aliveEnemies.Count);
            Transform selected = aliveEnemies[index];
            if (!selectedEnemies.Contains(selected))
            {
                selectedEnemies.Add(selected);
            }
        }

        foreach (Transform enemy in selectedEnemies)
        {
            Instantiate(bulletPrefab, enemy.position, transform.rotation);
        }
    }
}

