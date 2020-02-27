using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawners;

    GameObject attackerPrefab;
    bool spawn;

    // const float MIN_SPAWN_DELAY = 10.0f;
    // const float MAX_SPAWN_DELAY = 15.0f;

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
        float delayTime = 14.0f;
        // float delayShortenTime = 0.01f;
        while (spawn)
        {
            yield return new WaitForSeconds(delayTime);
            if (delayTime > 3.0f)
            {
                delayTime -= Time.deltaTime * 2;
                if (delayTime < 3.0f)
                {
                    delayTime = 3.0f;
                }
            }
            int spawnerIndex = Random.Range(0, spawners.Length);
            Instantiate(attackerPrefab, spawners[spawnerIndex].transform.position, Quaternion.identity);
        }

        /* if (firstSpawn)
        {
            firstSpawn = false;
            yield return new WaitForSeconds(30);
        }
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(MIN_SPAWN_DELAY, MAX_SPAWN_DELAY));
            GameObject enemy = Instantiate(attackerPrefab, this.transform.position, Quaternion.identity);
            // enemy.GetComponent<AttackerBehavior>().StartMoving();
        } */
    }
}
