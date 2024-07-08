using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetection : MonoBehaviour
{
    public GameObject Player;
    public GameObject Platform;
    public float Platformpos;
    public float Playerpos;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Platform = this.gameObject;
        //Playerpos = Player.GetComponent<Transform>().position.y;
        Platformpos = this.gameObject.GetComponent<Transform>().position.y;
    }   

    // Update is called once per frame
    void Update()
    {
        Playerpos= Player.transform.position.y;
        if(Playerpos<Platformpos)
        {
            this.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<Collider2D>().enabled = true;
        }
    }
}
