using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectPool : MonoBehaviour
{

    public static CObjectPool current = null;          // 오브젝트 풀 Static 참조 변수
    public GameObject[] prefabs = null;                // 오브젝트 풀을 사용할 프리팹 배열
    public List<GameObject>[] pooledObjects = null;  // 오브젝트 풀 리스트
    public int[] amountToBuffer = null;                // 인덱스와 일치하는 프리팹의 오브젝트 풀 크기 배열
    public int defaultBufferAmount = 10;        // 기본 오브젝트 풀 크기
    public bool canGrow = true;                 // 풀 크기 확장 여부

    private GameObject _containerObject = null;                 // 컨테이너 오브젝트

    void Awake()
    {

        if (current == null)
            current = this;
        else
            Destroy(gameObject); // 재생성 시 이전 오브젝트를 파괴함

        _containerObject = new GameObject("ObjectPool");
        pooledObjects = new List<GameObject>[prefabs.Length];

        int index = 0;
        foreach (GameObject objectPrefab in prefabs)
        {
            pooledObjects[index] = new List<GameObject>();

            int bufferAmount;
            if (index < amountToBuffer.Length)
                bufferAmount = amountToBuffer[index];
            else
                bufferAmount = defaultBufferAmount;

            for (int i = 0; i < bufferAmount; i++)
            {
                GameObject obj = (GameObject)Instantiate(objectPrefab);
                obj.name = objectPrefab.name;
                PoolObject(obj);
            }

            index++;
        }
    }

    // 풀에서 꺼냄
    public GameObject GetObject(GameObject objectType)
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            GameObject prefab = prefabs[i];

            if (prefab.name == objectType.name)
            {
                if (pooledObjects[i].Count > 0)
                {
                    //Debug.Log(pooledObjects[i].Count);
                    GameObject pooledObject = pooledObjects[i][0];
                    pooledObjects[i].RemoveAt(0);
                    pooledObject.transform.parent = null;
                    return pooledObject;

                }
                else if (canGrow)
                {
                    GameObject obj = Instantiate(prefabs[i]) as GameObject;
                    Debug.Log("버퍼를 초과하여 생산!");
                    obj.name = prefabs[i].name;
                    return obj;
                }

                break;

            }
        }

        return null;
    }

    // 풀에 삽입
    public void PoolObject(GameObject obj)
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            if (prefabs[i].name == obj.name)
            {
                //obj.transform.parent = containerObject.transform;
                obj.transform.SetParent(_containerObject.transform);
                pooledObjects[i].Add(obj);
                obj.SetActive(false);
                return;
            }
        }
    }
}
