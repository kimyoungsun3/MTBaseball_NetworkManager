using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServerData {
	#region 유저정보.
	private static int cashcost1_;
	private static int cashcost2_;
	public static int cashcost{
		get {
			return cashcost1_ + cashcost2_;
		}

		set {
			cashcost1_ = value / 2;
			cashcost2_ = value - cashcost1_;
		}
	}

	public static string birthday;
	#endregion

	public static Dictionary<int, ItemOwner> dicItemOwner = new Dictionary<int, ItemOwner>();
	public static List < DataGiftItem > listGiftItem = new List<DataGiftItem> ();

	//-------------------------------------------------------
	//초기화.
	//-------------------------------------------------------
	public static void Init(){		
		dicItemOwner.Clear();
		listGiftItem.Clear ();
	}


	//-------------------------------------------------------
	//
	//-------------------------------------------------------
	#region 보유템.
	public static void ReadItemOwner(SSParser _parser, string _xml, string _parseName){		
		ItemOwner _itemOwner = null;
		_parser.parsing ( _parseName );
		while (_parser.next ())
		{
			int _listidx = _parser.getInt("listidx");		//인벤에서의 인덱스이다. 
			if (dicItemOwner.ContainsKey (_listidx)) {
				continue;
			}

			_itemOwner = new ItemOwner ();

			_itemOwner.listIdx 		= _parser.getInt("listidx");		//인벤에서의 인덱스이다. 
			_itemOwner.invenkKind 	= _parser.getInt("invenkind");		//인벤의 종류...
																		//착용인벤 Protocol.USERITEM_INVENKIND_WEAR
																		//조각인벤 Protocol.USERITEM_INVENKIND_PIECE
																		//소비인벤 Protocol.USERITEM_INVENKIND_CONSUME
			_itemOwner.itemcode 	= _parser.getInt("itemcode");		//아이템 코드.
			_itemOwner.cnt 			= _parser.getInt("cnt");			//수량.
			_itemOwner.randSerial 	= _parser.getInt("randserial");		//랜덤 시리얼을 만들어 두세요...
																		//1. 구매시에는...
																		// SSUtil.getRandSerial() 호출해서 달리 보내면 구매동작을 합니다.
																		// 동일한 씨리어을 보내시면 구매되어 있으면 재구매 안하고...
																		// 안되어 있으면 구매한다.
																		//2. 동일 제품을 구매 할 경우.
																		// > 다른 씨리얼을 보내야한다. 안그러면 구매 안해줌...

			dicItemOwner.Add (_itemOwner.listIdx, _itemOwner);
		}
	}

	public static bool UseItemOwer(ItemOwner _itemOwner, int _useCount){
		return UseItemOwer ( _itemOwner.listIdx, _useCount );
	}

	public static bool UseItemOwer(int _listIdx, int _useCount){
		bool _rtn = false;
		if (dicItemOwner.ContainsKey (_listIdx)) {
			ItemOwner _itemOwner = dicItemOwner [_listIdx];

			_rtn = true;

		}

		return _rtn;
	}
	#endregion

	#region 선물 정보 읽기.
	public static void ReadGiftItem ( SSParser _parser , string _xml , string _target )
	{
		DataGiftItem _data = null;
		_parser.parsing(_xml, _target);

		while(_parser.next())
		{
			_data = new DataGiftItem ();

			_data.idx			= _parser.getInt("idx");				//선물 고유번호. 선물 받을 때 사용하는 코드.
			_data.giftkind		= _parser.getInt("giftkind");			//선물, 쪽지분류.
																		//메시지(1)		Protocol.GIFTLIST_GIFT_KIND_MESSAGE
																		//선물(2)		Protocol.GIFTLIST_GIFT_KIND_GIFT
			_data.message		= _parser.getString("message");			//메시지 내용.
			_data.itemcode		= _parser.getInt("itemcode");			//선물 아이템 코드.
			_data.cnt			= _parser.getInt64("cnt");				//선물수량.
			_data.giftdate		= _parser.getString("giftdate");		//선물 일자.
			_data.giftid		= _parser.getString("giftid");			//선물한 유저.

			listGiftItem.Add ( _data );
		}
	}

	public static DataGiftItem GetGiftItem ( int _idx )
	{
		DataGiftItem _targetData = null;
		for ( int i = 0 ; i < listGiftItem.Count; i++ )
		{

			if ( listGiftItem[ i ].idx == _idx )
			{
				_targetData = listGiftItem[ i ];
				break;
			}
		}

		return _targetData;
	}
	#endregion


	//-------------------------------------------------------
	//
	//-------------------------------------------------------
	#region 랜덤 씨리얼.
	public static string serial_itembuy;
	public static string serial_boxopen;
	public static string serial_combine;

	public static void Init_RandSerial ()
	{
		ChangeSerial_ItemBuy ();
		ChangeSerial_BoxOpen ();
		ChangeSerial_Combine ();
	}

	public static void ChangeSerial_ItemBuy ()
	{
		serial_itembuy = SSUtil.getRandSerial ();
	}

	public static void ChangeSerial_BoxOpen ()
	{
		serial_boxopen = SSUtil.getRandSerial ();
	}

	public static void ChangeSerial_Combine ()
	{
		serial_combine = SSUtil.getRandSerial ();
	}

	#endregion
}
