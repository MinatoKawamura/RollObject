using UnityEngine;

public class CoreMove : MonoBehaviour
{
    void Update()
    {
        TapCoreMove();
    }

    //クリックした場所に回転の中心(Core)を移動させる※今後タッチにも対応させる
    void TapCoreMove()
    {
        if (Input.GetMouseButtonDown(0))
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
}
