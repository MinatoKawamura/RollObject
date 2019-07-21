using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreMove : MonoBehaviour
{
    Vector3 mouseDownPosition;
    Vector3 mouseUpPosition;
    float mousePositionChange = 0f;
    float MOUSE_CHANGE = 50f;

    void Update()
    {
        MousePosition();
    }

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
        Debug.Log(mousePositionChange);
        if (mousePositionChange <= MOUSE_CHANGE && mousePositionChange >= -MOUSE_CHANGE)
        {
            TapCoreMove();
        }
    }

    //クリックした場所に回転の中心(Core)を移動させる※今後タッチにも対応させる
    void TapCoreMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "Box")
            {
                Vector3 hitPos = hit.collider.gameObject.transform.position;
                hitPos.y = transform.position.y;
                transform.position = hitPos;
            }
        }
    }
}
