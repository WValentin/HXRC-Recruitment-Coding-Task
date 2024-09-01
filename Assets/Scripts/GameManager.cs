using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Level;
    [SerializeField]
    private Camera mainCamera;


    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        SetLevelPositionAtBottom();
    }

    void Update()
    {
        // Call SetLevelPositionAtBottom every frame in case the game is dynamically resized
        SetLevelPositionAtBottom();
    }

    // This sets the whole level to the bottom of the screen
    void SetLevelPositionAtBottom()
    {
        // Set the position using Viewport space (0,0), which is the bottom of the screen
        Vector3 bottomPosition = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0f, mainCamera.nearClipPlane));
        // bottomPosition.z = 0; // Set z to 0 to ensure it's at the camera plane for 2D
        transform.position = bottomPosition;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
