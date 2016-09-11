using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{

	int Lives;
	bool IsDead;
	Animator EnemyAnimator;
	void Start () 
	{
		Lives = 3;
		EnemyAnimator = gameObject.GetComponent<Animator>();
		IsDead = false;
	}
	

	void Update () 
	{	
		if (Lives == 0) 
		{

		}

	}
}
