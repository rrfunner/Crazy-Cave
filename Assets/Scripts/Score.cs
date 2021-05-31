using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Score : MonoBehaviour
{
    public Text TotalGold;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    
    // Update is called once per frame
   public void Update()
    {
        TotalGold.text = PlayerPrefs.GetInt("Gold").ToString();
       
    }
}
