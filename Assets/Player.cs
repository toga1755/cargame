using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpForce;
    [SerializeField] private GameObject[] _player;

    private bool isJumping = false;

    int _select;

    void Start()
    {
        _selected = PlayerPrefs.GetInt("PlayerSelect", 0);
        _player[_selected].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !(rb.velocity.y < -0.5f))
        {
            Jump();
        }
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
    }
    void Jump()
    {
        isJumping = true;

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stage"))
        {
            isJumping = false;
        }
    }
}