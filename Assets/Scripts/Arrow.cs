using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public Vector3[] positions;
	public float[] rotations;
	public bool[] isContrast;
	public bool CheckInCorrect(){
		if(positions.Length!=rotations.Length)
			return false;
		else if(positions.Length!=isContrast.Length)
			return false;
		return true;
	}
}
