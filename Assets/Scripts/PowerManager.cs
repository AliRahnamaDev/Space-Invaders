using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    public Transform[] spawnPoints; 

    public GameObject objectToSpawn; 

    private GameObject currentObject;

    public float ActivetimeFirstvalue;
    public float ActivetimeSecondvalue;
    [Header("Har Chand Sanyieh yebar biad")]
    public float first;
    public float second;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(first, second)); 

            if (currentObject != null)
                Destroy(currentObject); 

            int index = Random.Range(0, spawnPoints.Length);
            currentObject = Instantiate(objectToSpawn, spawnPoints[index].position, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(ActivetimeFirstvalue, ActivetimeSecondvalue));
            if (currentObject != null)
                Destroy(currentObject);
        }
    }

}
