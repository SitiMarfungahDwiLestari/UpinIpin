using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;
    [SerializeField] private float previousRoomCameraX = 0f;
    [SerializeField] private float nextRoomCameraX = 21.68f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom, nextRoomCameraX);
            }
            else
            {
                cam.MoveToNewRoom(previousRoom, previousRoomCameraX);
            }
        }
    }
}
