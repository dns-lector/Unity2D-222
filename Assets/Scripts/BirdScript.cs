using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private float forceFactor = 100.0f;    // 1.0e2

    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * forceFactor);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
    }
}
