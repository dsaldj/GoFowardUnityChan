using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
    Animator animator;                 //アニメーションするためのコンポーネント
    Rigidbody2D rigid2D;　　　　　　　　　//unitychanを移動させるためのコンポーネント

    private float groundLevel  = -3.0f; //地面の位置
    private float dump         = 0.8f;  //ジャンプ速度の減衰
    private float jumpVelocity = 20f;　　//ジャンプ速度
    private float deadLine     = -9;    //ゲームオーバーになる位置


    // Start is called before the first frame update
    void Start() {
        //アニメーターのコンポーネントを取得
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dコンポーネントの取得
        this.rigid2D = GetComponent<Rigidbody2D>();
    }


    void Update() {
        //走るアニメーションを再生するためにAnimationのパラメータを調整
        this.animator.SetFloat("Horizontal", 1);
        //着地しているかどうかの判定
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ状態の時はボリュームは0にする
        GetComponent<AudioSource>().volume = (isGround) ? 0.2f : 0;


        //着地状態でクリックされた場合
        if (Input.GetMouseButtonDown(0) && isGround) {
            //上方向の力をかける
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックをやめたら上方向への速度を減速
        if (Input.GetMouseButton(0) == false) {
            if (this.rigid2D.velocity.y > 0) {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //デットラインを超えたらゲームオーバー
        if (transform.position.x < this.deadLine) {
            //UIControllderのGameOver関数を呼び出した画面上に「GameOver」と表示
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            //UnityChanを破壊
            Destroy(gameObject);
        }
    }
}
