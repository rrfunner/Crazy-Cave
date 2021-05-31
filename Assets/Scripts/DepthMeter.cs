using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DepthMeter : MonoBehaviour
{
    public Transform Player;
    private float temp;
    private int convert;
    public Text Score;
    private string Meters = " m ";
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        temp  = Player.transform.position.y;
        convert = (int)temp;
        convert = -(convert);
        Score.text = convert.ToString() + Meters;
        PlayerPrefs.SetInt("LastScore", convert);
    }
}
