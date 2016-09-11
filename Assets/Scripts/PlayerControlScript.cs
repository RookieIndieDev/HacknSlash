using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour
{

	Rigidbody2D PlayerRigidbody;
	float Speed = 2.5f;
	float xOffset = 2.0f;
	float yOffset = 0.49f;
	Vector3 ScreenSpaceVector;
	Vector2 PlayerPos2D;
	public static Vector4 PlayerPosition;
	public static bool IsDead;
	Transform PlayerTransform;
	void Start () 
	{
		PlayerRigidbody = gameObject.GetComponent<Rigidbody2D> ();
		IsDead = false;
		PlayerTransform = gameObject.transform;
	}
	

	void Update () 
	{
		if (!IsDead) 
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

			if (Input.anyKey != true) 
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
				Physics2D.Raycast(PlayerPos2D, Vector2.up, 2f);
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
				Physics2D.Raycast(PlayerPos2D, Vector2.down, 2f);
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
				Physics2D.Raycast(PlayerPos2D, Vector2.left, 2f);
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
				Physics2D.Raycast(PlayerPos2D, Vector2.right, 2f);
			}

			if(Input.GetKey(KeyCode.Delete))
			{
				IsDead = true;
				AnimControllerScript.IsDead = IsDead;
			}

			//Convert World Space to Screen Space
			ScreenSpaceVector.Set (PlayerTransform.position.x + xOffset + Random.Range (0f, 0.1f), PlayerTransform.position.y + yOffset + Random.Range (0f, 0.1f), PlayerTransform.position.z);
			ScreenSpaceVector = Camera.main.WorldToScreenPoint (ScreenSpaceVector);

			// Set the Position to be sent to the Shader
			PlayerPosition.Set (ScreenSpaceVector.x, ScreenSpaceVector.y, ScreenSpaceVector.z, 0);
			PlayerPos2D.Set(PlayerTransform.position.x, PlayerTransform.position.y);
		}
	}
}
