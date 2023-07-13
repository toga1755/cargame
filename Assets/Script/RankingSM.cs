﻿// using System.Collections;
// using UnityEngine;
// using UnityEngine.UI;
// using System.Linq;
// using NCMB;
// using NCMB.Extensions;

// namespace naichilab
// {
//     public class RankingSM : MonoBehaviour
//     {
//         private const string OBJECT_ID = "objectId";
//         private const string COLUMN_SCORE = "score";
//         private const string COLUMN_NAME = "name";


//         [SerializeField] Text captionLabel;
//         [SerializeField] RectTransform scrollViewContent;
//         [SerializeField] GameObject rankingNodePrefab;
//         [SerializeField] GameObject readingNodePrefab;
//         [SerializeField] GameObject notFoundNodePrefab;
//         [SerializeField] GameObject unavailableNodePrefab;

//         private string _objectid = null;

//         private string ObjectID
//         {
//             get { return _objectid ?? (_objectid = PlayerPrefs.GetString(BoardIdPlayerPrefsKey, null)); }
//             set
//             {
//                 if (_objectid == value)
//                     return;
//                 PlayerPrefs.SetString(BoardIdPlayerPrefsKey, _objectid = value);
//             }
//         }

//         private string BoardIdPlayerPrefsKey
//         {
//             get { return string.Format("{0}_{1}_{2}", "board", _board.ClassName, OBJECT_ID); }
//         }

//         private RankingInfo _board;
//         private IScore _lastScore;

//         private NCMBObject _ncmbRecord;

//         void Start()
//         {
//             _board = RankingLoader.Instance.CurrentRanking;
//             Debug.Log(BoardIdPlayerPrefsKey + "=" + PlayerPrefs.GetString(BoardIdPlayerPrefsKey, null));

//             StartCoroutine(GetHighScoreAndRankingBoard());
//         }

//         IEnumerator GetHighScoreAndRankingBoard()
//         {
//             captionLabel.text = string.Format("{0}ランキング", _board.BoardName);

//             //ランキング取得
//             yield return StartCoroutine(LoadRankingBoard());
//         }

//         /// <summary>
//         /// ランキング取得＆表示
//         /// </summary>
//         /// <returns>The ranking board.</returns>
//         private IEnumerator LoadRankingBoard()
//         {
//             int nodeCount = scrollViewContent.childCount;
//             for (int i = nodeCount - 1; i >= 0; i--)
//             {
//                 Destroy(scrollViewContent.GetChild(i).gameObject);
//             }

//             var msg = Instantiate(readingNodePrefab, scrollViewContent);

//             //2017.2.0b3の描画されないバグ暫定対応
//             MaskOffOn();

//             var so = new YieldableNcmbQuery<NCMBObject>(_board.ClassName);
//             so.Limit = 30;
//             if (_board.Order == ScoreOrder.OrderByAscending)
//             {
//                 so.OrderByAscending(COLUMN_SCORE);
//             }
//             else
//             {
//                 so.OrderByDescending(COLUMN_SCORE);
//             }

//             yield return so.FindAsync();

//             Debug.Log("データ取得 : " + so.Count.ToString() + "件");
//             Destroy(msg);

//             if (so.Error != null)
//             {
//                 Instantiate(unavailableNodePrefab, scrollViewContent);
//             }
//             else if (so.Count > 0)
//             {
//                 int rank = 0;
//                 foreach (var r in so.Result)
//                 {
//                     var n = Instantiate(rankingNodePrefab, scrollViewContent);
//                     var rankNode = n.GetComponent<RankingNode>();
//                     rankNode.NoText.text = (++rank).ToString();
//                     rankNode.NameText.text = r[COLUMN_NAME].ToString();

//                     var s = _board.BuildScore(r[COLUMN_SCORE].ToString());
//                     rankNode.ScoreText.text = s != null ? s.TextForDisplay : "エラー";

// //                    Debug.Log(r[COLUMN_SCORE].ToString());
//                 }
//             }
//             else
//             {
//                 Instantiate(notFoundNodePrefab, scrollViewContent);
//             }
//         }

//         private void MaskOffOn()
//         {
//             //2017.2.0b3でなぜかScrollViewContentを追加しても描画されない場合がある。
//             //親maskをOFF/ONすると直るので無理やり・・・
//             var m = scrollViewContent.parent.GetComponent<Mask>();
//             m.enabled = false;
//             m.enabled = true;
//         }
//     }
// }