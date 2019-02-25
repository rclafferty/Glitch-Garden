using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    GameObject[,] spawnGrid;
    const int GRID_ROWS = 5;
    const int GRID_COLS = 7;

    const int TROPHY_COST = 100;
    const int CACTUS_COST = 200;

    [SerializeField]
    GameObject defenderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnGrid = new GameObject[GRID_COLS, GRID_ROWS]; // 5 rows, 7 columns
        for (int i = 0; i < GRID_COLS; i++)
        {
            for (int j = 0; j < GRID_ROWS; j++)
            {
                spawnGrid[i, j] = null; // No attacker there yet
            }
        }

        // defenderPrefab = Resources.Load<GameObject>("Prefabs/Cactus");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (defenderPrefab == null)
                return;

            Defender thisDefender = defenderPrefab.GetComponent<Defender>();
            string defenderName = defenderPrefab.name.ToLower();

            if (defenderName.Contains("trophy"))
            {
                thisDefender.StarsCost = 50;
            }
            else if (defenderName.Contains("cactus"))
            {
                thisDefender.StarsCost = 100;
            }

            Vector3 mousePosition = Input.mousePosition;
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);
            int x = RoundUp(worldPos.x);
            int y = RoundUp(worldPos.y);

            if (x >= GRID_COLS || y >= GRID_ROWS || x < 0 || y < 0)
            {
                return;
            }

            if (spawnGrid[x, y] == null)
            {
                // Spawn defender at that grid location
                int cost = thisDefender.StarsCost;
                StarDisplay sd = FindObjectOfType<StarDisplay>();

                Debug.Log("Current amount: " + sd.CurrentStars + ", Cost: " + cost);

                if (sd.CurrentStars >= cost)
                {
                    spawnGrid[x, y] = Instantiate(defenderPrefab, new Vector3(x + 1, y + 1), Quaternion.identity);
                    sd.Purchase(cost);
                }
            }
            else
            {
                return;
            }

            // Debug.Log("X = " + x + " Y = " + y);
        }
    }

    int RoundUp(float mousePosition)
    {
        float offset = mousePosition % 1;
        //Debug.Log(offset);
        if (mousePosition % 1 < 0.5f)
        {
            return ((int)mousePosition) - 1;
        }
        else
        {
            return ((int)mousePosition);
        }
    }

    public void SetSelectedDefender(GameObject selected)
    {
        defenderPrefab = selected;
    }
}
