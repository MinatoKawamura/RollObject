using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum ROLL_MODE
    {
        not = 0,    //回転していない
        right = 1,  //右回転
        left = -1,  //左回転
    }
    public ROLL_MODE mode = ROLL_MODE.not;
    Transform corePos;//回転の中心のポジション
    public List<Transform> box = new List<Transform>();//プレイヤーを形成しているブロック
    public int goalCount = 0;
    Vector3 mouseDownPosition;
    Vector3 mouseUpPosition;
    float mousePositionChange = 0f;
    float MOUSE_CHANGE = 50f;

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
            else if(g_Object.tag == "Box")
            {
                box.Add(g_Object);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition();
    }

    //キー入力したら左右どちらの回転かを判断　※今後回転を滑らかにするためmodeを指定
    void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.A) && mode == ROLL_MODE.not)
        {
            mode = ROLL_MODE.left;//左回転
            Roll();
        }
        if (Input.GetKeyDown(KeyCode.D) && mode == ROLL_MODE.not)
        {
            mode = ROLL_MODE.right;//右回転
            Roll();
        }
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
        if(mousePositionChange >= MOUSE_CHANGE && mode == ROLL_MODE.not)
        {
            mode = ROLL_MODE.left;
            Roll();
        }
        if(mousePositionChange <= -MOUSE_CHANGE && mode == ROLL_MODE.not)
        {
            mode = ROLL_MODE.right;
            Roll();
        }
    }

    //回転させる
    void Roll()
    {
        //回転
        transform.RotateAround(corePos.position, transform.up, 90 * (int)mode);
        //回転後の場所にブロックが存在したらもとに戻す
        if (BoxHit())
        {
            transform.RotateAround(corePos.position, transform.up, 90 * -(int)mode);
        }
        mode = ROLL_MODE.not;//回転を止める
    }

    //回転後に通れないブロックがあるかどうかの判定
    bool BoxHit()
    {
        for(int i = 0; i < box.Count; i++)
        {
            //コライダーを配列に入れる
            Collider[] hitColliders = Physics.OverlapBox(box[i].position, new Vector3(0.25f, 0.25f, 0.25f));
            if(hitColliders.Length > 0)
            {
                for (int j = 0; j < hitColliders.Length; j++)
                {
                    if (hitColliders[j].tag == "Cube")
                    {
                        return true;//Cubeがあったらtrueを返す
                    }
                }
            }
        }
        return false;//ブロックが無かったらfalseを返す
    }
}
