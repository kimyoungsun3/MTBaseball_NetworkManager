using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StepByStep{
	public class StepByStep2 : MonoBehaviour {
		bool isClick = false;
		public StepClick click;
		public StepClick click2;
		public StepClick click3;

		IEnumerator Start () {

			//------------------------------
			Debug.Log (" Step 1");
			isClick = false;
			click.SetInit (OnClick);

			while (!isClick) {
				yield return null;
			}

			//------------------------------
			Debug.Log (" Step 2");
			isClick = false;
			click2.SetInit (delegate() {
				Debug.Log (" Step 2 > Pass");
				isClick = true;
			});

			while (!isClick) {
				yield return null;
			}

			//------------------------------
			Debug.Log (" Step 3");
			isClick = false;
			click3.SetInit (()=>{
				Debug.Log (" Step 3 > Pass");
				isClick = true;
			});

			while (!isClick) {
				yield return null;
			}
		}


		void OnClick(){
			isClick = true;
		}
	}
}