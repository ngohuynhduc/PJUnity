using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2RsWall : MonoBehaviour
{
    public float moveleftSpeed;
   
    public float oldPosition;
   
    private GameObject gObj;

    public float maxRange;
    public float minRange;
    // Start is called before the first frame update
    void Start()
    {
        gObj = gameObject;
        oldPosition = 10;
        moveleftSpeed = 4;
        maxRange = 9;
        minRange = 5.5f;
    }

    // Update is called once per frame
    void Update()
    {
        gObj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveleftSpeed, 0, 0));
    }
    //Xử lý va chạm với "RsWall" nhằm lặp lại những Wall có lỗ hổng khác nhau
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("RsWalls"))
            gObj.transform.position = new Vector3(oldPosition, Random.Range(minRange, maxRange + 1), 0);
    }
}
