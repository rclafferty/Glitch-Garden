using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehavior : MonoBehaviour
{
    GameObject gun;
    Transform gunTransform;
    GunController gunController;
    GameObject projectile;
    const float BASE_DAMAGE = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        gunTransform = this.transform.Find("Gun");
        gun = gunTransform.gameObject;
        gunController = gun.GetComponent<GunController>();

        projectile = Resources.Load<GameObject>("Prefabs/Axe");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        gunController.Fire(projectile);
    }
}
