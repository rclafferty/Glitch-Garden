using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerBehavior : MonoBehaviour
{
    const float SPEED = 0.5f;
    bool moving;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.Translate(Vector2.left * Time.deltaTime * SPEED);
        }
    }

    public void StartMoving()
    {
        moving = true;
    }

    public void StopMoving()
    {
        moving = false;
    }
}
