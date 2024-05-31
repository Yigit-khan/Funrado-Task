using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyLevel : MonoBehaviour
{
    public GameObject levelTextPrefab;
    public float levelOffsetY = 2.0f;

    private TextMeshPro levelText;

    void Start()
    {
        GameObject levelTextObject = Instantiate(levelTextPrefab, transform);

        levelText = levelTextObject.GetComponent<TextMeshPro>();

        if (levelText != null)
        {
            int level = CalculateLevelBasedOnScale();
            levelText.text = "Level " + level.ToString();

            levelText.transform.localPosition = new Vector3(0, levelOffsetY, 0);
        }
    }

    int CalculateLevelBasedOnScale()
    {
        float averageScale = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3f;
        int level = Mathf.CeilToInt(averageScale);

        return level;
    }
}
