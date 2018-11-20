using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StepByStep{
	public class StepByStep3 : MonoBehaviour {
		bool isClick = false;
		public StepClick click;
		public StepClick click2;
		public StepClick click3;

		IEnumerator Start () {
			//------------------------------
			Debug.Log (" Step 1");
			yield return StartCoroutine (Step1 ());

			//------------------------------
			Debug.Log (" Step 2");
			yield return StartCoroutine (Step2 ());

			//------------------------------
			Debug.Log (" Step 3");
			yield return StartCoroutine (Step3 ());
		}

		IEnumerator Step1(){
			isClick = false;
			click.SetInit (OnClick);

			while (!isClick) {
				yield return null;
			}
		}

		IEnumerator Step2(){
			isClick = false;
			click2.SetInit (delegate() {
				Debug.Log (" Step 2 > Pass");
				isClick = true;
			});

			while (!isClick) {
				yield return null;
			}
		}

		IEnumerator Step3(){
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