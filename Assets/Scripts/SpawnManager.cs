using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject wallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateWall", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateWall()
    {
        Instantiate(wallPrefab, new Vector3(30, Random.Range(4, 10), -2), wallPrefab.transform.rotation);
    }
}
