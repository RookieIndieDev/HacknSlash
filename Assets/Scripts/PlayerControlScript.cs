using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour
{

	Rigidbody2D PlayerRigidbody;
	float Speed = 3.5f;
	float xOffset = 3.2f;
	float yOffset = 0.49f;
	Vector3 ScreenSpaceVector;
	public static Vector4 PlayerPosition;
	void Start () 
	{
		PlayerRigidbody = gameObject.GetComponent<Rigidbody2D> ();
	}
	

	void Update () 
	{

		//Movement Handling
		if (Input.GetKey ("w")) 
		{
			PlayerRigidbody.velocity = Vector2.up * Speed;
			AnimControllerScript.IsFacingBackward = true;
			AnimControllerScript.IsFacingForward = false;
			AnimControllerScript.IsFacingLeft = false;
			AnimControllerScript.IsFacingRight = false;
			AnimControllerScript.IsPlayerAttackingUp = false;
			AnimControllerScript.IsPlayerAttackingDown = false;
			AnimControllerScript.IsPlayerAttackingLeft = false;
			AnimControllerScript.IsPlayerAttackingRight = false;
		}

		if (Input.GetKey ("s")) 
		{
			PlayerRigidbody.velocity = Vector2.down * Speed;
			AnimControllerScript.IsFacingForward = true;
			AnimControllerScript.IsFacingBackward = false;
			AnimControllerScript.IsFacingLeft = false;
		    AnimControllerScript.IsFacingRight = false;
			AnimControllerScript.IsPlayerAttackingUp = false;
			AnimControllerScript.IsPlayerAttackingDown = false;
			AnimControllerScript.IsPlayerAttackingLeft = false;
			AnimControllerScript.IsPlayerAttackingRight = false;
		}

		if (Input.GetKey ("a")) 
		{
			PlayerRigidbody.velocity = Vector2.left * Speed;
			AnimControllerScript.IsFacingLeft = true;
			AnimControllerScript.IsFacingBackward = false;
			AnimControllerScript.IsFacingForward = false;
			AnimControllerScript.IsFacingRight = false;
			AnimControllerScript.IsPlayerAttackingUp = false;
			AnimControllerScript.IsPlayerAttackingDown = false;
			AnimControllerScript.IsPlayerAttackingLeft = false;
			AnimControllerScript.IsPlayerAttackingRight = false;
		}

		if (Input.GetKey ("d"))
		{
			PlayerRigidbody.velocity = Vector2.right * Speed;
			AnimControllerScript.IsFacingRight = true;
			AnimControllerScript.IsFacingBackward = false;
			AnimControllerScript.IsFacingForward = false;
			AnimControllerScript.IsFacingLeft = false;
			AnimControllerScript.IsPlayerAttackingUp = false;
			AnimControllerScript.IsPlayerAttackingDown = false;
			AnimControllerScript.IsPlayerAttackingLeft = false;
			AnimControllerScript.IsPlayerAttackingRight = false;
		}

		if(Input.anyKey != true)
		{
			AnimControllerScript.IsPlayerIdle = true;
			AnimControllerScript.IsFacingRight = false;
			AnimControllerScript.IsFacingBackward = false;
			AnimControllerScript.IsFacingForward = false;
			AnimControllerScript.IsFacingLeft = false;
			AnimControllerScript.IsPlayerAttackingUp = false;
			AnimControllerScript.IsPlayerAttackingDown = false;
			AnimControllerScript.IsPlayerAttackingLeft = false;
			AnimControllerScript.IsPlayerAttackingRight = false;
		}

		//Attack Handling

		if (Input.GetKey (KeyCode.UpArrow))
		{
			AnimControllerScript.IsPlayerIdle = false;
			AnimControllerScript.IsFacingRight = false;
			AnimControllerScript.IsFacingBackward = false;
			AnimControllerScript.IsFacingForward = false;
			AnimControllerScript.IsFacingLeft = false;
			AnimControllerScript.IsPlayerAttackingUp = true;
			AnimControllerScript.IsPlayerAttackingDown = false;
			AnimControllerScript.IsPlayerAttackingLeft = false;
			AnimControllerScript.IsPlayerAttackingRight = false;
		}

		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			AnimControllerScript.IsPlayerIdle = false;
			AnimControllerScript.IsFacingRight = false;
			AnimControllerScript.IsFacingBackward = false;
			AnimControllerScript.IsFacingForward = false;
			AnimControllerScript.IsFacingLeft = false;
			AnimControllerScript.IsPlayerAttackingUp = false;
			AnimControllerScript.IsPlayerAttackingDown = true;
			AnimControllerScript.IsPlayerAttackingLeft = false;
			AnimControllerScript.IsPlayerAttackingRight = false;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			AnimControllerScript.IsPlayerIdle = false;
			AnimControllerScript.IsFacingRight = false;
			AnimControllerScript.IsFacingBackward = false;
			AnimControllerScript.IsFacingForward = false;
			AnimControllerScript.IsFacingLeft = false;
			AnimControllerScript.IsPlayerAttackingUp = false;
			AnimControllerScript.IsPlayerAttackingDown = false;
			AnimControllerScript.IsPlayerAttackingLeft = true;
			AnimControllerScript.IsPlayerAttackingRight = false;
		}

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			AnimControllerScript.IsPlayerIdle = false;
			AnimControllerScript.IsFacingRight = false;
			AnimControllerScript.IsFacingBackward = false;
			AnimControllerScript.IsFacingForward = false;
			AnimControllerScript.IsFacingLeft = false;
			AnimControllerScript.IsPlayerAttackingUp = false;
			AnimControllerScript.IsPlayerAttackingDown = false;
			AnimControllerScript.IsPlayerAttackingLeft = false;
			AnimControllerScript.IsPlayerAttackingRight = true;
		}

		//Convert World Space to Screen Space
		ScreenSpaceVector.Set(gameObject.transform.position.x + xOffset + Random.Range(0f,0.1f), -gameObject.transform.position.y + yOffset + Random.Range(0f,0.1f), gameObject.transform.position.z);
		ScreenSpaceVector = Camera.main.WorldToScreenPoint(ScreenSpaceVector);

		// Set the Position to be sent to the Shader
		PlayerPosition.Set(ScreenSpaceVector.x, ScreenSpaceVector.y, ScreenSpaceVector.z, 0);

	}
}
