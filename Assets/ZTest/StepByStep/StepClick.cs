using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StepByStep{
	public class StepClick : MonoBehaviour {
		System.Action onClickCallBack;

		void Awake(){
			gameObject.SetActive (false);
		}

		public void SetInit(System.Action _on){
			gameObject.SetActive (true);
			onClickCallBack = _on;
		}

		void OnMouseDown(){
			if (onClickCallBack != null) {
				onClickCallBack ();
				onClickCallBack = null;
			}

			gameObject.SetActive (false);
		}
	}
}