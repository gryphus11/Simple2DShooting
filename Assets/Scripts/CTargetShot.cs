using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTargetShot : MonoBehaviour
{
    public GameObject weaponPrefab = null;
    public float shotDelayTime = 0.0f;
    public Transform shotPos = null;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(AutoShotCoroutine());
    }

    private IEnumerator AutoShotCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shotDelayTime);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length <= 0)
                continue;

            List<GameObject> targetEnemyList = new List<GameObject>();

            foreach (GameObject enemy in enemies)
            {
                if ((transform.position.y + 2.0f) < enemy.transform.position.y)
                {
                    targetEnemyList.Add(enemy);
                }
            }

            if (targetEnemyList.Count <= 0)
                continue;

            Transform targetEnemy = null;
            float minDist = 0.0f;

            foreach (GameObject enemy in targetEnemyList)
            {
                float dist = Vector2.Distance(transform.position, enemy.transform.position);

                if (targetEnemy == null)
                {
                    targetEnemy = enemy.transform;
                    minDist = dist;
                    continue;
                }

                if (minDist > dist)
                {
                    targetEnemy = enemy.transform;
                    minDist = dist;
                }
            }

            if (targetEnemy == null)
                continue;

            if (weaponPrefab == null)
                Debug.Log("무기 프리팹이 null");

            //Instantiate(_weaponPrefab, _shotPos.position, Quaternion.identity);
            GameObject weapon = CObjectPool.current.GetObject(weaponPrefab);
            weapon.transform.position = shotPos.position;
            weapon.transform.rotation = Quaternion.identity;
            weapon.SetActive(true);

            if (weapon == null)
                Debug.Log("무기가 null");

            weapon.GetComponent<CTargetMovement>().Init(targetEnemy);

        }
    }
}
