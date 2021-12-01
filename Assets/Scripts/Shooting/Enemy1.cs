using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float EnemyMoveLeft;
    public float EnemyOldPosition;
    public float maxRange;
    public float minRange;
    private GameObject gameObj;
    public Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        gameObj = gameObject;
        EnemyOldPosition = 10;
        EnemyMoveLeft = 5;
        maxRange = 1;
        minRange = -2;
    }

    // Update is called once per frame
    void Update()
    {
        gameObj.transform.Translate(new Vector3(1 * Time.deltaTime * EnemyMoveLeft, 0, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("RsWalls"))
            gameObj.transform.position = new Vector3(EnemyOldPosition, Random.Range(minRange, maxRange + 2), 0);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.transform.position = respawnPoint.transform.position;
        }
    }
}
