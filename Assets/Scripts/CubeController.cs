using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    //キューブの移動速度
    private float speed = -12;
    //消滅位置
    private float deadLine = -10;
    private AudioSource audioSource;
    private bool isCollison;


    // Start is called before the first frame update
    void Start() {
        //GetComponent<AudioSource>().volume = 0.1f;
        audioSource = gameObject.GetComponent<AudioSource>();
}

    // Update is called once per frame
    void Update() {

        //キューブを移動
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //bool isCollison = false;

        //画面外に出ると破棄
        if (transform.position.x < this.deadLine) {
            Destroy(gameObject);
        }
    }

    /// ---------------------------Lesson7課題(追加)----------------------------------
    /// 地面、他のキューブ衝突時に音が出るように
    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag == "BlockTag"|| other.gameObject.tag == "GroundTag") {
            //ジャンプ状態の時はボリュームは0にする
            audioSource.volume = 0.2f;
            audioSource.Play();
        }
    }
    
}
