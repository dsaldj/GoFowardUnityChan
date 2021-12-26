using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab; //キューブのPrefab

    private float delta   =0;     //時間測定用の変数
    private float span    = 1.0f; //キューブの生成間隔
    private float genPosX = 12;   //キューブの生成位置

    private float offsetY = 0.3f; //キューブ生成位置オフセット
    private float spaceY  = 6.9f; // キューブ縦方向の間隔

    private float offsetX = 0.5f; //キューブ生成位置オフセット
    private float spaceX  = 0.4f; // キューブ縦方向の間隔

    private int maxBlockNum = 4;  //キューブ生成個数の上限

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        //span秒以上の時間が経過したかを調べる
        if (this.delta > this.span) {
            this.delta = 0;
            //生成するキューブ数をランダムに決める
            int n = Random.Range(1, maxBlockNum + 1);
            //指定した数(n個)だけキューブを生成
            for(int i = 0; i < n; i++) {
                //キューブの生成
                GameObject go = Instantiate(cubePrefab);
                go.transform.position =
                new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            //次のキューブまでの生成時間を決める
            this.span = this.offsetX + this.spaceX * n;
        }
    }
}
