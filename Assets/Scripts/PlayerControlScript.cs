﻿using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour
{

	Rigidbody2D PlayerRigidbody;
	float Speed = 2.5f;
	void Start () 
	{
		PlayerRigidbody = gameObject.GetComponent<Rigidbody2D> ();
	}
	

	void Update () 
	{
		if (Input.GetKey ("w")) 
		{
			PlayerRigidbody.velocity = Vector2.up * Speed;
			AnimControlleScript.IsFacingBackward = true;
			AnimControlleScript.IsFacingForward = false;
			AnimControlleScript.IsFacingLeft = false;
			AnimControlleScript.IsFacingRight = false;
			AnimControlleScript.IsPlayerAttackingUp = false;
		}

		if (Input.GetKey ("s")) 
		{
			PlayerRigidbody.velocity = Vector2.down * Speed;
			AnimControlleScript.IsFacingForward = true;
			AnimControlleScript.IsFacingBackward = false;
			AnimControlleScript.IsFacingLeft = false;
		    AnimControlleScript.IsFacingRight = false;
			AnimControlleScript.IsPlayerAttackingUp = false;
		}

		if (Input.GetKey ("a")) 
		{
			PlayerRigidbody.velocity = Vector2.left * Speed;
			AnimControlleScript.IsFacingLeft = true;
			AnimControlleScript.IsFacingBackward = false;
			AnimControlleScript.IsFacingForward = false;
			AnimControlleScript.IsFacingRight = false;
			AnimControlleScript.IsPlayerAttackingUp = false;
		}

		if (Input.GetKey ("d"))
		{
			PlayerRigidbody.velocity = Vector2.right * Speed;
			AnimControlleScript.IsFacingRight = true;
			AnimControlleScript.IsFacingBackward = false;
			AnimControlleScript.IsFacingForward = false;
			AnimControlleScript.IsFacingLeft = false;
			AnimControlleScript.IsPlayerAttackingUp = false;
		}

		if(Input.anyKey != true)
		{
			AnimControlleScript.IsPlayerIdle = true;
			AnimControlleScript.IsFacingRight = false;
			AnimControlleScript.IsFacingBackward = false;
			AnimControlleScript.IsFacingForward = false;
			AnimControlleScript.IsFacingLeft = false;
			AnimControlleScript.IsPlayerAttackingUp = false;
		}

		if (Input.GetKey (KeyCode.UpArrow))
		{
			AnimControlleScript.IsPlayerIdle = false;
			AnimControlleScript.IsFacingRight = false;
			AnimControlleScript.IsFacingBackward = false;
			AnimControlleScript.IsFacingForward = false;
			AnimControlleScript.IsFacingLeft = false;
			AnimControlleScript.IsPlayerAttackingUp = true;
		}
	}
}