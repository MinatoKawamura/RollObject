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
    Transform corePos;//回転の中心のポジション
    public List<Transform> box = new List<Transform>();//オブジェクトを形成している

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform g_Object in gameObject.transform)
        {
            //回転の中心のオブジェクトを取得する
            if (g_Object.name == "Core")
            {
                corePos = g_Object.transform;
            }
            //回転の中心以外のオブジェクトを取得する
            else
            {
                box.Add(g_Object);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        inputKey();
    }

    //キー入力したら左右どちらの回転かを判断
    void inputKey()
    {
        if (Input.GetKeyDown(KeyCode.A) && mode == ROLL_MODE.not)
        {
            mode = ROLL_MODE.left;//左回転
            roll();
        }
        if (Input.GetKeyDown(KeyCode.D) && mode == ROLL_MODE.not)
        {
            mode = ROLL_MODE.right;//右回転
            roll();
        }
    }

    //回転させる
    void roll()
    {
        //回転
        transform.RotateAround(corePos.position, transform.up, 90 * (int)mode);
        //回転後の場所にブロックが存在したらもとに戻す
        if (boxHit())
        {
            transform.RotateAround(corePos.position, transform.up, 90 * -(int)mode);
        }
        mode = ROLL_MODE.not;//回転を止める
    }

    //回転後にブロックがあるかどうかの判定
    bool boxHit()
    {
        for(int i = 0; i < box.Count; i++)
        {
            Collider[] hitColliders = Physics.OverlapBox(box[i].position, new Vector3(0.25f, 0.25f, 0.25f));
            if(hitColliders.Length > 0)
            {
                return true;//ブロックがあったらtrueを返す
            }
        }
        return false;//ブロックが無かったらfalseを返す
    }
}
