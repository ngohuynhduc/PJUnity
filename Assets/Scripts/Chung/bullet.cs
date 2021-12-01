using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject explodeEff;
    public GameObject DeadExplode;
    public AudioClip shootSound;
    public AudioClip explodeSound;
    private AudioSource audSource;
    // Start is called before the first frame update
    void Start()
    {
        audSource = gameObject.GetComponent<AudioSource>();
        audSource.clip = shootSound;
        audSource.Play();
        rb.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explodeEff, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            audSource.clip = explodeSound;
            audSource.Play();
            Instantiate(DeadExplode, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
