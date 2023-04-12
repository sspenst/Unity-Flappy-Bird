using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject wallPrefab;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        StartCoroutine(InstantiateWall());
    }

    IEnumerator InstantiateWall(int delay = 0, float yScale = 2.0f)
    {
        yield return new WaitForSeconds(delay);

        if (playerControllerScript.isGameActive)
        {
            GameObject wall = Instantiate(wallPrefab, new Vector3(30, Random.Range(-3, 3), -2), wallPrefab.transform.rotation);

            // adjust the wall gap
            wall.transform.localScale = new Vector3(1.0f, yScale, 1.0f);

            // the 14th wall is the minimum gap size; after that the gap is constant
            float nextYScale = Mathf.Max(0.7f, yScale - 0.1f);

            StartCoroutine(InstantiateWall(2, nextYScale));
        }
    }
}
