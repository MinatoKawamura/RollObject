using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    Player player;
    GameObject canvas;
    public bool goalFlag = false;
    float LoadTime = 0f;
    const float LOAD_TIME_MAX = 3f;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        GoalLoadScene();
    }

    void GoalLoadScene()
    {
        if (goalFlag)
        {
            LoadTime += Time.deltaTime;
            if(LoadTime >= 5f)
            {
                goalFlag = false;
                SceneManager.LoadScene("Title");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Box")
        {
            player.goalCount++;
            if (player.goalCount >= player.box.Count)
            {
                goalFlag = true;
                canvas.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Box")
        {
            player.goalCount--;
        }
    }
}
