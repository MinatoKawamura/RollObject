using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform pPos;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(transform.position.x, transform.position.y, pPos.position.z);
        transform.position = pos;
    }
}
