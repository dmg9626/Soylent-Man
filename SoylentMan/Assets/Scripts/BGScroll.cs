using UnityEngine;
using System.Collections;

public class BGScroll : MonoBehaviour 
{
    private float _speed;
	// Use this for initialization
	void Start () 
	{
        _speed = .25F;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 offset = new Vector2 (Time.time * _speed, 0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
