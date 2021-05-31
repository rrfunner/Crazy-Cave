using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    private GameManager managergame;
    public BallScript ballscript;
    public GameObject MainScreen;
    public GameObject Skinsscreen;
    public GameObject HowtoPlayscreen;
    public Text HighScore;

    public AudioClip clicksound;
    AudioSource src;

    
    private string gameId = "3956923";
    

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();

        Advertisement.Initialize(gameId, false);
        if(PlayerPrefs.GetInt("HighScore") != null)
        {
            HighScore.text = (string)" High Score : " +
                " " + PlayerPrefs.GetInt("HighScore").ToString();
        }
       
    }

    public void Playclick()
    {
        src.PlayOneShot(clicksound);
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("HighScore") <= PlayerPrefs.GetInt("LastScore"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("LastScore"));
            HighScore.text = (string)" High Score : " +  PlayerPrefs.GetInt("HighScore").ToString();
        }
        
    }

    
    public void Howtoplay()
    {
       HowtoPlayscreen.SetActive(true);
        MainScreen.SetActive(false);
        Skinsscreen.SetActive(false);
    }
    public void back()
    {
        HowtoPlayscreen.SetActive(false);
        MainScreen.SetActive(true);
        Skinsscreen.SetActive(false);
    }
    public void Play()
    {
        if (Advertisement.IsReady())
        {
           // Advertisement.Show();
            SceneManager.LoadScene(1);
        }
        SceneManager.LoadScene(1);
        
    }
    public void Skins()
    {
       // Settingscreen.SetActive(false);
        MainScreen.SetActive(false);
        Skinsscreen.SetActive(true);

    }
    public void Pause()
    {

    }
    public void Exite()
    {
        Application.Quit();
    }
}

