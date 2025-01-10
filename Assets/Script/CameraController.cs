using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private bool isMoving;
    private Vector3 startPosition;
    public float moveSpeed = 10f;
    public float roomWidth = 17f;     // Jarak antar room
    private int currentRoom = 0;      // Menghitung room ke berapa

    void Start()
    {
        startPosition = new Vector3(0, 0, -10);
        transform.position = startPosition;
    }

    public void MoveToNextRoom()
    {
        if (!isMoving)
        {
            currentRoom++;
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            Vector3 targetPosition = new Vector3(roomWidth * currentRoom, 0, -10);
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
}