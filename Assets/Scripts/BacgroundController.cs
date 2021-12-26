using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundController : MonoBehaviour
{
    //スクロール速度
    private float scrollSpeed = -1;    
    //背景終了位置
    private float deadLine    = -19.2f;   //-16f
    //背景開始位置
    private float startLine   = 18f;  //15.8f

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //背景を移動
        transform.Translate(this.scrollSpeed * Time.deltaTime, 0, 0);
        //画面外に出たら画面右端に移動
        if (transform.position.x < this.deadLine) {
            transform.position = new Vector2(this.startLine, 0);
        }
    }
}
