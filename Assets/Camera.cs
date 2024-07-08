using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    public float playerpos;
    public float highestpos;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        highestpos = Player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerpos= Player.transform.position.y;
        if (playerpos > highestpos)
        {
            highestpos = playerpos;
            this.GetComponent<Transform>().position = new Vector3(0, Player.GetComponent<Transform>().position.y, -10);
        }
    }
}
