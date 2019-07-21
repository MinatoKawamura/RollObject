using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Box")
        {
            player.goalCount++;
            if (player.goalCount >= player.box.Count)
            {
                Debug.Log("クリア");
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
