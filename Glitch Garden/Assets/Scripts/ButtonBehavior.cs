using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    GameObject defenderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
        defenderPrefab = Resources.Load<GameObject>("Prefabs/" + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]
    GameObject[] allButtons;

    private void OnMouseDown()
    {
        allButtons = GameObject.FindGameObjectsWithTag("Defender Button");

        foreach (GameObject g in allButtons)
        {
            g.GetComponent<SpriteRenderer>().color = Color.gray;
        }

        GetComponent<SpriteRenderer>().color = Color.white;

        GameObject.Find("Defender Spawner").GetComponent<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        Debug.Log("Clicked on " + gameObject.name + ", Cost = " + defenderPrefab.GetComponent<Defender>().StarsCost);
    }
}

