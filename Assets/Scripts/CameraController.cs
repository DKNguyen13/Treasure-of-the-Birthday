using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    //Room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float smoothTime; // Thời gian để camera dịu dần chuyển động
    // Update is called once per frame
    void Update()
    {
        //Room camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX,transform.position.y,transform.position.z),ref velocity,speed );
        //Follow player 
        if(player.position.x > -0.75f && player.position.x <= 153f)
        {
            Vector3 targetPosition = new Vector3(player.position.x, 0, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else if(player.position.x >= 153f)
        {
            Vector3 xyz = new Vector3(player.position.x,player.position.y,transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, xyz, ref velocity, smoothTime);
        }

    }
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
