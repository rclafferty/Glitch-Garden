using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField]
    int starCost;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawned a " + gameObject.name);
        string name = gameObject.name.ToLower();
        if (name.Contains("cactus"))
        {
            starCost = 50;
        }
        else if (name.Contains("trophy"))
        {
            starCost = 25;
        }
        //starCost = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int StarsCost
    {
        get
        {
            return starCost;
        }
        set
        {
            if (value > 0)
            {
                starCost = value;
            }
        }
    }

    public void ObtainStars(int amount)
    {
        FindObjectOfType<StarDisplay>().ObtainStars(amount);
    }
}
