using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassAndClass{
	public class Tank : MonoBehaviour {
		public float speed = 3f;
		void Update () {
			float _h = Input.GetAxisRaw ("Horizontal");
			float _v = Input.GetAxisRaw ("Vertical");

			Vector3 _move = new Vector3 (_h, _v, 0);
			transform.Translate (_move.normalized * speed * Time.deltaTime);
		}

		void OnMouseDown(){
			gameObject.SetActive (false);
		}
	}
}
