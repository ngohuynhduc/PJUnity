using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBG : MonoBehaviour
{
    public float moveleftSpeed;
    public float Range;
    private Vector3 oldPosition;
    private GameObject gObj;
    void Start()
    {
        gObj = gameObject;
        oldPosition = gObj.transform.position;
        moveleftSpeed = 1;
        Range = 21.6f;
    }

    // Update is called once per frame
    void Update()
    {
        gObj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveleftSpeed, 0, 0));
        //Cấu trúc lặp lại BackGround
        if (Vector3.Distance(oldPosition, gObj.transform.position) > Range)
        {
            gObj.transform.position = oldPosition;
        }
    }
}
