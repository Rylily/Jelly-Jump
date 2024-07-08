using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public GameObject Platform;
    public int numberofplatforms;
    public int Xpos;
    public int Ypos;
    public int distance;
    public bool Gamestart;
    public GameObject Camera;
    public float playerpos;
    public float highestpos;
    public bool Gameend;
    public bool message;
    public bool end;
    public AudioSource audioSource;
    public AudioClip bgmClip;
    public AudioClip LoseClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.Play();
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        highestpos = this.GetComponent<Transform>().position.y;
        for(int i=0; i<numberofplatforms; i++)
        {
            Xpos = Random.Range(-6, 6);
            GameObject Theplatform=Instantiate(Platform);
            Theplatform.transform.position = new Vector2(Xpos, Ypos + (distance * i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying=false;
#endif
            Application.Quit();
        }
        if (end == true && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Level2");
        }
        if (end == false)
        {
            playerpos = this.GetComponent<Transform>().position.y;
            if (playerpos > highestpos)
            {
                highestpos = playerpos;
            }
            if (playerpos < highestpos - 6)
            {
                Gameend = true;
            }
            if (Gameend == true)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
                message = true;
                audioSource.Stop();
                audioSource.PlayOneShot(LoseClip);
                Debug.Log("You Lose!");
                end = true;
            }

            else if (Gameend == false)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, -20);
                    this.GetComponent<Rigidbody2D>().gravityScale = 1;
                    Gamestart = true;
                }
                if (Gamestart == true && Gameend == false)
                {
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        this.GetComponent<Rigidbody2D>().velocity = new Vector2(5, this.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, this.GetComponent<Rigidbody2D>().velocity.y);
                    }
                }
            }
        }
    }
}
