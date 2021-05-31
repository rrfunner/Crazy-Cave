using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionLeft : MonoBehaviour
{
   public BallScript ball;
    public ParticleSystem fire; public ParticleSystem fire1;
    public GameObject RayStart; public GameObject RayEnd;
    RaycastHit2D rayhit;
    private bool fireOn;
    public int Timegap =  3;
    public LayerMask Player;
   // AudioSource src;
   // public AudioClip lionsound;
    // Start is called before the first frame update
    void Start()
    {
       // src = GetComponent<AudioSource>();
    }

    IEnumerator forfireOn()
    {
        fire.Play();
        fire1.Play();
        //src.Play();
        rayhit = Physics2D.Raycast(RayStart.transform.position, Vector2.right);
        if (ball.GameOver == false)
        {
            if (rayhit.collider.name == "Ball 001")
            {
                ball.GameOver = true;
                StartCoroutine(ball.finallydead());

            }
        }
        yield return new WaitForSeconds(4);
        fireOn = false;
    }IEnumerator forfireOff()
    {
        fire.Stop();
        fire1.Stop();
       // src.Stop();
        yield return new WaitForSeconds(5);
        fireOn = true;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (fireOn)
        {
            StartCoroutine(forfireOn());
        } 
        else if (!fireOn)
        {
            StartCoroutine(forfireOff());
        }      
    }





}
