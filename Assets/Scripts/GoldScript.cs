using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript : MonoBehaviour
{
  public  ParticleSystem particle;
//  public  Score callUpdate;
   
    

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerPrefs.GetInt("Gold");
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        BallScript.playmaggic = true;
        particle = Instantiate(particle, transform.position, transform.rotation);
        particle.Play();
        Destroy(this.gameObject);
        
        if (gameObject.tag == "Gold100")
        {
            int a = PlayerPrefs.GetInt("Gold");
            PlayerPrefs.SetInt("Gold", a +  Random.Range(1 ,10));


        }
     //   callUpdate.Update();
        
        

    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
