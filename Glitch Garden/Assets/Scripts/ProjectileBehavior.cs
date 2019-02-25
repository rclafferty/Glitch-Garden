using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    const float SPEED = 5.0f;

    float xmax;

    // Start is called before the first frame update
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        xmax = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance)).x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * SPEED * Time.deltaTime, Space.World);

        if (transform.position.x > xmax)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name = collision.GetComponent<Collider2D>().name;
        if (name.ToLower().Contains("lizard"))
        {
            collision.GetComponent<HealthManager>().Hit();
            Destroy(gameObject);
        }
    }
}
