using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // player オブジェクトの取得
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // フレームごとに等速で落下させる
        transform.Translate(0, -0.02f, 0);

        // 画面外に出たらオブジェクトを破棄
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // 当たり判定
        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 0.95f;

        // 矢とプレイヤーの衝突判定
        if (d < r1 + r2)
        {
            // 監督スクリプトのメソッド呼び出し
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            // 矢を削除
            Destroy(gameObject);
        }
    }
}
