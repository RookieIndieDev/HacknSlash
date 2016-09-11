using UnityEngine;
using System.Collections;

public class AnimControllerScript : MonoBehaviour 
{

	public static Animator PlayerAnimator;

	// Movement Bools
	public static bool IsFacingLeft;
	public static bool IsFacingRight;
	public static bool IsFacingForward;
	public static bool IsFacingBackward;
	public static bool IsPlayerIdle;

	//Attack Bools
	public static bool IsPlayerAttackingUp;
	public static bool IsPlayerAttackingDown;
	public static bool IsPlayerAttackingLeft;
	public static bool IsPlayerAttackingRight;

	//Death Bool
	public static bool IsDead;

	void Start () 
	{
		PlayerAnimator = GameObject.Find ("Player").GetComponent<Animator> ();
		IsDead = false;
	}
	

	void Update () 
	{
		PlayerAnimator.SetBool ("IsIdle", IsPlayerIdle);

		//Movement Anims
		PlayerAnimator.SetBool ("FacingLeft", IsFacingLeft);
		PlayerAnimator.SetBool ("FacingRight", IsFacingRight);
		PlayerAnimator.SetBool ("FacingForward", IsFacingForward);
		PlayerAnimator.SetBool ("FacingBackward", IsFacingBackward);


		//Attack Anims
		PlayerAnimator.SetBool ("IsAttackingUp", IsPlayerAttackingUp);
		PlayerAnimator.SetBool ("IsAttackingDown", IsPlayerAttackingDown);
		PlayerAnimator.SetBool ("IsAttackingLeft", IsPlayerAttackingLeft);
		PlayerAnimator.SetBool ("IsAttackingRight", IsPlayerAttackingRight);

		//Death Anim
		PlayerAnimator.SetBool("IsDead", IsDead);
	}
}
