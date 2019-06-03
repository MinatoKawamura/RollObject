using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreMove : MonoBehaviour
{
    float pos1 = 0.5f;
    float pos2 = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localPosition = new Vector3(pos1, 1f, pos2);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localPosition = new Vector3(pos1, 1f, pos1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localPosition = new Vector3(pos2, 1f, pos1);
        }
    }
}
