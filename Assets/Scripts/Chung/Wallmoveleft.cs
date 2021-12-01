using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallmoveleft : MonoBehaviour
{
    //Tạo tùy chỉnh trực quan sự thay đổi tốc độ trên giao diện Unity
    public float moveleftSpeed;
    //Tạo vị trí ban đầu của Wall
    public float oldPosition;
    //Tạo tham chiếu tăng khả năng xử lý code
    private GameObject gObj;
    //Tạo giá trị max min khoảng cách của Wall khi random theo trục Y
    public float maxRange;
    public float minRange;
    // Start is called before the first frame update
    void Start()
    {
        gObj = gameObject;
        oldPosition = 10;
        moveleftSpeed = 4;
        maxRange = 1;
        minRange = -2;
    }

    // Update is called once per frame
    void Update()
    {
        gObj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveleftSpeed, 0, 0));
    }
    //Xử lý va chạm với "RsWall" nhằm lặp lại những Wall có lỗ hổng khác nhau
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("RsWalls"))
        gObj.transform.position = new Vector3(oldPosition, Random.Range(minRange, maxRange + 1),0);
    }
}
