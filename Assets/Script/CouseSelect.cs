using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CouseSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] _course;
    private int _selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        _selected = PlayerPrefs.GetInt("CourseSelect", 0);
        _course[_selected].SetActive(true);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Right()
    {
        _course[_selected].SetActive(false);
        _selected++;
        if (_selected >= _course.Length)
            _selected = 0;
        _course[_selected].SetActive(true);
    }
    public void Left()
    {
        _course[_selected].SetActive(false);
        _selected--;
        if (_selected < 0)
            _selected = _course.Length - 1;
        _course[_selected].SetActive(true);
    }
    public void SelectBall()
    {
        PlayerPrefs.SetInt("CourseSelect", _selected);
        SceneManager.LoadScene("titleScene");
    }
}
