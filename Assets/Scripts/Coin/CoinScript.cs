using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float moveLeft;
    public float oldPosition;
    public float minRange;
    public float maxRange;
    private GameObject gObj;
    public Transform respawnPoint;
    private AudioSource audioSource;
    public AudioClip Getcoin;

    // Start is called before the first frame update
    void Start()
    {
        gObj = gameObject;
        oldPosition = 10;
        moveLeft = 4;
        maxRange = 1;
        minRange = -2;
        audioSource = gObj.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        gObj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveLeft, 0, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("RsWalls"))
            gObj.transform.position = new Vector3(oldPosition, Random.Range(minRange, maxRange + 2), 0);
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.clip = Getcoin;
            audioSource.Play();
            gameObject.transform.position = respawnPoint.transform.position;
        }
    }
}
