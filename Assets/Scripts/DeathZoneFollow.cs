using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneFollow : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;  // Reference to the main camera
    [SerializeField]
    private float yOffset = -5f; // Offset to place the death zone slightly below the bottom of the screen

    void Update()
    {
        // Calculate the position at the bottom of the camera's view
        Vector3 cameraBottomPosition = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0, 0));
        
        // Set the death zone's Y position to the camera bottom position with an offset
        transform.position = new Vector3(transform.position.x, cameraBottomPosition.y + yOffset, transform.position.z);
    }
}
