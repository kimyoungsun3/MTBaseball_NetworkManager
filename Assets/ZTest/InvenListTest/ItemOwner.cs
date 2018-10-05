using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ListTest{
	[System.Serializable]
	public class ItemOwner{
		public int listIdx;
		public int itemCode;
		public string itemName;
		public int cnt;

		//---------------------------------------
		public ItemOwner(){
		}

		public ItemOwner(int _listIdx, int _itemcode, string _name){
			listIdx = _listIdx;
			itemCode = _itemcode;
			itemName = _name;
			cnt = 999;
		}

		public ItemOwner(int _listIdx, int _itemcode, string _name, int _cnt){
			listIdx = _listIdx;
			itemCode = _itemcode;
			itemName = _name;
			cnt = _cnt;
		}

		//---------------------------------------
		public void Display(){
			Debug.Log (listIdx + " > " + itemCode + ", " + itemName + " , " + cnt);
		}
		public string GetValues(){
			return listIdx + " > " + itemCode + ", " + itemName + " , " + cnt;

		}

		public void AddCnt(int _cnt){
			cnt += _cnt;
		}

		public bool CheckCnt (int _useCnt){
			return cnt - _useCnt >= 0;
		}

		public void UseItem(int _useCnt){
			cnt -= _useCnt;
		}
	}
}