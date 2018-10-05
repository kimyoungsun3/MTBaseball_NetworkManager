using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ListTest{
	[System.Serializable]
	public class GiftItem{
		public int listIdx;
		public int itemCode;
		public int cnt;
		public string itemName;

		public GiftItem(){
		}

		public GiftItem(int _listIdx, int _itemcode, int _cnt, string _name){
			listIdx 	= 	_listIdx;
			itemCode 	= 	_itemcode;
			cnt 		= 	_cnt;
			itemName 	= 	_name;
		}
		public void Display(){
			Debug.Log (listIdx + " > " + itemCode+ ", " + cnt + ", " + itemName);
		}
	}
}