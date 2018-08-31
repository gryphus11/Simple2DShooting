using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItemDrop : MonoBehaviour
{
    public GameObject[] itemPrefab = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemDrop()
    {
        int randomIndex = Random.Range(0, itemPrefab.Length);
        Instantiate(itemPrefab[randomIndex], transform.position, Quaternion.identity);
        //GameObject item = CObjectPool.current.GetObject(_itemPrefab[randomIndex]);
        //item.transform.position = transform.position;
        //item.transform.rotation = Quaternion.identity;
        //item.SetActive(true);
    }
}
