using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private Renderer rend;
    private float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.mainTextureOffset -= new Vector2(Time.deltaTime * speed, rend.material.mainTextureOffset.y);
    }
}
