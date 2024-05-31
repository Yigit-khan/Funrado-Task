using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTextController : MonoBehaviour
{
    public Transform target; 
    public TextMeshProUGUI levelTextPrefab;
    private TextMeshProUGUI levelTextInstance;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        if (levelTextPrefab != null)
        {
            levelTextInstance = Instantiate(levelTextPrefab, transform);
        }
        else
        {
            Debug.LogError("LevelTextPrefab is not assigned!");
            return;
        }
    }

    void LateUpdate()
    {
        if (target != null && levelTextInstance != null)
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position); // Hedefin d�nya pozisyonunu ekran koordinatlar�na d�n��t�r
            levelTextInstance.rectTransform.position = screenPos + new Vector3(0, 50, 0); // Metni biraz yukar�ya yerle�tir

            Vector3 direction = (mainCamera.transform.position - levelTextInstance.rectTransform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            levelTextInstance.rectTransform.rotation = lookRotation;
        }
    }
}
