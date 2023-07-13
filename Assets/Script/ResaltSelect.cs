using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
using System.Linq;
using UnityEngine.UI;

public class ResaltSelect : MonoBehaviour
{
    public Text targetText; 
    void Start () {
        //順位のカウント
        int count = 0;
        string tempScore = "";
        //★ データストアの「TimeHiScore」クラスから検索
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("TimeHiScore");
        //★Scoreフィールドの降順でデータを取得
        query.OrderByDescending ("score");
        //★検索件数を5件に設定
        query.Limit = 5;
        query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
                if (e != null) {
                  UnityEngine.Debug.Log ("ランキング取得失敗");
                } else {
                    //検索成功時の処理
                    UnityEngine.Debug.Log ("ランキング取得成功");
                        // 値とインデックスのペアをループ処理
                        foreach (NCMBObject obj in objList)
                        {
                            count++;
                             //★ユーザーネームとスコアを画面表示
                            tempScore += count.ToString() + "位：" + "：ユーザーネーム：" + obj ["UserName"] + "：スコア：" + obj ["score"] + "\r\n";
                        }
                        targetText.GetComponent<Text>().text = tempScore;
                }                     
         });
    }
}