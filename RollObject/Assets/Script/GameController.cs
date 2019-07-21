using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector3 mouseDownPosition;
    Vector3 mouseUpPosition;
    float mousePositionChange = 0f;
    float MOUSE_CHANGE = 1f;

    void MousePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseUpPosition = Input.mousePosition;
            MousePositionChange();
        }
    }

    void MousePositionChange()
    {
        mousePositionChange = mouseDownPosition.x - mouseUpPosition.x;
    }
}