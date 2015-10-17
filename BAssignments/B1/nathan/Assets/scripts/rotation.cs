using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {

	public float smooth = 2.0F;
	void LateUpdate () {
		// Rotation
		
		Quaternion targetf = Quaternion.Euler(0, 0, 0); // Vector3 Direction when facing frontway
		Quaternion targetb = Quaternion.Euler(0, 180, 0); // Vector3 Direction when facing opposite way
		
		if (Input.GetAxisRaw ("Vertical") < 0.0f) // if input is lower than 0 turn to targetf
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, targetf, Time.deltaTime * smooth);
			
		}
		if (Input.GetAxisRaw ("Vertical") > 0.0f) // if input is higher than 0 turn to targetb
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, targetb, Time.deltaTime * smooth);
			
		}
	}
}
