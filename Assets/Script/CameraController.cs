using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private bool isMoving;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    public float moveSpeed = 10f;

    void Start()
    {
        startPosition = new Vector3(0, 0, -10);
        targetPosition = new Vector3(17, 0, -10);
        transform.position = startPosition;
    }

    // Tambahkan fungsi ini
    public void MoveToNextRoom()
    {
        if (!isMoving)
        {
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
}