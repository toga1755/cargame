using NCMB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resaltTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var millsec = 123456;
        var timeScore = new System.TimeSpan (0, 0, 0, 0, millsec);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (timeScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
