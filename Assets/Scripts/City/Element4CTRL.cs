using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element4CTRL : MonoBehaviour
{
    public float flyForce = 145;
    //Tạo biến để thao tác với âm thanh
    public AudioClip clickSound;
    public AudioClip gameOver;
    //public AudioClip GetCoin;
    private AudioSource audioSource;
    private Animator anime;
    GameObject gObj;
    GameObject gameCtrl;
    // Start is called before the first frame update
    void Start()
    {
        gObj = gameObject;
        audioSource = gObj.GetComponent<AudioSource>();
        audioSource.clip = clickSound;
        anime = gObj.GetComponent<Animator>();
        anime.SetBool("isDead", false);
        gameCtrl = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        //Tạo lực đẩy nhân vật khi nhấn chuột trái
        if (Input.GetMouseButton(0))
        {
            if (!gameCtrl.GetComponent<Game4Ctrl>().isEndGame)
                audioSource.Play();
            gObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyForce));
        }

    }
    //Hàm xử lý va chạm
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }
    //Hàm tăng điểm khi va chạm
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // audioSource.clip = GetCoin;
        //audioSource.Play();
        gameCtrl.GetComponent<Game4Ctrl>().GetPoint();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EndGame();
        }
    }
    //Hàm EndGame
    public void EndGame()
    {
        anime.SetBool("isDead", true);
        audioSource.clip = gameOver;
        audioSource.Play();
        gameCtrl.GetComponent<Game4Ctrl>().EndGame();
    }
}
