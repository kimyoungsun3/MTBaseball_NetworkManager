#define BUILD_MODE_REAL
//#define BUILD_MODE_DEBUG

#define SERVER_MODE_TEST_FREE
//#define SERVER_MODE_REAL_FREE

using UnityEngine;
using System.Collections;

public class Protocol{
	#region MARKET_MODE
	/////////////////////////////////////////////////////////////////////
	//	
	/////////////////////////////////////////////////////////////////////
	public const int 	VERSION			= 100;			
	public const int 	VERSION_CODE	= 1;
	public const string MARKET_BRANCH	= "pc";
	#endregion

	/////////////////////////////////////////////////////////
	/// 기존정의값.
	public const int 	AGREEMENT_KO				= 0,	//한글 약관동의.
					 	AGREEMENT_EN 				= 1;	//영문 약관동의.

	public const float LIMIT_CONNECT_TIME 			= 30f;	//40초.
	public const string NULL_VALUE_STR				= "-1";

	// 개인 사용.
	public const int BUILD_MODE_REAL 				= 1;
	public const int BUILD_MODE_DEBUG 				= 2;
	#if BUILD_MODE_REAL
		public const int 	BUILD_MODE		= Protocol.BUILD_MODE_REAL;
	#elif BUILD_MODE_DEBUG
		public const int 	BUILD_MODE		= Protocol.BUILD_MODE_DEBUG;
	#endif



	#region SERVER_MODE
	/////////////////////////////////////////////////////////////////////
	//	실서버와 테스트서버
	/////////////////////////////////////////////////////////////////////
	#if SERVER_MODE_TEST_FREE
		public const string SERVER 			= "http://49.247.202.212:8086/GameMTBaseball/" + MARKET_BRANCH + "/";		
	#elif SERVER_MODE_REAL_FREE
		public const string SERVER 			= "http://49.247.202.212:8086/GameMTBaseball/" + MARKET_BRANCH + "/";
	#endif
	#endregion

	/////////////////////////////////////////////////////////////////////
	//  Client -> Server Request.
	//  PTC_XXX	: Client -> Server
	//  PTS_XXX	: Client <- Server
	/////////////////////////////////////////////////////////////////////
	#region PTC, PTS
	public const int 	
						//PTC_NOTICE		= 0,	//notice.jsp
						//PTS_NOTICE		= 0,
						PTC_CREATEID		= 1,	//createid.jsp
						PTS_CREATEID		= 1,
						PTC_LOGIN			= 2,	//login.jsp
						PTS_LOGIN			= 2,
						PTC_SERVERTIME		= 3,	//servertime.jsp
						PTS_SERVERTIME		= 3,	
						PTC_USERPARAM		= 4,	//userparam.jsp
						PTS_USERPARAM		= 4,

						PTC_GIFTGAIN		= 21, 	//giftgain.jsp
						PTS_GIFTGAIN		= 21,
						PTC_SYSINQUIRE		= 22, 	//sysinquire.jsp
						PTS_SYSINQUIRE		= 22,
						PTC_KCHECKNN		= 23, 	//kchecknn.jsp
						PTS_KCHECKNN		= 23,

						PTC_SGREADY			= 31, 	//sgready.jsp
						PTS_SGREADY			= 31, 
						PTC_SGBET			= 32, 	//sgbet.jsp
						PTS_SGBET			= 32,
						PTC_SGRESULT		= 33, 	//sgresult.jsp
						PTS_SGRESULT		= 33,	

						//@@@@ 0025 start 
						PTC_PTREADY			= 34, 	//ptready.jsp  
						PTS_PTREADY			= 34,
						PTC_PTBET			= 35, 	//ptbet.jsp
						PTS_PTBET			= 35,
						PTC_PTRESULT		= 36, 	//ptresult.jsp
						PTS_PTRESULT		= 36,		
						//@@@@ 0025 end

						//@@@@ 0030 start 
						PTC_GAMERECORD		= 37, 	//gamerecord.jsp
						PTS_GAMERECORD		= 37,	
						//@@@@ 0030 end

						PTC_XXXXX			= 99,	
						PTS_XXXXX			= 99;
	#endregion


	/////////////////////////////////////////////////////////////////////
	//  Client -> Server Request. PagetName
	/////////////////////////////////////////////////////////////////////
	#region PTG
	public const string	
						PTG_NOTICE			= "notice.jsp",
						PTG_CREATEID		= "createid.jsp",
						PTG_LOGIN			= "login.jsp",
						PTG_SERVERTIME		= "servertime.jsp",
						PTG_USERPARAM		= "userparam.jsp",
						PTG_GIFTGAIN		= "giftgain.jsp",
						PTG_SYSINQUIRE		= "sysinquire.jsp",
						PTG_KCHECKNN		= "kchecknn.jsp",

						PTG_SGREADY			= "sgready.jsp",
						PTG_SGBET			= "sgbet.jsp",
						PTG_SGRESULT		= "sgresult.jsp",

						//@@@@ 0025 start 
						PTG_PTREADY			= "ptready.jsp",
						PTG_PTBET			= "ptbet.jsp",
						PTG_PTRESULT		= "ptresult.jsp",
						//@@@@ 0025 end	

						//@@@@ 0030 start 
						PTG_GAMERECORD		= "gamerecord.jsp",
						//@@@@ 0030 end

						PTG_XXXXX			= "_xxxxx.jsp";

	#endregion

	/////////////////////////////////////////////////////////////////////
	//  //Clinet <- Server Response.(Result)
	/////////////////////////////////////////////////////////////////////
	#region RESULT_CODE
	public const int 	RESULT_SUCCESS 						=  1,	//일반성공.
						RESULT_ERROR						= -1,	//일반실패.

						//가입 오류.
						RESULT_ERROR_ID_DUPLICATE			= -2,
						RESULT_ERROR_ID_CREATE_MAX			= -3,
						RESULT_ERROR_PHONE_DUPLICATE		= -4,
						RESULT_ERROR_EMAIL_DUPLICATE		= -5,
						RESULT_ERROR_NICKNAME_DUPLICATE		= -6,

						//로그인 오류.
						RESULT_ERROR_BLOCK_USER 			= -11, 		//블럭유저 > 팝업처리후 인트로로 빼버린다.
						RESULT_ERROR_DELETED_USER			= -12, 		//삭제유저 > 팝업처리후 인트로로 빼버린다.
						RESULT_ERROR_NOT_FOUND_GAMEID		= -13,		//해당유저를 찾지 못함.
						RESULT_ERROR_NOT_FOUND_PASSWORD		= -17,
						RESULT_ERROR_SERVER_CHECKING		= -14,		//서버를 점검하고 있다.
						RESULT_NEWVERION_CLIENT_DOWNLOAD 	= -15,		//신버젼이 나왔다 > 새버젼을 받아라 메세지 처리후 링크처리.
						RESULT_NEWVERION_FILE_DOWNLOAD 		= -16, 		//신버젼이 나왔다 > 새버젼을 받아라 메세지 처리후 종료.
						RESULT_ERROR_NOT_FOUND_PHONE		= -76,

						//게임중에 부족.
						RESULT_ERROR_CASHCOST_LACK			= -22,	//캐쉬가 부족하다.
						RESULT_ERROR_GAMECOST_LACK			= -24, 	//볼(gamecost)가 부족.
						RESULT_ERROR_ITEM_LACK				= -23,	//아이템이부족하다.

						//아이템 구매, 변경.
						RESULT_ERROR_BUY_ALREADY			= -31,  //이미 구매했습니다.
						RESULT_ERROR_NOT_HAVE				= -32,  //보유하지 않고 있다.
						RESULT_ERROR_UPGRADE_FULL			= -35,	//업그레이드가 풀로되었다.
						RESULT_ERROR_ITEM_NOSALE_KIND		= -37,	//판매하지 않는 아이템.
						RESULT_ERROR_CASH_COPY				= -40,
						RESULT_ERROR_CASH_OVER				= -41,
						RESULT_ERROR_MONTH_OVER				= -42,	//한달동안 구매한도를 검사.

						//아이템 선물.
						RESULT_ERROR_NOT_FOUND_ITEMCODE 	= -50,	//아이템코드못찾음.
						RESULT_ERROR_GIFTITEM_NOT_FOUND		= -51,	//선물아이템을 못찾음.
						RESULT_ERROR_GIFTITEM_ALREADY_GAIN	= -52,	//선물을 이미 가져감.
						RESULT_ERROR_NOT_FOUND_GIFTID		= -75,	//캐쉬 > 선물할 아이디를 못찾음.

						//MT SMS
						RESULT_ERROR_SMS_NOT_MATCH_PHONE	= -80, 	//문자추천.
						RESULT_ERROR_SMS_KEY_DUPLICATE		= -81,
						RESULT_ERROR_SMS_REJECT				= -84,
						RESULT_ERROR_SMS_DOUBLE_PHONE		= -85,
						RESULT_ERROR_KEY_DUPLICATE			= -86,	//일반 키가 중복되었다.

						//기타오류.
						RESULT_ERROR_RESULT_COPY			= -53,	//결과카피시도.
						RESULT_ERROR_CASHCOST_COPY			= -200,	//캐쉬카피시도
						RESULT_ERROR_NOT_SUPPORT_MODE		= -70,	//지원하지않는모드.
						RESULT_ERROR_NOT_MATCH				= -110,	//무엇인가 매치가 안되었다.
						RESULT_ERROR_DOUBLE_RANDSERIAL		= -111,	//랜덤시리얼 중복.
						RESULT_ERROR_ITEMCOST_WRONG			= -113, //아이템 가격이 이상함.
						RESULT_ERROR_NOT_FOUND_LISTIDX		= -114,	//리스트 번호를 못찾음.
						RESULT_ERROR_NOT_ENOUGH				= -115,	//무엇인가 충분하지 않음.
						RESULT_ERROR_PARAMETER				= -122, //파라미터오류.
						RESULT_ERROR_TIME_REMAIN			= -123, //아직 시간이 남음.
						RESULT_ERROR_ALREADY_REWARD			= -126,	//무엇인가 이미보상했음.
						RESULT_ERROR_NOT_FOUND_CERTNO		= -133,	//쿠폰 번호가 없음.
						RESULT_ERROR_CANNOT_USED_NICKNAME	= -141, //닉네임 사용불가.
						RESULT_ERROR_ALREADY_REWARD_COUPON	= -143,	//쿠폰은 1인 1매.
						RESULT_ERROR_CANNT_CHANGE			= -146, //무엇인가를 변경할 수 없습니다.
						RESULT_ERROR_WAIT_RETURN			= -148,	//요청 대기중입니다.
						RESULT_ERROR_TICKET_LACK			= -150,	 
						RESULT_ERROR_DIFFERENT_GRADE		= -154,	//등급이 다릅니다.
						RESULT_ERROR_NOT_FOUND_BOX			= -156,	//박스를 찾을 수 없습니다.
						RESULT_ERROR_TIME_PASSED			= -160,	//시간이 지났습니다.
						RESULT_ERROR_PRODUCT_EXPIRE			= -165,	//해당상품이 만기되었습니다.
						RESULT_ERROR_PRODUCT_EXHAUSTED		= -166,	//해당상품이 모두 판매되었거나 및 조기종영되었습니다.
						RESULT_ERROR_NOT_FOUND_OTHERID		= -83,	//
						RESULT_ERROR_SESSION_ID_EXPIRE_LOGOUT= -151,//세션이 만료되었습니다.
						RESULT_ERROR_DOUBLE_IP				= -201, //IP중복...
						RESULT_ERROR_TURNTIME_WRONG			= -203, //회차정보가 잘못되었다.
						RESULT_ERROR_NOT_BET_ITEMLACK		= -204, //아이템을 배팅하지 않고 배팅할려고하였습니다.
						RESULT_ERROR_NOT_BET_OVERTIME		= -211, //오버타임이상에서는 배팅불가.
						RESULT_ERROR_NOT_BET_SAFETIME		= -205, //30초 ~ 결과 ~ 10초 이시간에는 배팅금지.
						RESULT_ERROR_NOT_INPUT_SUPERBALL_5TRY		= -207,	// 슈퍼볼 데이터가 아직 안들어옴… > 5초후에 다시 요청.
						RESULT_ERROR_NOT_ING_TURNTIME				= -208,	// 강제로 로그 아웃을 시켜주세요… (이미 타임을 지나간 것을 결과 요청이라서).
						RESULT_ERROR_NOT_CALCULATE_LOTTO_WAIT_LOBBY	= -209,	// 로또에서 회차 정보가 5분이 되어도 안옴… > 로비에서 대기해주세요.
						RESULT_ERROR_NOT_CALCULATE_LOTTO_LOGOUT		= -210,	// 로또에서 회차 정보가 오버타임지나도(5+5분) 안들어옴… > 내부취소마킹, 로그아웃, 점검중.
						RESULT_ERROR_ITEMCODE_GRADE_CHECK			= -212, // 아이템 등급이 잘못되었습니다.
						RESULT_ERROR_MINUMUN_LACK					= -213,	// 최소수량보다 부족.

						RESULT_XXXXXX						= -999;
	#endregion

	
	#region 정의값들.
	public const int 	CONNECT_STATE_NON					= 0,
						CONNECT_STATE_TRY					= 1,
						CONNECT_STATE_WAIT					= 2,
						CONNECT_STATE_TIMEOVER				= 3,
						CONNECT_STATE_SUCCESS				= 10,
						CONNECT_STATE_FAIL					= -1;
	
	public const int 	//게임서버 상태값.
					 	SYSTEM_CHECK_SERVICE				= 0,	//게임서버 서비스.
					 	SYSTEM_CHECK_CHECKING				= 1,	//        점검중.	

						//선물 종류.
						GIFTLIST_GIFT_KIND_MESSAGE			= 1,	//선물(메세지).
						GIFTLIST_GIFT_KIND_GIFT				= 2,	//선물(아이템).
						GIFTLIST_GIFT_KIND_MESSAGE_DEL		= -1,	//메세지 삭제.
						GIFTLIST_GIFT_KIND_GIFT_DEL			= -2,	//선물 삭제(안받고 삭제).
						GIFTLIST_GIFT_KIND_GIFT_GET			= -3,	//선물 받기(해당템만 전송).
						GIFTLIST_GIFT_KIND_GIFT_SELL		= -4,	//선물 바로판매.
						GIFTLIST_GIFT_KIND_LIST				= -5,	//리스트.

						MODE_RETURN_STATE_NON				= 0, 	// 활동.
						MODE_RETURN_STATE_SENDED			= 1, 	// 이미요청.		
						MODE_RETURN_STATE_LONG				= 2, 	// 장기미접속.

						//유저 파라미터 사용방법.
						USERPARAM_MODE_SAVE					= 1,	//저장, 
						USERPARAM_MODE_READ					= 2,	//읽기모드.

						//MT 게임모드.
						GAME_MODE_PRACTICE					= 0,	//연습모드.
						GAME_MODE_SINGLE					= 1, 	//싱글모드.
						GAME_MODE_MULTI						= 2,	//멀티모드.

						//선택한 것들...
						SELECT_1							= 1, 	//스트라이크, 볼.
						SELECT_2							= 2, 	//직구, 변화구.
						SELECT_3							= 3, 	//좌, 우.
						SELECT_4							= 4, 	//상, 하.
						SELECT_1_NON						= -1,	//스트라이크, 볼 : 	선택안함(-1).
						SELECT_1_STRIKE						= 0,	//  				스트라이크(0).
						SELECT_1_BALL						= 1,	//     				볼(1).
						SELECT_2_NON						= -1,	//직구, 변화구 : 	선택안함(-1).
						SELECT_2_FAST						= 0,	//  				직구(0).
						SELECT_2_CURVE						= 1,	//     				변화구(1).
						SELECT_3_NON						= -1,	//좌, 우. 		: 	선택안함(-1).
						SELECT_3_LEFT						= 0,	//  				좌(0).
						SELECT_3_RIGHT						= 1,	//     				우(1).
						SELECT_4_NON						= -1,	//상, 하 		: 	선택안함(-1).
						SELECT_4_UP							= 0,	//  				상(0).
						SELECT_4_DOWN						= 1,	//     				하(1).

						//@@@@ 0021 start 
						//배팅결과.
						GAME_RESULT_ING						= -1,
						GAME_RESULT_OUT						= 0,
						GAME_RESULT_ONEHIT					= 1,
						GAME_RESULT_TWOHIT					= 2,
						GAME_RESULT_THREEHIT				= 3,
						GAME_RESULT_HOMERUN					= 4,

						//결과 플레그정보.
						RESULT_SELECT_NON					= -1,
						RESULT_SELECT_LOSE					=  0,
						RESULT_SELECT_WIN					=  1,
						//@@@@ 0021 end
						XXXXXXXXXXXXXXXXXXXXXXXXXX1			= -1;

	public const int 	//아이템의 인벤, 대분류, 중분류.
						//인벤의 종류.
						USERITEM_INVENKIND_WEAR				= 1,	//착용인벤.
						USERITEM_INVENKIND_PIECE			= 2,	//조각인벤.
						USERITEM_INVENKIND_CONSUME			= 3,	//소비인벤.

						//아이템 대분류...
						ITEM_MAINCATEGORY_WEARPART 			= 1,	//장착템(1)
						ITEM_MAINCATEGORY_PIECEPART			= 15,	//조각템(15)
						ITEM_MAINCATEGORY_COMSUME			= 40,	//소모품(40)
						ITEM_MAINCATEGORY_CASHCOST 			= 50,	//캐쉬선물(50)
						ITEM_MAINCATEGORY_STATICINFO 		= 500,	//정보수집(500)
						ITEM_MAINCATEGORY_LEVELUPREWARD		= 510,	//레벨업 보상(510)

						//MT 아이템 소분류.
						ITEM_SUBCATEGORY_WEAR_HELMET		= 1,	//헬멧(1)
						ITEM_SUBCATEGORY_WEAR_SHIRT			= 2,	//상의(2)
						ITEM_SUBCATEGORY_WEAR_PANTS			= 3,	//하의(3)
						ITEM_SUBCATEGORY_WEAR_GLOVES		= 4,	//장갑(4)
						ITEM_SUBCATEGORY_WEAR_SHOES			= 5,	//신발(5)
						ITEM_SUBCATEGORY_WEAR_BAT			= 6,	//방망이(6)
						ITEM_SUBCATEGORY_WEAR_BALL			= 7,	//색깔공(7)
						ITEM_SUBCATEGORY_WEAR_GOGGLE		= 8,	//고글(8)
						ITEM_SUBCATEGORY_WEAR_WRISTBAND		= 9,	//손목 아대(9)
						ITEM_SUBCATEGORY_WEAR_ELBOWPAD		= 10,	//팔꿈치 보호대(10)
						ITEM_SUBCATEGORY_WEAR_BELT			= 11,	//벨트(11)
						ITEM_SUBCATEGORY_WEAR_KNEEPAD		= 12,	//무릎 보호대(12)
						ITEM_SUBCATEGORY_WEAR_SOCKS			= 13,	//양말(13)
						ITEM_SUBCATEGORY_PIECE_HELMET	   	= 15,	//헬멧 조각(15)
						ITEM_SUBCATEGORY_PIECE_SHIRT	    = 16,	//상의 조각(16)
						ITEM_SUBCATEGORY_PIECE_PANTS	   	= 17,	//하의 조각(17)
						ITEM_SUBCATEGORY_PIECE_GLOVES	    = 18,	//장갑 조각(18)
						ITEM_SUBCATEGORY_PIECE_SHOES	    = 19,	//신발 조각(19)
						ITEM_SUBCATEGORY_PIECE_BAT		    = 20,	//방망이 조각(20)
						ITEM_SUBCATEGORY_PIECE_BALL			= 21,	//색깔공 조각(21)
						ITEM_SUBCATEGORY_PIECE_GOGGLE	   	= 22,	//고글 조각(22)
						ITEM_SUBCATEGORY_PIECE_WRISTBAND   	= 23,	//손목 아대 조각(23)
						ITEM_SUBCATEGORY_PIECE_ELBOWPAD		= 24,	//팔꿈치 보호대 조각(24)
						ITEM_SUBCATEGORY_PIECE_BELT			= 25,	//벨트 조각(25)
						ITEM_SUBCATEGORY_PIECE_KNEEPAD	    = 26,	//무릎 보호대 조각(26)
						ITEM_SUBCATEGORY_PIECE_SOCKS	    = 27,	//양말 조각(27)
						ITEM_SUBCATEGORY_BOX_WEAR			= 40,	//조각 랜덤박스(40)
						ITEM_SUBCATEGORY_BOX_PIECE			= 41,	//의상 랜덤박스(41)
						ITEM_SUBCATEGORY_BOX_ADVICE			= 42,	//조언 패키지 박스(42)
						ITEM_SUBCATEGORY_SCROLL_EVOLUTION	= 45,	//합성초월주문서(45)
						ITEM_SUBCATEGORY_SCROLL_COMMISSION	= 46,	//수수료주문서(46)
						ITEM_SUBCATEGORY_ETC_ITEM	= 47,	//기타템들(47)
						ITEM_SUBCATEGORY_CASHCOST			= 50,	//다이아(50)
						ITEM_SUBCATEGORY_STATICINFO			= 500,	//정보수집(500)
						ITEM_SUBCATEGORY_LEVELUPREWARD		= 900,	//레벨업 보상(510)

						XXXXXXXXXXXXXXXXXXXXXXXXXX2			= -1;
		
	#endregion
}














