using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour, IUnityAdsListener
{
   
    [SerializeField]
    BallScript ballScript;
    [SerializeField]
    public GameObject SettingCanva;
    [SerializeField]
    public GameObject GameOverCanvas;
    [SerializeField]
    public GameObject GameCanvas;
    [SerializeField]
    public Text hehetextgameover;
    [SerializeField]
    public Text lastscoretext;
    public GameObject Ball001;
    [SerializeField]
    public string[] hehe = {"You need more patients !" , "Lol ! its ok XD" , "You're a true gamer! Don't Give Up" , "hehe ! You Played well" , "Its not much tough bruhh" , "I know you can do better" };
    [SerializeField]
    public Image ButtonUpper1;
    [SerializeField]
    public Image ButtonUpper2;
    [SerializeField]
    public Image LowerUpper1;
    [SerializeField]
    public GameObject LoadingCanva;
    [SerializeField]
    public Slider slider;
    [SerializeField]
    public GameObject pausebutton;
    //[SerializeField]
  //  public GameObject Backbutton;
    [SerializeField]
    public Image LowerUpper2;

    string gameID = "3956923";
    string adsId = "rewardedVideo";
    public Text text;
    
    public bool adfinished;

    public AudioClip clicksound;
    AudioSource src;
    private void Awake()
    {
        SceneManager.MoveGameObjectToScene(Ball001, SceneManager.GetActiveScene());
        LoadingCanva.SetActive(true);
        
        GameCanvas.SetActive(false); 
        GameOverCanvas.SetActive(false);
        SettingCanva.SetActive(false);
        StartCoroutine(loadingwait());
    }
    void Start()
    {
        src = GetComponent<AudioSource>();
        ballScript = FindObjectOfType<BallScript>();
        {
            Advertisement.AddListener(this);
            PlayerPrefs.SetInt("AdsWatch", 0);
            Advertisement.Initialize(gameID, false);
        }

        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }

        PlayerPrefs.SetInt("printhehe", 0);
        Color color = ButtonUpper1.color;
        color.a = PlayerPrefs.GetFloat("Buttonupper1");
        ButtonUpper1.color = color;
        Color color2 = ButtonUpper2.color;
        color2.a = PlayerPrefs.GetFloat("Buttonupper2");
        ButtonUpper2.color = color2;
        Color color3 = LowerUpper1.color;
        color3.a = PlayerPrefs.GetFloat("Lowerupper1");
        LowerUpper1.color = color3;
        Color color4 = LowerUpper2.color;
        color4.a = PlayerPrefs.GetFloat("Lowerupper2");
        LowerUpper2.color = color4;

    }

    public void Playclick()
    {
        src.PlayOneShot(clicksound);
    }
   IEnumerator loadingwait()
    {
        slider.value = 0.2f;
        yield return new WaitForSeconds(Random.Range(1, 2));
        slider.value = 0.5f;
        yield return new WaitForSeconds(Random.Range(1, 4));
        slider.value = 0.8f;
        yield return new WaitForSeconds(Random.Range(1, 2));
        slider.value = 0.99f;
        yield return new WaitForSeconds(0.5f);
        LoadingCanva.SetActive(false);
        GameCanvas.SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {
       
        if (ballScript.GameOver == true)
        {
            
            printmsg();
            lastscoretext.text = PlayerPrefs.GetInt("LastScore").ToString() + (string)" Meters ";
            StartCoroutine(pausetime());
            GameOverCanvas.SetActive(true);
            GameCanvas.SetActive(false);
           
        }
        
    }
    public void SetTransparency(float transparency)
    {
        #region trasparency
        //transparency is a value in the [0,1] range
        Color color = ButtonUpper1.color;
        color.a = transparency;
        PlayerPrefs.SetFloat("Buttonupper1", transparency);
        ButtonUpper1.color = color;
        Color color2 = ButtonUpper2.color;
        color2.a = transparency;
        PlayerPrefs.SetFloat("Buttonupper2", transparency);
        ButtonUpper2.color = color2;
        Color color3 = LowerUpper1.color;
        color3.a = transparency;
        PlayerPrefs.SetFloat("Lowerupper1", transparency);
        LowerUpper1.color = color3;
        Color color4 = LowerUpper2.color;
        color4.a = transparency;
        PlayerPrefs.SetFloat("Lowerupper2", transparency);
        LowerUpper2.color = color4;
        #endregion
    }
    void printmsg()
    { 
        if (PlayerPrefs.GetInt("printhehe") == 0)
        {
            hehetextgameover.text = hehe[Random.Range(1, 6)];
            PlayerPrefs.SetInt("printhehe", 1);
        }       
    }
    public void Restart()
    {
       // DontDestroyOnLoad(ballScript);
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("printhehe", 0);
       // Time.timeScale = 1;
        GameOverCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        ballScript.GameOver = false;
        SettingCanva.SetActive(false);
    }
     public void Home()
    {
       // DontDestroyOnLoad(ballScript);
        SceneManager.LoadScene(0);
    }

    public void Setting()
    {
        
        
            SettingCanva.SetActive(true);
            GameOverCanvas.SetActive(false);
            GameCanvas.SetActive(true);
            pausebutton.SetActive(false);
            
       

    }   public void Back()
    {
        
        
            SettingCanva.SetActive(false);
            GameOverCanvas.SetActive(false);
            GameCanvas.SetActive(true);
            pausebutton.SetActive(true);
            
       

    }
    public void ContinuewithAds()
    {
        OnUnityAdsReady(adsId);
        if (Advertisement.IsReady(adsId) && (PlayerPrefs.GetInt("AdsWatch") == 0 || PlayerPrefs.GetInt("AdsWatch") == 1) ) 
        {
            
            Advertisement.Show(adsId);
        }
        else if(PlayerPrefs.GetInt("AdsWatch") == 2)
        {
            text.text = "You crossed the limit";
            i = 0;
        }
       
            
    }

    int i = 0;
    IEnumerator pausetime()
    {
        yield return new WaitForSeconds(1);
       // Time.timeScale = 0;
    }

    public void OnUnityAdsReady(string placementId)
    {
        placementId = adsId;
    }

    public void OnUnityAdsDidError(string message)
    {
        text.text = "Connection Failure";
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        
        if (showResult == ShowResult.Finished)
        {
            i++;
            adfinished = true;
            ballScript.Continue();
         
            PlayerPrefs.SetInt("AdsWatch", i);
            ballScript.GameOver = false;
            PlayerPrefs.SetInt("printhehe", 0);
            GameOverCanvas.SetActive(false);
            GameCanvas.SetActive(true);
        }
        else if (showResult == ShowResult.Skipped)
        {
            
        }
        else if (showResult == ShowResult.Failed)
        {
           
        }

        
    }
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

}
