using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public bool isLit;

	public void OnTriggerEnter(Collider other)
	{
		if (!isLit)
		{
			isLit = true;
			Debug.Log("Fire Lit");
			//animator.SetBool("IsLit", isLit);
		}
	}
}
