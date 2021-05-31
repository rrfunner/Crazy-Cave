using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BallScript : MonoBehaviour
{
    static BallScript instance;
   // SpriteRenderer ballsprite;
    Animator anim;

    Rigidbody2D Player;
    public int jump = 10;
    public int slowjump = 10;

    public int sidemovemnet = 5;
    private bool isgrounded;
    public AudioClip jumpsound;
    public AudioClip goldmaggicsound;
    public AudioClip Gameoversound;
    AudioSource src;
    public static bool playmaggic;
    public bool GameOver = false;

    public void Awake()
    {
        
    }
    void Start()
    {
       // DontDestroyOnLoad(ballsprite);
        //ballsprite = GetComponent<SpriteRenderer>();
        Player = GetComponent<Rigidbody2D>();
        src = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        Time.timeScale = 1.5f;
       // DontDestroyOnLoad(ballsprite);
    }
    private void Update()
    {
        

        if (playmaggic == true)
        {
            src.PlayOneShot(goldmaggicsound);
            playmaggic = false;
        }

        
    }
    public void Continue()
    {
        
           // ballsprite.enabled = true;

            GameOver = false;
            gameObject.SetActive(true);
            float tempy = PlayerPrefs.GetInt("LastScore");
            gameObject.transform.position = new Vector2(-10, -tempy - Random.Range(4, 7));
            PlayerPrefs.SetInt("Pressed", 0);

        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        isgrounded = true;

        if (collision.gameObject.tag == "ButtonHead")
        {

            GameOver = true;
          //  ballsprite.enabled = false;
            StartCoroutine(finallydead());

        }
       
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inctime")
        {
            Time.timeScale += 0.2f;
          
        }
    }
    public IEnumerator finallydead()
    {
        
        
            src.PlayOneShot(Gameoversound);
            anim.SetBool("Blast", true);
            yield return new WaitForSeconds(1);
            gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

     //   isgrounded = false;
    }

    public void leftjump()
    {
        if (isgrounded)
        {
            src.PlayOneShot(jumpsound);
            Player.velocity = Vector2.up * jump + Vector2.left * sidemovemnet;
           
            isgrounded = false;
        }
    } public void slowleftjump()
    {
        if (isgrounded)
        {
            src.PlayOneShot(jumpsound);
            Player.velocity = Vector2.up * slowjump + Vector2.left * sidemovemnet;
           
            isgrounded = false;
        }
    }
    public void rightjump()
    {
        if (isgrounded)
        {
            src.PlayOneShot(jumpsound);
            Player.velocity = Vector2.up * jump + Vector2.right * sidemovemnet;
           
            isgrounded = false;
        }

    }public void slowrightjump()
    {
        if (isgrounded)
        {
            src.PlayOneShot(jumpsound);
            Player.velocity = Vector2.up * slowjump + Vector2.right * sidemovemnet;
           
            isgrounded = false;
        }

    }
}