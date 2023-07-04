using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] _car;
    private int _selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        _selected = PlayerPrefs.GetInt("CarSelect", 0);
        _car[_selected].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Right()
    {
        _car[_selected].SetActive(false);
        _selected++;
        if (_selected >= _car.Length)
            _selected = 0;
        _car[_selected].SetActive(true);
        PlayerPrefs.SetInt("carSelect", _selected);
    }

    public void Left()
    {
        _car[_selected].SetActive(false);
        _selected--;
        if (_selected < 0)
            _selected = _car.Length - 1;
        _car[_selected].SetActive(true);
        PlayerPrefs.SetInt("carSelect", _selected);
    }
}
