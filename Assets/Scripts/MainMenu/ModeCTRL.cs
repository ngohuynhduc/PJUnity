using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeCTRL : MonoBehaviour
{
    public Button btnMode4;
    public Button btnMode3;
    public Button btnMode1;
    public Button btnMode2;
    public Button btnBack;
    public Sprite btnBackIdle;
    public Sprite btnBackHover;
    public Image black;
    public Animator anim;
    public float transitionsTime = 1f;
    public void BackClick()
    {
        StartCoroutine(Fading(SceneManager.GetActiveScene().buildIndex - 1));
    }
    public void BackButtonIdle()
    {
        btnBack.GetComponent<Image>().sprite = btnBackIdle;
    }
    public void BackButtonHover()
    {
        btnBack.GetComponent<Image>().sprite = btnBackHover;
    }
    public void Mode1()
    {
        StartCoroutine(Fading(SceneManager.GetActiveScene().buildIndex + 2));
    }
    public void Mode2()
    {
        StartCoroutine(Fading(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void Mode3()
    {
        StartCoroutine(Fading(SceneManager.GetActiveScene().buildIndex + 3));
    }
    public void Mode4()
    {
        StartCoroutine(Fading(SceneManager.GetActiveScene().buildIndex + 4));
    }
    IEnumerator Fading(int index)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(transitionsTime);
        SceneManager.LoadScene(index);
    }
}

