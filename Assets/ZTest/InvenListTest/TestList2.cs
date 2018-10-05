using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ListTest{
	public class TestList2 : MonoBehaviour {
		public string listIdx;
		public int useCnt = 1;
		public Dictionary<string, ItemOwner> dicItemOwner = new Dictionary<string, ItemOwner>();

		void Start(){

			ItemOwner _itemowner;
			for(int i = 0; i < 2; i++){
				_itemowner = new ItemOwner(i, i* 100, i+"A", 1);
				dicItemOwner.Add (
					_itemowner.listIdx.ToString(),
					_itemowner
				);
			}

			Display ();

		}
		void Update(){			
			if (Input.GetKeyDown (KeyCode.Alpha1)) {	
				int i = Random.Range (0, 10);
				ItemOwner _itemowner = new ItemOwner (i, i * 100, i + "A", 10);
				AddItemOwner (_itemowner);
				Display ();
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				Debug.Log ("Remove > " + listIdx);
				if (dicItemOwner.ContainsKey (listIdx)) {
					dicItemOwner.Remove (listIdx);
				}
				Display ();
			} else if (Input.GetKeyDown (KeyCode.Alpha3)) {	
				Debug.Log ("Use > " + listIdx);
				UseItemOwner (listIdx, useCnt);
				Display ();
			}
		}

		bool UseItemOwner(string _listIdx, int _useCnt){
			if (dicItemOwner.ContainsKey (listIdx)) {
				ItemOwner _owner = dicItemOwner [listIdx];
				if (_owner.CheckCnt (_useCnt)) {
					_owner.UseItem (_useCnt);
					Debug.Log ("Use > " + _useCnt);
					return true;
				} else {
					Debug.Log ("Lack Item > " + _useCnt);
				}
			} else {
				Debug.Log ("Not own > " + _useCnt);
			}

			return false;
		}


		void AddItemOwner(ItemOwner _itemowner){

			if (dicItemOwner.ContainsKey (_itemowner.listIdx.ToString ())) {
				Debug.Log (" Exist > Plus");

				dicItemOwner [_itemowner.listIdx.ToString ()].AddCnt (_itemowner.cnt);
			} else {
				Debug.Log (" Not Exist > Add");
				dicItemOwner.Add (
					_itemowner.listIdx.ToString (),
					_itemowner
				);
			}
		}

		void Display(){
			foreach (KeyValuePair<string, ItemOwner> _p in dicItemOwner) {
				Debug.Log (_p.Key + " > " + _p.Value.GetValues ());
			}
		}
	} 
}