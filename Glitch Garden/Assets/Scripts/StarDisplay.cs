using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    Text starsText;
    int stars;

    // Start is called before the first frame update
    void Start()
    {
        starsText = GameObject.Find("Star Text").GetComponent<Text>();
        stars = 150;

        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CurrentStars
    {
        get
        {
            return stars;
        }
    }

    public void Purchase(Defender d)
    {
        if (stars >= d.StarsCost)
        {
            stars -= d.StarsCost;
            UpdateDisplay();
        }
    }

    public void Purchase(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

    public void ObtainStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starsText.text = stars.ToString();
    }
}
