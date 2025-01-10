using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    private CameraController cameraController;

    void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraController.MoveToNextRoom();
            gameObject.SetActive(false);
        }
    }
}