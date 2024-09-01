using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitchController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 90f; // The speed of the rotation of the color switch

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
