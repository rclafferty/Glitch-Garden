using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenBehavior : MonoBehaviour
{
    Sprite[] backgroundImages;
    Image backgroundRenderer;

    // Start is called before the first frame update
    void Start()
    {
        backgroundRenderer = GameObject.Find("Background Image").GetComponent<Image>();
        backgroundImages = Resources.LoadAll<Sprite>("Images/TitleScreenImages");
        int randomIndex = Random.Range(0, backgroundImages.Length - 1);
        backgroundRenderer.sprite = backgroundImages[randomIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
