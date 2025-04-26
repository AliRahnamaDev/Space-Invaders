using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; 
    public Transform enemyParent;       
    public int rows = 5;                
    public int columns = 10;            
    public float spacingX = 1.5f;       
    public float spacingY = 1.5f;       
    public Vector2 startPosition = new Vector2(-7f, 4f);
    public int ChangeEnemiesperRow = 2;
    public int EnemyCount;
    
    void Start()
    {
        SpawnEnemies();
         EnemyCount = rows * columns;
    }

    private void Update()
    {
        
    }

    void SpawnEnemies()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 spawnPos = new Vector2(startPosition.x + (col * spacingX), startPosition.y - (row * spacingY));
                int typeIndex = (row / ChangeEnemiesperRow) % enemyPrefabs.Length;
                GameObject prefab = enemyPrefabs[typeIndex];
                GameObject enemy = Instantiate(prefab, spawnPos, transform.rotation, enemyParent);
            }
        }
    }
}