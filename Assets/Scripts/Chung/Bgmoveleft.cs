using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgmoveleft : MonoBehaviour
{
    //Tạo tùy chỉnh trực quan sự thay đổi tốc độ trên giao diện Unity
    public float moveleftSpeed;
    //Tạo tùy chỉnh trực quan sự lặp lại của BackGround trên giao diện Unity
    public float Range;
    //Tạo vị trí ban đầu của BackGround
    private Vector3 oldPosition;
    //Tạo tham chiếu tăng khả năng xử lý code
    private GameObject gObj;
    // Start is called before the first frame update
    void Start()
    {
        gObj = gameObject;
        oldPosition = gObj.transform.position;
        moveleftSpeed = 4;
        Range = 25.19f;
    }

    // Update is called once per frame
    void Update()
    {
        //Hàm dịch chuyển background sang trái một khoảng bằng deltaTime mỗi khi update
        gObj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveleftSpeed, 0, 0));
        //Cấu trúc lặp lại BackGround
        if(Vector3.Distance(oldPosition,gObj.transform.position) > Range)
        {
            gObj.transform.position = oldPosition;
        }
    }
}
