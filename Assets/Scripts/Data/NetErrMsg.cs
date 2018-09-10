using UnityEngine;
using System.Collections;

public class NetErrMsg {	
	public static string GetMsg ( int _resultCode )
	{
		string _errMent = null;
		
		switch ( _resultCode )
		{
		case Protocol.RESULT_SUCCESS:					_errMent = Msg.NET_RESULT_SUCCESS; break;

		//가입 오류.
		case Protocol.RESULT_ERROR_ID_DUPLICATE:		_errMent = Msg.NET_RESULT_ERROR_ID_DUPLICATE; break;
		case Protocol.RESULT_ERROR_ID_CREATE_MAX:		_errMent = Msg.NET_RESULT_ERROR_ID_CREATE_MAX; break;
		case Protocol.RESULT_ERROR_PHONE_DUPLICATE:		_errMent = Msg.NET_RESULT_ERROR_PHONE_DUPLICATE; break;
		case Protocol.RESULT_ERROR_EMAIL_DUPLICATE:		_errMent = Msg.NET_RESULT_ERROR_EMAIL_DUPLICATE; break;
		case Protocol.RESULT_ERROR_NICKNAME_DUPLICATE:	_errMent = Msg.NET_RESULT_ERROR_NICKNAME_DUPLICATE; break;

		//로그인 오류.
		case Protocol.RESULT_ERROR_BLOCK_USER:			_errMent = Msg.NET_RESULT_ERROR_BLOCK_USER; break;
		case Protocol.RESULT_ERROR_DELETED_USER:		_errMent = Msg.NET_RESULT_ERROR_DELETED_USER; break;
		case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:	_errMent = Msg.NET_RESULT_ERROR_NOT_FOUND_GAMEID; break;
		case Protocol.RESULT_ERROR_NOT_FOUND_PASSWORD:	_errMent = Msg.NET_RESULT_ERROR_NOT_FOUND_PASSWORD; break;
		case Protocol.RESULT_ERROR_SERVER_CHECKING:		_errMent = Msg.NET_RESULT_ERROR_SERVER_CHECKING; break;
		case Protocol.RESULT_NEWVERION_CLIENT_DOWNLOAD:	_errMent = Msg.NET_RESULT_NEWVERION_CLIENT_DOWNLOAD; break;
		case Protocol.RESULT_NEWVERION_FILE_DOWNLOAD:	_errMent = Msg.NET_RESULT_NEWVERION_FILE_DOWNLOAD; break;
		case Protocol.RESULT_ERROR_NOT_FOUND_PHONE:		_errMent = Msg.NET_RESULT_ERROR_NOT_FOUND_PHONE; break;

		//게임중에 부족.
		case Protocol.RESULT_ERROR_CASHCOST_LACK:		_errMent = Msg.NET_RESULT_ERROR_CASHCOST_LACK; break;
		case Protocol.RESULT_ERROR_ITEM_LACK:			_errMent = Msg.NET_RESULT_ERROR_ITEM_LACK; break;

		//아이템 구매, 변경.
		case Protocol.RESULT_ERROR_BUY_ALREADY:			_errMent = Msg.NET_RESULT_ERROR_BUY_ALREADY; break;
		case Protocol.RESULT_ERROR_NOT_HAVE:			_errMent = Msg.NET_RESULT_ERROR_NOT_HAVE; break;
		case Protocol.RESULT_ERROR_UPGRADE_FULL:		_errMent = Msg.NET_RESULT_ERROR_UPGRADE_FULL; break;	
		case Protocol.RESULT_ERROR_ITEM_NOSALE_KIND:	_errMent = Msg.NET_RESULT_ERROR_ITEM_NOSALE_KIND; break;
		case Protocol.RESULT_ERROR_CASH_COPY:			_errMent = Msg.NET_RESULT_ERROR_CASH_COPY; break;
		case Protocol.RESULT_ERROR_CASH_OVER:			_errMent = Msg.NET_RESULT_ERROR_CASH_OVER; break;
		case Protocol.RESULT_ERROR_MONTH_OVER:			_errMent = Msg.NET_RESULT_ERROR_MONTH_OVER; break;

		//아이템 선물.
		case Protocol.RESULT_ERROR_NOT_FOUND_ITEMCODE:	_errMent = Msg.NET_RESULT_ERROR_NOT_FOUND_ITEMCODE; break;
		case Protocol.RESULT_ERROR_GIFTITEM_NOT_FOUND:	_errMent = Msg.NET_RESULT_ERROR_GIFTITEM_NOT_FOUND; break;
		case Protocol.RESULT_ERROR_GIFTITEM_ALREADY_GAIN:_errMent = Msg.NET_RESULT_ERROR_GIFTITEM_ALREADY_GAIN; break;
		case Protocol.RESULT_ERROR_NOT_FOUND_GIFTID:	_errMent = Msg.NET_RESULT_ERROR_NOT_FOUND_GIFTID; break;
			
		//기타오류.
		case Protocol.RESULT_ERROR_RESULT_COPY:			_errMent = Msg.NET_RESULT_ERROR_RESULT_COPY; break;
		case Protocol.RESULT_ERROR_CASHCOST_COPY:		_errMent = Msg.NET_RESULT_ERROR_CASHCOST_COPY; break;
		case Protocol.RESULT_ERROR_NOT_SUPPORT_MODE:	_errMent = Msg.NET_RESULT_ERROR_NOT_SUPPORT_MODE; break;
		case Protocol.RESULT_ERROR_NOT_MATCH:			_errMent = Msg.NET_RESULT_ERROR_NOT_MATCH; break;
		case Protocol.RESULT_ERROR_DOUBLE_RANDSERIAL:	_errMent = Msg.NET_RESULT_ERROR_DOUBLE_RANDSERIAL; break;
		case Protocol.RESULT_ERROR_ITEMCOST_WRONG:		_errMent = Msg.NET_RESULT_ERROR_ITEMCOST_WRONG; break;
		case Protocol.RESULT_ERROR_NOT_FOUND_LISTIDX:	_errMent = Msg.NET_RESULT_ERROR_NOT_FOUND_LISTIDX; break;
		case Protocol.RESULT_ERROR_NOT_ENOUGH:			_errMent = Msg.NET_RESULT_ERROR_NOT_ENOUGH; break;
		case Protocol.RESULT_ERROR_PARAMETER:			_errMent = Msg.NET_RESULT_ERROR_PARAMETER; break;
		case Protocol.RESULT_ERROR_TIME_REMAIN:			_errMent = Msg.NET_RESULT_ERROR_TIME_REMAIN; break;
		case Protocol.RESULT_ERROR_ALREADY_REWARD:		_errMent = Msg.NET_RESULT_ERROR_ALREADY_REWARD; break;
		case Protocol.RESULT_ERROR_NOT_FOUND_CERTNO:	_errMent = Msg.NET_RESULT_ERROR_NOT_FOUND_CERTNO; break;
		case Protocol.RESULT_ERROR_ALREADY_REWARD_COUPON:_errMent = Msg.NET_RESULT_ERROR_ALREADY_REWARD_COUPON; break;
		case Protocol.RESULT_ERROR_CANNT_CHANGE:		_errMent = Msg.NET_RESULT_ERROR_CANNT_CHANGE; break;
		case Protocol.RESULT_ERROR_WAIT_RETURN:			_errMent = Msg.NET_RESULT_ERROR_WAIT_RETURN; break;
		case Protocol.RESULT_ERROR_TICKET_LACK:			_errMent = Msg.NET_RESULT_ERROR_TICKET_LACK; break;
		case Protocol.RESULT_ERROR_DIFFERENT_GRADE:		_errMent = Msg.NET_RESULT_ERROR_DIFFERENT_GRADE; break;
		case Protocol.RESULT_ERROR_NOT_FOUND_BOX:		_errMent = Msg.NET_RESULT_ERROR_NOT_FOUND_BOX; break;
		case Protocol.RESULT_ERROR_TIME_PASSED:			_errMent = Msg.NET_RESULT_ERROR_TIME_PASSED; break;
		case Protocol.RESULT_ERROR_PRODUCT_EXPIRE:		_errMent = Msg.NET_RESULT_ERROR_PRODUCT_EXPIRE; break;
		case Protocol.RESULT_ERROR_PRODUCT_EXHAUSTED:	_errMent = Msg.NET_RESULT_ERROR_PRODUCT_EXHAUSTED; break;
		case Protocol.RESULT_ERROR_NOT_FOUND_OTHERID:	_errMent = Msg.NET_RESULT_ERROR_NOT_FOUND_OTHERID; break;
		case Protocol.RESULT_ERROR_SESSION_ID_EXPIRE:	_errMent = Msg.NET_RESULT_ERROR_SESSION_ID_EXPIRE; break;

		default :
			_errMent = Msg.NET_NOT_FOUND_ERR + "\n( code : "+ _resultCode.ToString () +" )"; break;
		}	
		
		return _errMent ;
	}
}
