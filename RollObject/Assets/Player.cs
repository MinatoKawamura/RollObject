using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum ROLL_MODE
    {
        not = 0,    //回転していない
        right = 1,  //右回転
        left = -1,  //左回転
    }
    //IEnumerator roll;
    ROLL_MODE mode = ROLL_MODE.not;
    const float ROLL_MAX = 90f;
    const float ROLL_TIME = 2f;
    Transform corePos;
    float rollCount = 0f;
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
        inputKey();
        roll();
    }

    void inputKey()
    {
        if (Input.GetKeyDown(KeyCode.A) && mode == ROLL_MODE.not)
        {
            mode = ROLL_MODE.right;
            //roll = Roll();
            //StartCoroutine(roll);
        }
        if (Input.GetKeyDown(KeyCode.D) && mode == ROLL_MODE.not)
        {
            mode = ROLL_MODE.left;
            //roll = Roll();
            //StartCoroutine(roll);
        }
    }

    //IEnumerator Roll()
    //{
    //    while (true)
    //    {
    //        transform.RotateAround(corePos.position, transform.up, rollSpeed() * (int)mode);
    //        yield return new WaitForSeconds(ROLL_TIME);
    //    }
    //}

    void roll()
    {
        if (rollCount < ROLL_MAX)
        {
            transform.RotateAround(corePos.position, transform.up, rollSpeed() * (int)mode * Time.deltaTime);
            rollCount += rollSpeed() * Time.deltaTime;
        }
        else
        {
            rollCount = 0f;
            mode = ROLL_MODE.not;
        }
    }

    float rollSpeed()
    {
        return ROLL_MAX / ROLL_TIME;
    }
}
