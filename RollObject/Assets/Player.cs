using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum rollMode
    {
        not,
        right,
        reft,
    }
    float rollCount = 0;
    const float ROLL_MAX = 90f;
    const float ROLL_TIME = 1f;
    const float ROLL_SPEED = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rollCount);
    }
}
