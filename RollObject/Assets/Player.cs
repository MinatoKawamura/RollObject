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
    ROLL_MODE mode = ROLL_MODE.not;
    const float ROLL_MAX = 90f;
    const float ROLL_TIME = 2f;
    Transform corePos;
    float rollCount = 0f;
    List<Transform> box = new List<Transform>();

    //test
    Rigidbody rBody;
    Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        //回転の中心のオブジェクトを取得する
        foreach (Transform g_Object in gameObject.transform)
        {
            if (g_Object.name == "Core")
            {
                corePos = g_Object.transform;
            }
            else
            {
                box.Add(g_Object);
            }
        }
        //test
        rBody = GetComponent<Rigidbody>();
        speed = new Vector3(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        inputKey();
        roll();
    }

    //キー入力したら左右どちらの回転かを判断
    void inputKey()
    {
        if (Input.GetKeyDown(KeyCode.A) && mode == ROLL_MODE.not)
        {
            mode = ROLL_MODE.right;
        }
        if (Input.GetKeyDown(KeyCode.D) && mode == ROLL_MODE.not)
        {
            mode = ROLL_MODE.left;
        }
    }

    //回転させる
    void roll()
    {
        if (rollCount < ROLL_MAX)
        {
            transform.RotateAround(corePos.position, transform.up, 90 * (int)mode);
            mode = ROLL_MODE.not;
        }
    }

    void TestRoll()
    {
        transform.RotateAround(corePos.position, transform.up, 90 * (int)mode);
        for(int i = 0; i > box.Count; i++)
        {
            Collider[] hitColliders = Physics.OverlapBox();
        }
    }
}
