using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private GameObject gameOverText;  //ゲームオーバーテキスト
    private GameObject runLengthText; //走行距離テキスト

    private float len       = 0;     //走行距離
    private float speed     = 5f;    //走行速度
    private bool isGameOver = false; //ゲームオーバー判定

    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからオブジェクトのジッタを検索
        this.gameOverText  = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false) {
            this.len += this.speed * Time.deltaTime;

            this.runLengthText.GetComponent<Text>().text
            = "Distance: " + len.ToString("F2") + "m";
        }

        //ゲームオーバーになった場合
        if (this.isGameOver == true) {
            //左ボタンがクリックされたらシーンをロード
            if (Input.GetMouseButtonDown(0)) {
                //SampleSceneを読み込む
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void GameOver() {
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }
}
