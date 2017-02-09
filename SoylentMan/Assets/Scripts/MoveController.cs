using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour 
{
    private GameObject _player;
    private float _moveSpeed;
    private float _jumpPower;
    private bool _jumpedOnce;
    private bool _jumpedTwice;
	// Use this for initialization
	private void Start () 
    {
        _player = GameObject.Find("SoylentBottle");
        _moveSpeed = .125F;
        _jumpedOnce = true;
        _jumpedTwice = true;
        _jumpPower = 10;
        _player.GetComponent<Rigidbody2D>().freezeRotation = true;
	}
	
	// Update is called once per frame
	private void Update () 
    {
        ParsePlayerInput();
	}

    private void ParsePlayerInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            _player.transform.position = new Vector2(_player.transform.position.x - _moveSpeed, _player.transform.position.y);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            _player.transform.position = new Vector2(_player.transform.position.x + _moveSpeed, _player.transform.position.y);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            Jump();
        
    }

    private void Jump()
    {
        if(!_jumpedOnce)
        {
            _player.GetComponent<Rigidbody2D>().velocity += Vector2.up * _jumpPower;
            _jumpedOnce = true;
            Debug.Log("jumped once");
        }
        else if(!_jumpedTwice)
        {
            _player.GetComponent<Rigidbody2D>().velocity += Vector2.up * _jumpPower;
            _jumpedTwice = true;
            Debug.Log("jumped twice");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (_jumpedOnce)
            {
                _jumpedOnce = false;
                _jumpedTwice = false;
                Debug.Log("landed");
            }
        }
    }
}
