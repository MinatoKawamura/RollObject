using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum ROLL_MODE
    {
        not,    //回転していない
        right,  //右回転
        reft,   //左回転
    }
    ROLL_MODE mode = ROLL_MODE.not;
    Vector3 pos;
    float rollCount = 0;
    const float ROLL_MAX = 90f;
    const float ROLL_TIME = 2f;
    Transform corePos;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform core in gameObject.transform)
        {
            if (core.name == "Core")
            {
                corePos = core.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rollCount);
        //inputKey();
        if (Input.GetKeyDown(KeyCode.A))
        {
            //transform.Rotate(new Vector3(0f, rollSpeed() * Time.deltaTime));
            transform.RotateAround(corePos.position, transform.up, ROLL_MAX);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //transform.Rotate(new Vector3(0f, -rollSpeed() * Time.deltaTime));
            transform.RotateAround(corePos.position, transform.up, -ROLL_MAX);
        }
    }

    //void roll()
    //{

    //}

    //void inputKey()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        mode = ROLL_MODE.reft;
    //    }
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        mode = ROLL_MODE.right;
    //    }
    //}

    float rollSpeed()
    {
        return ROLL_MAX / ROLL_TIME;
    }
}
