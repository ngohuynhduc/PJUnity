using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour
{
    public Button btnPlay;
    public Button btnExit;
    public Button btnSetting;
    public Sprite btnPlayIdle;
    public Sprite btnPlayHover;
    public Sprite btnExitIdle;
    public Sprite btnExitHover;
    public Sprite btnSettingHover;
    public Sprite btnSettingIdle;
    public string url;
    public float transitionsTime = 1f;
    public Animator anim;
    public Animator aw;
    // Start is called before the first frame update
    public void PlayClick()
    {
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       StartCoroutine(Fading(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void ExitClick()
    {
        //  Debug.Log("Quitttt!");
        Application.Quit();
    }
    public void FaceBookClick()
    {
        Application.OpenURL(url);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayButtonIdle()
    {
        btnPlay.GetComponent<Image>().sprite = btnPlayIdle;
    }
    public void PlayButtonHover()
    {
        btnPlay.GetComponent<Image>().sprite = btnPlayHover;
    }
    public void ExitButtonIdle()
    {
        btnExit.GetComponent<Image>().sprite = btnExitIdle;
    }
    public void ExitButtonHover()
    {
        btnExit.GetComponent<Image>().sprite = btnExitHover;
    }
    public void SettingButtonIdle()
    {
        btnSetting.GetComponent<Image>().sprite = btnSettingIdle;
    }
    public void SettingButtonHover()
    {
        btnSetting.GetComponent<Image>().sprite = btnSettingHover;
    }
     IEnumerator Fading(int index)
     {
          anim.SetTrigger("Start");
        yield return new WaitForSeconds(transitionsTime);
        SceneManager.LoadScene(index);
     }
    public void Awake()
    {
        Time.timeScale = 1;
    }
} 
