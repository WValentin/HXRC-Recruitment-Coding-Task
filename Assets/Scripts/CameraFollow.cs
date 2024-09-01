using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform ballTransform; // Reference to the ball/player object
    [SerializeField]
    public float yOffset = 2.0f; // Offset to keep some space between the ball and the top of the camera view

    
    private float highestYPosition; // To track the highest Y position the ball has reached

    void Start()
    {
        // Initialize the highest Y position to the camera's starting Y position
        highestYPosition = transform.position.y;
    }

    void Update()
    {
        // Check if the ball's current Y position is higher than the highest recorded position
        if (ballTransform.position.y > highestYPosition)
        {
            // Update the highest Y position
            highestYPosition = ballTransform.position.y;

            // Move the camera upwards to follow the ball
            Vector3 newPosition = transform.position;
            newPosition.y = highestYPosition + yOffset; // Add offset to keep some space
            transform.position = newPosition;
        }
    }
}
