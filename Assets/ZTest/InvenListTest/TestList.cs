using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ListTest{
	public class TestList : MonoBehaviour {
		public int idxItemOwner;
		public List<ItemOwner> listItemOwner = new List<ItemOwner>();
		public int idxGiftItem;
		public List<GiftItem> listGiftItem = new List<GiftItem> ();

		void Start(){

			ItemOwner _itemowner;
			for(int i = 0; i < 5; i++){
				
				_itemowner = new ItemOwner(i, i* 100, i+"A");
				listItemOwner.Add (_itemowner);
			//	Debug.Log (i);
			}

			GiftItem _giftitem;
			for (int i = 0; i < 5; i++) {

				_giftitem = new GiftItem (i, i * 100, i+1, i + "A");
				listGiftItem.Add (_giftitem);
				Debug.Log (i);
			}
		}

		void Update(){
			
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				Debug.Log ("alpha1");
				int rdm = Random.Range (5, 20);
				ItemOwner _itemowner = new ItemOwner (rdm, rdm * 100, rdm + "B");
				listItemOwner.Add (_itemowner);			
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				Debug.Log ("alpha2");
				if (listItemOwner.Count > 0) {
					int _idx = Random.Range (0, listItemOwner.Count);
					listItemOwner.RemoveAt (_idx);
				}
			} else if (Input.GetKeyDown (KeyCode.A)) {
				listItemOwner[idxItemOwner].Display();			
			
			} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
				
				int rdm = Random.Range (5, 20);
				GiftItem _giftitem = new GiftItem(rdm, rdm* 100, rdm+1, rdm+"B");
				listGiftItem.Add (_giftitem);
			} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
				Debug.Log ("alpha4");
				if (listGiftItem.Count > 0) {
					listGiftItem.RemoveAt (listGiftItem.Count -1);
				}
			} else if (Input.GetKeyDown (KeyCode.B)) {
				listGiftItem[idxGiftItem].Display();	
			}
		}
	} 
}