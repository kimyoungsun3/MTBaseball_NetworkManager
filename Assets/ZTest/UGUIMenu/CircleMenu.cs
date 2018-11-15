using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuTest{
	public class CircleMenu : MonoBehaviour {
		public List<CircleItem> list = new List<CircleItem>();

		void Start(){
			CircleItem _circleItem;
			int _num = 0;
			foreach (Transform _t in transform) {
				_circleItem = _t.GetComponent<CircleItem> ();
				list.Add (_circleItem);
				_circleItem.num = ++_num;
			}	
		}

		public void OnCircleEnter(CircleItem _circleItem){
			Debug.Log ("OnCircleEnter:" + _circleItem.num);
		}

		public void OnCircleExit(CircleItem _circleItem){
			Debug.Log ("OnCircleExit:" + _circleItem.num);
		}

		public void OnCircleDown(CircleItem _circleItem){
			Debug.Log ("OnCircleDown:" + _circleItem.num);
		}

		public void OnCircleUp(CircleItem _circleItem){
			Debug.Log ("OnCircleUp:" + _circleItem.num);
		}
	}
}
