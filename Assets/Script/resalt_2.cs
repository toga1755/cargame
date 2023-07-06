using NCMB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resalt_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int millsec = (int)((Timer.countTime)*1000);
        var timeScore = new System.TimeSpan (0, 0, 0, 0, millsec);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (timeScore, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
