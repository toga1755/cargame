using NCMB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resalt_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int millsec = (int)((Timer.countTime)*1000);
        var timeScore = new System.TimeSpan (0, 0, 0, 0, millsec);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (timeScore, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
