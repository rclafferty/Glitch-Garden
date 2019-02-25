using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    GameObject attackerPrefab;
    bool spawn;

    const float MIN_SPAWN_DELAY = 10.0f;
    const float MAX_SPAWN_DELAY = 20.0f;

    bool firstSpawn;

    // Start is called before the first frame update
    void Start()
    {
        attackerPrefab = Resources.Load<GameObject>("Prefabs/Lizard");

        spawn = true;
        firstSpawn = true;

        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawn()
    {
        if (firstSpawn)
        {
            firstSpawn = false;
            yield return new WaitForSeconds(30);
        }
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(MIN_SPAWN_DELAY, MAX_SPAWN_DELAY));
            GameObject enemy = Instantiate(attackerPrefab, this.transform.position, Quaternion.identity);
            // enemy.GetComponent<AttackerBehavior>().StartMoving();
        }
    }
}
