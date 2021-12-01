using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game3Ctrl : MonoBehaviour
{
    // Start is called before the first frame update
    //Tạo biến kiểm tra xem trò chơi đã kết thúc hay chưa?
    public bool isEndGame;
    bool isFirstTime;
    int gamePoint = 0;
    public Text txtPoint;
    public GameObject panelScore;
    public Text txtScore;
    public Button btnReplay;
    public Button btnExit;
    public Button btnHome;
    //Replay
    public Sprite btnReplayIdle;
    public Sprite btnReplayHover;
    public Sprite btnReplayClick;
    //Exit
    public Sprite btnExitIdle;
    public Sprite btnExitHover;
    public Sprite btnExitClick;
    //Home
    public Sprite btnHomeIdle;
    public Sprite btnHomeHover;
    public Sprite btnHomeClick;
    // public float transitionsTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //Khởi tạo màn chơi bằng cách dừng thời gian
        Time.timeScale = 0;
        isFirstTime = true;
        isEndGame = false;
        panelScore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            //Cấu trúc load lại màn chơi nếu isEndGame=true(Gameover)
            if (Input.GetMouseButtonDown(0) && isFirstTime)
            {
                StartGame();
            }
        }
        else
        {
            //Cấu trúc bắt đầu chơi
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
            }
        }
    }
    public void ReplayBtnClick()
    {
        btnReplay.GetComponent<Image>().sprite = btnReplayClick;
    }
    public void ReplayBtnIdle()
    {
        btnReplay.GetComponent<Image>().sprite = btnReplayIdle;
    }
    public void ReplayBtnHover()
    {
        btnReplay.GetComponent<Image>().sprite = btnReplayHover;
    }
    public void ExitBtnClick()
    {
        btnExit.GetComponent<Image>().sprite = btnExitClick;
    }
    public void ExitBtnIdle()
    {
        btnExit.GetComponent<Image>().sprite = btnExitIdle;
    }
    public void ExitBtnHover()
    {
        btnExit.GetComponent<Image>().sprite = btnExitHover;
    }
    public void HomeBtnClick()
    {
        btnHome.GetComponent<Image>().sprite = btnHomeClick;
    }
    public void HomeBtnIdle()
    {
        btnHome.GetComponent<Image>().sprite = btnHomeIdle;
    }
    public void HomeBtnHover()
    {
        btnHome.GetComponent<Image>().sprite = btnHomeHover;
    }
    //Hàm tăng điểm
    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "" + gamePoint.ToString();
    }
    void StartGame()
    {
        SceneManager.LoadScene(4);
    }
    public void Restart()
    {
        StartGame();
    }
    public void BackHome()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void EndGame()
    {
        //Gameover bằng cách dừng thời gian
        isEndGame = true;
        isFirstTime = false;
        Time.timeScale = 0;
        panelScore.SetActive(true);
        txtScore.text = "" + gamePoint.ToString();

    }
}
