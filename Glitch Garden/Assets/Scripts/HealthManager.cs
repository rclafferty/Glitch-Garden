using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    const int BASE_HEALTH = 1;
    [SerializeField]
    int health;

    GameObject deathVFX;

    // Start is called before the first frame update
    void Start()
    {
        health = BASE_HEALTH;
        deathVFX = Resources.Load<GameObject>("Prefabs/Explosion VFX");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        Hit(1);
    }

    public void Hit(int h)
    {
        health -= h;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        TriggerDeathVFX();
        Destroy(gameObject);
    }

    void TriggerDeathVFX()
    {
        if (deathVFX == null)
        {
            return;
        }

        GameObject vfx = Instantiate(deathVFX, transform.position + Vector3.left * 0.5f, Quaternion.identity);
        //vfx.transform.parent = transform;
        Destroy(vfx, 1f);
    }
}
