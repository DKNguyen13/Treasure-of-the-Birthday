using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{

    [SerializeField] private float min, max, speed;

    private bool movingRight = true;

    private GameObject player;

    private Transform originalParent;
    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if(transform.position.x >= max)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if(transform.position.x <= min)
            {
                movingRight = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject; // Set the player GameObject when collision occurs
            originalParent = player.transform.parent; // Store the original parent
            player.transform.parent = transform; // Make the player a child of the platform
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.parent = originalParent; // Reset the parent to the original
        }
    }

}
