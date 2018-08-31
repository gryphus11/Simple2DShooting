using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyGenerator : MonoBehaviour
{
    public Transform[] generatePositions = null;
    public GameObject[] enemyPrefabs = null;

    public float delayMinTime = 0.0f;
    public float delayMaxTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        float randomDelay = GetDelayTime();
        Invoke("CreateEnemy", randomDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemy()
    {
        float randomDelayTime = GetDelayTime();
        int randomIndex = Random.Range(0, generatePositions.Length);
        int randomRate = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[randomRate], generatePositions[randomIndex].position, Quaternion.identity);

        Invoke("CreateEnemy", randomDelayTime);
    }

    float GetDelayTime()
    {
        return Random.Range(delayMinTime, delayMaxTime);
    }
}
