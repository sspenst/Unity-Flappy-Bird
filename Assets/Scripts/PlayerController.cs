using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float gravityScale;
    public float jumpForce;
    public float yMax;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
            rb.velocity = Vector3.zero;
        }
        else if (transform.position.y < -7)
        {
            Debug.Log("Game Over - too low");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Opening"))
        {
            score++;
            Debug.Log(score);
        }
        else if (other.CompareTag("Wall"))
        {
            Debug.Log("Game Over - hit a wall");
        }
    }
}
