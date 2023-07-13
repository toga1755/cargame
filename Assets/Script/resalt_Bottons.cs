using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resalt_Bottons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickGoTitleButton()
    {
        SceneManager.LoadScene("titleScene");
    }

    public void OnClickRetryButton()
    {
        if(SceneManager.GetActiveScene().name == "1_resaltScene"){
            SceneManager.LoadScene("1_courseScene");
        }
        if(SceneManager.GetActiveScene().name == "2_resaltScene"){
            SceneManager.LoadScene("2_courseScene");
        }
        if(SceneManager.GetActiveScene().name == "3_resaltScene"){
            SceneManager.LoadScene("3_courseScene");
        }
    }
}
