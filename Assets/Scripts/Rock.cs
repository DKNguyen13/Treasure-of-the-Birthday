using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private GameObject GameObject;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (Transform t in gameObject.transform)
            {
                t.gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (Transform t in gameObject.transform)
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}
