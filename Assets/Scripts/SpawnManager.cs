using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject wallPrefab;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        StartCoroutine(InstantiateWall(1));
    }

    IEnumerator InstantiateWall(int delay)
    {
        yield return new WaitForSeconds(delay);

        if (playerControllerScript.isGameActive)
        {
            Instantiate(wallPrefab, new Vector3(30, Random.Range(4, 10), -2), wallPrefab.transform.rotation);

            StartCoroutine(InstantiateWall(2));
        }
    }
}
