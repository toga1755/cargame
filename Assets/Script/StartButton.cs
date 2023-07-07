using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private int _selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        _selected = PlayerPrefs.GetInt("CourseSelect", 0);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        if(_selected == 0){
            SceneManager.LoadScene("1_courseScene");
        }
        if(_selected == 1){
            SceneManager.LoadScene("2_courseScene");
        }
        if(_selected == 2){
            SceneManager.LoadScene("3_courseScene");
        }
    }
}
