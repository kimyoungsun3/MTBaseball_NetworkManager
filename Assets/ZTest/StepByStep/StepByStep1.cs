using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StepByStep{
	public class StepByStep1 : MonoBehaviour {


		IEnumerator Start () {
			Debug.Log (" Step 1");
			yield return null;

			Debug.Log (" Step 2");
			yield return null;

			Debug.Log (" Step 3");
			yield return null;

			Debug.Log (" Step 4");
			yield return null;
		}
	}
}