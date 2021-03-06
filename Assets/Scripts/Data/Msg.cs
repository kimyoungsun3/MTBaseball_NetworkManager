using UnityEngine;
using System.Collections;
public class Msg  {

	public const string CROP_UPGRADE_COMPLETE = "업그레이드 완료!!";
	public const string LV = "Lv.{0}";
	public const string UPGRADE_FAIL = "업그레이드 실패";

	public const string NET_RESULT_SUCCESS 						= "정상 처리되었습니다.";
	public const string NET_NOT_FOUND_ERR 						= "알 수 없는 오류";

	public const string NET_RESULT_ERROR_ID_DUPLICATE 			= "아이디가 중복되었습니다.";
	public const string NET_RESULT_ERROR_ID_CREATE_MAX 			= "아이디 생성에 제한이 걸렸습니다.";
	public const string NET_RESULT_ERROR_PHONE_DUPLICATE 		= "핸드폰 번호가 중복되었습니다.";
	public const string NET_RESULT_ERROR_EMAIL_DUPLICATE 		= "이메일이 중복되었습니다.";
	public const string NET_RESULT_ERROR_NICKNAME_DUPLICATE 	= "닉네임을 다른 사람이 사용중입니다.";


	public const string NET_RESULT_ERROR_BLOCK_USER 			= "블럭처리된 유져 입니다.";
	public const string NET_RESULT_ERROR_DELETED_USER 			= "삭제된 계정입니다.";
	public const string NET_RESULT_ERROR_NOT_FOUND_GAMEID 		= "아이디가 틀렸습니다.";
	public const string NET_RESULT_ERROR_NOT_FOUND_PASSWORD 	= "비밀번호가 틀렸습니다.";
	public const string NET_RESULT_ERROR_SERVER_CHECKING 		= "시스템 점검중 입니다.";
	public const string NET_RESULT_NEWVERION_CLIENT_DOWNLOAD 	= "신규 버전이 출시 되었습니다.\n다운로드 페이지로 이동합니다.";
	public const string NET_RESULT_NEWVERION_FILE_DOWNLOAD 		= "추가 다운로드가 있습니다.";
	public const string NET_RESULT_ERROR_NOT_FOUND_PHONE  		= "폰번호를 찾을 수 없습니다.";

	public const string NET_RESULT_ERROR_CASHCOST_LACK 			= "다이아가 부족합니다.";
	public const string NET_RESULT_ERROR_ITEM_LACK  			= "아이템이 부족합니다.";

	public const string NET_RESULT_ERROR_BUY_ALREADY 			= "이미 구했습니다.";
	public const string NET_RESULT_ERROR_NOT_HAVE 				= "보유하지 않고 있습니다.";
	public const string NET_RESULT_ERROR_UPGRADE_FULL 			= "업그레이드가 최대치 입니다.";
	public const string NET_RESULT_ERROR_ITEM_NOSALE_KIND 		= "판매되지 않는 아이템입니다.";
	public const string NET_RESULT_ERROR_CASH_COPY				= "캐쉬를 카피 모니터 되었습니다.";
	public const string NET_RESULT_ERROR_CASH_OVER 				= "캐쉬를 더이상 보유 할 수 없습니다.";
	public const string NET_RESULT_ERROR_MONTH_OVER 			= "월 한도를 초과 했습니다.";

	public const string NET_RESULT_ERROR_NOT_FOUND_ITEMCODE 	= "아이템 코드를 찾을 수 없습니다.";
	public const string NET_RESULT_ERROR_GIFTITEM_NOT_FOUND 	= "선물 아이템이 존재하지 않습니다.";
	public const string NET_RESULT_ERROR_GIFTITEM_ALREADY_GAIN 	= "아이템을 이미 지급받았습니다.";
	public const string NET_RESULT_ERROR_NOT_FOUND_GIFTID 		= "선물할 아이디를 찾지 못했습니다.";

	public const string NET_RESULT_ERROR_RESULT_COPY 			= "결과를 카피할려고 하셨습니다.";
	public const string NET_RESULT_ERROR_CASHCOST_COPY 			= "캐쉬를 카피 시도 하셨습니다.";
	public const string NET_RESULT_ERROR_NOT_SUPPORT_MODE 		= "지원하지 않는 모드 입니다.";
	public const string NET_RESULT_ERROR_NOT_MATCH 				= "매칭되는 것이 없습니다.";
	public const string NET_RESULT_ERROR_DOUBLE_RANDSERIAL 		= "랜덤시릴이 중복되었습니다.";
	public const string NET_RESULT_ERROR_ITEMCOST_WRONG 		= "아이템 가격이 잘못 되었습니다.";
	public const string NET_RESULT_ERROR_NOT_FOUND_LISTIDX 		= "해당 아이템 존재하지 않습니다.";
	public const string NET_RESULT_ERROR_NOT_ENOUGH 			= "충분하지 않습니다.";
	public const string NET_RESULT_ERROR_PARAMETER 				= "파라미터 오류";
	public const string NET_RESULT_ERROR_TIME_REMAIN 			= "시간이 남아 있습니다.";
	public const string NET_RESULT_ERROR_ALREADY_REWARD 		= "보상은 이미 지급했습니다.";
	public const string NET_RESULT_ERROR_NOT_FOUND_CERTNO 		= "쿠폰 번호를 찾을 수 없습니다.";
	public const string NET_RESULT_ERROR_ALREADY_REWARD_COUPON 	= "이미 지급했습니다.";
	public const string NET_RESULT_ERROR_CANNT_CHANGE		 	= "변경할 수 없습니다.";
	public const string NET_RESULT_ERROR_WAIT_RETURN 			= "요청 대기중입니다.";
	public const string NET_RESULT_ERROR_TICKET_LACK 			= "티켓이 부족합니다.";
	public const string NET_RESULT_ERROR_DIFFERENT_GRADE 		= "등급이 다릅니다.";
	public const string NET_RESULT_ERROR_NOT_FOUND_BOX 			= "박스를 찾을 수 없습니다.";
	public const string NET_RESULT_ERROR_TIME_PASSED 			= "시간이 지났습니다.";
	public const string NET_RESULT_ERROR_PRODUCT_EXPIRE 		= "해당 상품이 만기 되었습니다.";
	public const string NET_RESULT_ERROR_PRODUCT_EXHAUSTED 		= "해당상품이 모두 판ㅐ되었거나 조기 종영되었습니다.";
	public const string NET_RESULT_ERROR_NOT_FOUND_OTHERID 		= "상대 아이디를 찾을 수 없습니다.";
	public const string NET_RESULT_ERROR_SESSION_ID_EXPIRE 		= "세션이 만료되었습니다.";


	public const string NET_CONNECTION_TRY 						= "연결을 다시 시도합니다.";
	public const string NET_CONNECTION_TRY_2 					= "네트워크 연결이 끊어졌습니다.\n랜이나 무선인터넷 연결상태를 확인하여 주세요.\n\n연결을 다시 시도합니다.";
	public const string NET_CONNECTION_TRY_WITH_OUT_RETRY 		= "네트워크 연결이 끊어졌습니다.\n랜이나 무선인터넷 연결상태를 확인하여 주세요.";

	public const string SYSINQUIRE_TITLE 						= "고객 센터";
	public const string SYSINQUIRE_TOP_TEXT_01 					= "문의 내용을 상세히 적어주세요.";
	public const string SYSINQUIRE_TOP_TEXT_02 					= "( 고객 센터 운영 시간:평일 10:00 ~ 19:00 )";
	public const string SYSINQUIRE_CATOGORY_DEFAULT 			= "카테고리";
	public const string SYSINQUIRE_TEXT_DEFAULT 				= "문의 사항을 작성해 주세요.";
	
	public const string SYSINQUIRE_CHECK_MSG 					= "작성하신 내용으로 문의 하시겠습니까?";
	public const string SYSINQUIRE_NET_SUCCESS 					= "문의 하기를 보냈습니다.";
	public const string SYSINQUIRE_NET_FAIL						= "문의 하기를 보내지 못했습니다.\n잠시 후 다시 시도해 주세요.";

}





























