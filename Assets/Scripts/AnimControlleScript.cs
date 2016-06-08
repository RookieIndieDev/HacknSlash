using UnityEngine;
using System.Collections;

public class AnimControlleScript : MonoBehaviour 
{

	public static Animator PlayerAnimator;
	public static bool IsFacingLeft;
	public static bool IsFacingRight;
	public static bool IsFacingForward;
	public static bool IsFacingBackward;
	public static bool IsPlayerIdle;
	public static bool IsPlayerAttackingUp;
	void Start () 
	{
		PlayerAnimator = GameObject.Find ("Player").GetComponent<Animator> ();
	}
	

	void Update () 
	{
		PlayerAnimator.SetBool ("FacingLeft", IsFacingLeft);
		PlayerAnimator.SetBool ("FacingRight", IsFacingRight);
		PlayerAnimator.SetBool ("FacingForward", IsFacingForward);
		PlayerAnimator.SetBool ("FacingBackward", IsFacingBackward);
		PlayerAnimator.SetBool ("IsAttackingUp", IsPlayerAttackingUp);
		PlayerAnimator.SetBool ("IsIdle", IsPlayerIdle);
	}
}
