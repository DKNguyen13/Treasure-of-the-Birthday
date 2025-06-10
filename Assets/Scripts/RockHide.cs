using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHide : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    private GameObject spawnedObject;
    private Vector3 spawnPosition;
    private float xOffset = 58.25f, yOffset = -1.274932f;
    private float x, y;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
       spawnPosition = new Vector3(xOffset, yOffset, -0.02690177f);
    }

    private void Update()
    {
        if(count < 6)
        {
            // Instantiate objectPrefab at spawnPosition
            spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            x = Random.Range(3f, 4f);
            y = Random.Range(0.1f, 0.3f);
            xOffset += x;
            yOffset += y;
            spawnPosition = new Vector3(xOffset, yOffset, -0.02690177f);
            // Hide child objects initially
            ToggleChildObjects(false);
            count++;
        }
    }
    // Toggle visibility of child objects
    void ToggleChildObjects(bool show)
    {
        foreach (Transform child in spawnedObject.transform)
        {
            child.gameObject.SetActive(show);
        }
    }

    
        
}
