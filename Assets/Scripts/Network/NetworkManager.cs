#if UNITY_EDITOR
	#define NET_DEBUG_MODE
#endif

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {
	public static NetworkManager ins;
	[HideInInspector] public int nConnectState;
	private string url, urlbase;
	private WWW www;

	public static string strCreateID,
				  		 strCreatePW,
						 strUserName, strBirthday, strEmail, strNickname,
				 		 strPhoneNumber 	= null,
				 		 strPhoneNumberC 	= null;


	void Awake()
	{	
		ins 	= this;
		urlbase = Protocol.SERVER;		
		if ( Protocol.BUILD_MODE != Protocol.BUILD_MODE_REAL )
		{
			Debug.LogWarning(" 현재 디버그 모드입니다.");
		}
		nConnectState = Protocol.CONNECT_STATE_NON;
	}

	#if NET_DEBUG_MODE
	private string strDebugMsg = "";
	private bool bNetDebug = false;
	void OnGUI(){
		//int _idx = 0;
		string _str;
		int _px = 10, _py = 10, _dx = 150, _dy = 40;
		Rect _rl;

		//netstate
		_str = "cs:" + nConnectState + " " + strDebugMsg + "[" + strPhoneNumber + ":" + strPhoneNumberC + "]";
		_rl = new Rect(_px, _py, Screen.width, _dy);
		GUI.Label(_rl, _str);

		_str = "NET on/off";
		_rl = new Rect(Screen.width - 100, Screen.height * 0.5f, 100, 40);
		if(GUI.Button(_rl, _str))bNetDebug = !bNetDebug;
		if(bNetDebug)return;

		//PTC_CREATEID
		_str = "PTC_CREATEID";
		_py += _dy;
		_rl = new Rect(_px, _py, _dx, _dy);
		if (GUI.Button (_rl, _str)) {
			sendCode (Protocol.PTC_CREATEID, null);
		}

		_str = "PTC_LOGIN";
		_py += _dy;
		_rl = new Rect(_px, _py, _dx, _dy);
		if (GUI.Button (_rl, _str)) {
			sendCode (Protocol.PTC_LOGIN, null);
		}

		_str = "PTC_SERVERTIME";
		_py += _dy;
		_rl = new Rect(_px, _py, _dx, _dy);
		if (GUI.Button (_rl, _str)) {
			sendCode (Protocol.PTC_SERVERTIME, null);
		}

		_str = "PTC_USERPARAM";
		_py += _dy;
		_rl = new Rect(_px, _py, _dx, _dy);
		if (GUI.Button (_rl, _str)) {
			sendCode (Protocol.PTC_USERPARAM, null);
		}

		_str = "PTC_GIFTGAIN";
		_py += _dy;
		_rl = new Rect(_px, _py, _dx, _dy);
		if (GUI.Button (_rl, _str)) {
			sendCode (Protocol.PTC_GIFTGAIN, null);
		}

		_str = "PTC_SYSINQUIRE";
		_py += _dy;
		_rl = new Rect(_px, _py, _dx, _dy);
		if (GUI.Button (_rl, _str)) {
			sendCode (Protocol.PTC_SYSINQUIRE, null);
		}

		_str = "PTC_SGREADY";
		_py += _dy;
		_rl = new Rect(_px, _py, _dx, _dy);
		if (GUI.Button (_rl, _str)) {
			sendCode (Protocol.PTC_SGREADY, null);
		}

		_str = "PTC_SGBET";
		_py += _dy;
		_rl = new Rect(_px, _py, _dx, _dy);
		if (GUI.Button (_rl, _str)) {
			sendCode (Protocol.PTC_SGBET, null);
		}

		_str = "PTC_SGRESULT";
		_py += _dy;
		_rl = new Rect(_px, _py, _dx, _dy);
		if (GUI.Button (_rl, _str)) {
			sendCode (Protocol.PTC_SGRESULT, null);
		}

		_str = "PTC_KCHECKNN";
		_py += _dy;
		_rl = new Rect(_px, _py, _dx, _dy);
		if (GUI.Button (_rl, _str)) {
			sendCode (Protocol.PTC_KCHECKNN, null);
		}



	}
	#endif
	
	//--------------------------------------------
	// [C -> S]
	// 1. Client -> Server 데이타 요청
	// 호출방법 : NetworkManager.Ins.sendCode
	// 멀티 호출이 가능함.
	//
	// _code			: 코드.
	// VOID_FUN_INTINT	: 응답후 함수(delegate (int, int)) 2개의 파라미터를 받을 수 있음...
	// _bPopup			: 팝업을 띄울것인가?
	//--------------------------------------------
	public bool sendCode( int _code, VOID_FUN_INTINT _onResult )
	{
		WWWForm _form = new WWWForm();
		nConnectState = Protocol.CONNECT_STATE_TRY;
		
		switch(_code)
		{
		//@@@@ 2018-09-10 start
		case Protocol.PTC_CREATEID:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C -> S] PTC_CREATEID");
				#endif
				//1. make URL
				url = urlbase + Protocol.PTG_CREATEID;

				//2. setting form
				strCreateID 		= "mtxxxx3";
				strCreatePW 		= SSUtil.setPassword( "a1s2d3f4" );
				strUserName 		= "mtusername3";
				strBirthday 		= "19980813";
				strPhoneNumber		= "01012345673";
				strPhoneNumberC 	= SSUtil.setPhoneNumber (strPhoneNumber);
				strEmail			= "mtxxxx3@xxx.xxx";
				strNickname	 		= "ntnickname3";
				//Debug.Log ("strCreatePW :" + strCreatePW);
				//Debug.Log ("strPhoneNumber :" + strPhoneNumber + " > " + strPhoneNumberC);

				_form.AddField("gameid", 	strCreateID);
				_form.AddField("password",	strCreatePW);
				_form.AddField("username", 	strUserName);
				_form.AddField("birthday", 	strBirthday);
				_form.AddField("phone", 	strPhoneNumberC);
				_form.AddField("email", 	strEmail);
				_form.AddField("nickname", 	strNickname);
				_form.AddField("version", "" + Protocol.VERSION);

				//3. sending
				#if NET_DEBUG_MODE
				Debug.Log(" _form:" + SSUtil.getString(_form.data));
				#endif
				StartCoroutine(Handle(new WWW(url, _form ), _onResult));
			}
			break;
			//@@@@ 2018-09-10 end
			//@@@@ 2018-09-13 start
		case Protocol.PTC_LOGIN:		
			{			
				#if NET_DEBUG_MODE			
				Debug.Log("[C -> S] PTC_LOGIN");			
				#endif
			
				//1. make URL			
				url = urlbase + Protocol.PTG_LOGIN;			
			
				//2. setting form
				strCreateID = "mtxxxx3";
				strCreatePW	= SSUtil.setPassword( "a1s2d3f4" );
				//Debug.Log (strCreatePW);
				//strCreatePW = "049000s1i0n7t8445289";

				_form.AddField("gameid", strCreateID);			
				_form.AddField("password", strCreatePW);
				_form.AddField("version", "" + Protocol.VERSION);
				_form.AddField("connectip", "192.168.0.8");
			
				//3. sending			
				#if NET_DEBUG_MODE			
				Debug.Log(" _form:" + SSUtil.getString(_form.data));			
				#endif
				StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
			}
			break;
			//@@@@ 2018-09-13 end
			//@@@@ 2018-09-16 start
		case Protocol.PTC_GIFTGAIN:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C -> S] PTC_GIFTGAIN");
				#endif
				//1. make URL
				url = urlbase + Protocol.PTG_GIFTGAIN;

				//2. setting form	
				//---------------------------------------------
				//1. 1번에 메세지 > 보았다는 상태로 변경하기.
				//---------------------------------------------
				_form.AddField("gameid", "mtxxxx3" );										//유저 아이디.
				_form.AddField("password", "049000s1i0n7t8445289" );					//유저 패스워드.
				_form.AddField("sid", "333" );											//로그인때 받은 sid값	Protocol.GIFTLIST_GIFT_KIND_GIFT_GET		
				_form.AddField("idx", "" + 238 );											//선물번호 인덱스.
				_form.AddField("giftkind", "" + Protocol.GIFTLIST_GIFT_KIND_GIFT_GET );	//선물 받기(해당템만 전송)(-3)		Protocol.GIFTLIST_GIFT_KIND_GIFT_GET			
				//---------------------------------------------
				//2-1. 나무헬멧 받기 > 하나씩만 들어간다.	
				//---------------------------------------------
				//gameid=xxx
				//password=xxx
				//sid=xxx
				//giftkind=xxx
				//idx=xxx(선물 번호)
				//_form.AddField("gameid", "xxxx2" );										//유저 아이디.
				//_form.AddField("password", "049000s1i0n7t8445289" );						//유저 패스워드.
				//_form.AddField("sid", "333" );											//로그인때 받은 sid값
				//_form.AddField("giftkind", "" + Protocol.GIFTLIST_GIFT_KIND_MESSAGE_DEL ); //메세지 삭제(-1).				Protocol.GIFTLIST_GIFT_KIND_MESSAGE_DEL		
				//선물 받기(해당템만 전송)(-3)	

				//_form.AddField("idx", "" + 2 );											//선물번호 인덱스.
				//
				//---------------------------------------------
				//2-2. 나무 헬멧 조각A > 수량 누적.
				//---------------------------------------------
				//gameid=xxx
				//password=xxx
				//sid=xxx
				//giftkind=xxx
				//idx=xxx(선물 번호)
				//_form.AddField("gameid", "xxxx2" );										//유저 아이디.
				//_form.AddField("password", "049000s1i0n7t8445289" );						//유저 패스워드.
				//_form.AddField("sid", "333" );											//로그인때 받은 sid값
				//_form.AddField("giftkind", "" + Protocol.GIFTLIST_GIFT_KIND_GIFT_GET );	//선물 받기(해당템만 전송)(-3)		Protocol.GIFTLIST_GIFT_KIND_GIFT_GET			
				//_form.AddField("idx", "" + 3 );											//선물번호 인덱스.
				//
				//---------------------------------------------
				//2-2. 나무 조각 랜덤박스, 나무 의상 랜덤박스, 조언 패키지 박스, 조합 주문서, 초월 주문서, 응원의 소리, 코치의 조언 주문서, 감독의 조언 주문서> 수량 누적.
				//---------------------------------------------
				//gameid=xxx
				//password=xxx
				//sid=xxx
				//giftkind=xxx
				//idx=xxx(선물 번호)
				//_form.AddField("gameid", "xxxx2" );										//유저 아이디.
				//_form.AddField("password", "049000s1i0n7t8445289" );						//유저 패스워드.
				//_form.AddField("sid", "333" );											//로그인때 받은 sid값
				//_form.AddField("giftkind", "" + Protocol.GIFTLIST_GIFT_KIND_GIFT_GET );	//선물 받기(해당템만 전송)(-3)		Protocol.GIFTLIST_GIFT_KIND_GIFT_GET			
				//_form.AddField("idx", "" + 4 );											//선물번호 인덱스.
				//
				//---------------------------------------------
				//2-3. 다이아 > cashcost에 누적.
				// * 다이아는 멀티가 있으면 cnt으로 표시
				//   다이아가 싱글로 있으면 buyamount가 올라간다.
				//   캐쉬 해킹을 방지하기 위해서....
				//---------------------------------------------
				//gameid=xxx
				//password=xxx
				//sid=xxx
				//giftkind=xxx
				//idx=xxx(선물 번호)
				//_form.AddField("gameid", "xxxx2" );										//유저 아이디.
				//_form.AddField("password", "049000s1i0n7t8445289" );						//유저 패스워드.
				//_form.AddField("sid", "333" );											//로그인때 받은 sid값
				//_form.AddField("giftkind", "" + Protocol.GIFTLIST_GIFT_KIND_GIFT_GET );	//선물 받기(해당템만 전송)(-3)		Protocol.GIFTLIST_GIFT_KIND_GIFT_GET			
				//_form.AddField("idx", "" + 12 );											//선물번호 인덱스.

				//3. sending			
				#if NET_DEBUG_MODE			
				Debug.Log(" _form:" + SSUtil.getString(_form.data));			
				#endif
				StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
			}
			break;
			//@@@@ 2018-09-16 end
			//@@@@ 2018-09-14 start
		case Protocol.PTC_SERVERTIME:		
			{			
				#if NET_DEBUG_MODE			
				Debug.Log("[C -> S] PTC_SERVERTIME");			
				#endif

				//1. make URL			
				url = urlbase + Protocol.PTG_SERVERTIME;			

				//2. setting form
				strCreateID = "mtxxxx3";
				strCreatePW = "049000s1i0n7t8445289";

				_form.AddField("gameid", strCreateID);			
				_form.AddField("password", strCreatePW);

				//3. sending			
				#if NET_DEBUG_MODE			
				Debug.Log(" _form:" + SSUtil.getString(_form.data));			
				#endif
				StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
			}
			break;
			//@@@@ 2018-09-14 end
			//@@@@ 2018-09-15 start
		case Protocol.PTC_USERPARAM:		
			{			
				#if NET_DEBUG_MODE			
				Debug.Log("[C -> S] PTC_USERPARAM");			
				#endif

				//1. make URL			
				url = urlbase + Protocol.PTG_USERPARAM;			

				//2. setting form
				strCreateID = "mtxxxx3";
				strCreatePW = "049000s1i0n7t8445289";

				//-----------------------------------
				//읽기 사용법.
				//파라미터에 공백을 보내시면 됩니다.
				//-----------------------------------
				//_form.AddField("gameid", strCreateID);			
				//_form.AddField("password", strCreatePW);		
				//_form.AddField("mode", "" + Protocol.USERPARAM_MODE_READ);			
				//_form.AddField("listset", "");					

				//-----------------------------------
				//저장 사용법.
				//-----------------------------------
				_form.AddField("gameid", strCreateID);			
				_form.AddField("password", strCreatePW);		
				_form.AddField("mode", "" + Protocol.USERPARAM_MODE_SAVE);		
				_form.AddField("listset", "0:0;1:1;2:2;3:3;4:4;5:5;6:6;7:7;8:8;9:9;");
				//							paramX자리 / 구분자(:) / 데이타 / 구분자(;)
				//							paramX자리 / 구분자(:) / 데이타 / 구분자(;)
				//							....
				//							9자리를 전송할 수 있다.

				//3. sending			
				#if NET_DEBUG_MODE			
				Debug.Log(" _form:" + SSUtil.getString(_form.data));			
				#endif
				StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
			}
			break;
			//@@@@ 2018-09-15 end
			//@@@@ 0017 start 
		case Protocol.PTC_SYSINQUIRE:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C -> S] PTC_SYSINQUIRE");
				#endif
				//1. make URL
				url = urlbase + Protocol.PTG_SYSINQUIRE;

				//2. setting form
				//---------------------------------------
				//유저 정보.
				strCreateID = "mtxxxx3";
				strCreatePW = "049000s1i0n7t8445289";
				string strMessage = "문의드립니다.";
				//---------------------------------------

				_form.AddField("gameid", strCreateID );
				_form.AddField("password", strCreatePW );
				_form.AddField("message", strMessage );					

				//3. sending
				#if NET_DEBUG_MODE
				Debug.Log(" _form:" + SSUtil.getString(_form.data));
				#endif
				StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
			}
			break;
			//@@@@ 0017 end
			//@@@@ 0018 start 
		case Protocol.PTC_SGREADY:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C -> S] PTC_SGREADY");
				#endif
				//1. make URL
				url = urlbase + Protocol.PTG_SGREADY;

				//2. setting form
				//---------------------------------------
				//유저 정보.
				strCreateID = "mtxxxx3";
				strCreatePW = "049000s1i0n7t8445289";
				//---------------------------------------
				_form.AddField("gameid", strCreateID );
				_form.AddField("password", strCreatePW );
				_form.AddField("sid", "333" );								//login에서 받은 sid
				_form.AddField("gmode", "" + Protocol.GAME_MODE_SINGLE );	//연습, 싱글, 
																			//연습  Protocol.GAME_MODE_PRACTICE
																			//싱글  Protocol.GAME_MODE_SINGLE
																			//멀티  Protocol.GAME_MODE_MULTI
				_form.AddField("listidx", "" + -1 );						//아이템은 리스트 번호.

				//3. sending
				#if NET_DEBUG_MODE
				Debug.Log(" _form:" + SSUtil.getString(_form.data));
				#endif
				StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
			}
			break;
			//@@@@ 0018 end
			//@@@@ 0019 start 
		case Protocol.PTC_SGBET:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C -> S] PTC_SGBET");
				#endif
				//1. make URL
				url = urlbase + Protocol.PTG_SGBET;

				//2. setting form
				//---------------------------------------
				//유저 정보.
				strCreateID = "mtxxxx3";
				strCreatePW = "049000s1i0n7t8445289";
				//---------------------------------------
				_form.AddField("gameid", strCreateID );
				_form.AddField("password", strCreatePW );
				_form.AddField("sid", "333" );								//login에서 받은 sid
				_form.AddField("gmode", "" + Protocol.GAME_MODE_SINGLE );	//연습, 싱글, 
																			//연습  Protocol.GAME_MODE_PRACTICE
																			//싱글  Protocol.GAME_MODE_SINGLE
																			//멀티  Protocol.GAME_MODE_MULTI
				_form.AddField("listidx", "" + 11 );						//아이템은 리스트 번호.
				_form.AddField("curturntime", "" + -1 );					//현재의 회차번호 (모르면 -1를 넣어주면된다).
				_form.AddField("select", "1:0:100;2:0:100;3:0:100;4:0:100;" );//배팅조각.
				//1. 배팅템 정보 구분자.
				//   배팅템 정보는 순서대로 들어가며 없으면 없는 정보를 셑팅.
				//   구분자는 (;)으로 해주시면 됩니다.
				//   예) 배팅템정보1;배팅템정보2;배팅템정보3;배팅템정보4;
				//
				//2. 배팅안에 구성요소 (여기의 구분자는 : )
				//   배팅번호:배팅선택종류:조각리스트번호:배팅수량;
				//
				//2-1. 배팅번호
				//Protocol.SELECT_1 		: 스트라이크, 볼.
				//Protocol.SELECT_2 		: 직구, 변화구.
				//Protocol.SELECT_3 		: 좌, 우.
				//Protocol.SELECT_4 		: 상, 하.
				//
				//2-2. 배팅선택 종류
				//
				//Protocol.SELECT_1_NON						= -1,	//스트라이크, 볼 : 	선택안함(-1).
				//Protocol.SELECT_1_STRIKE					= 0,	//  				스트라이크(0).
				//Protocol.SELECT_1_BALL					= 1,	//     				볼(1).
				//
				//Protocol.SELECT_2_NON						= -1,	//직구, 변화구 : 	선택안함(-1).
				//Protocol.SELECT_2_FAST					= 0,	//  				직구(0).
				//Protocol.SELECT_2_CURVE					= 1,	//     				변화구(1).
				//
				//Protocol.SELECT_3_NON						= -1,	//좌, 우. 		: 	선택안함(-1).
				//Protocol.SELECT_3_LEFT					= 0,	//  				좌(0).
				//Protocol.SELECT_3_RIGHT					= 1,	//     				우(1).
				//
				//Protocol.SELECT_4_NON						= -1,	//상, 하 		: 	선택안함(-1).
				//Protocol.SELECT_4_UP						= 0,	//  				상(0).
				//Protocol.SELECT_4_DOWN					= 1,	//     				하(1).
				//
				//
				//2-3. 배팅수량
				//     배팅한 조각의 수량.
				//
				//예) 1 개 배팅
				//1:0:100;2:-1:0; 3:-1:0; 4:-1:0;
				//예)4 개 배팅
				//1:0:100;2:0:100;3:0:100;4:0:100;

				//3. sending
				#if NET_DEBUG_MODE
				Debug.Log(" _form:" + SSUtil.getString(_form.data));
				#endif
				StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
			}
			break;		
			//@@@@ 0019 end
			//@@@@ 0021 start
		case Protocol.PTC_SGRESULT:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C -> S] PTC_SGRESULT");
				#endif
				//1. make URL
				url = urlbase + Protocol.PTG_SGRESULT;

				//2. setting form
				//---------------------------------------
				//유저 정보.
				strCreateID = "mtxxxx3";
				strCreatePW = "049000s1i0n7t8445289";
				//---------------------------------------
				_form.AddField("gameid", strCreateID );
				_form.AddField("password", strCreatePW );
				_form.AddField("sid", "333" );								//login에서 받은 sid
				_form.AddField("gmode", "" + Protocol.GAME_MODE_SINGLE );	//연습, 싱글,
																			//연습  Protocol.GAME_MODE_PRACTICE
																			//싱글  Protocol.GAME_MODE_SINGLE
																			//멀티  Protocol.GAME_MODE_MULTI
				_form.AddField("curturntime", "" + 830093 );				//현재의 회차번호.

				//3. sending
				#if NET_DEBUG_MODE
				Debug.Log(" _form:" + SSUtil.getString(_form.data));
				#endif
				StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
			}
			break;
			//@@@@ 0021 end

			//@@@@ 0022 start 
		case Protocol.PTC_KCHECKNN:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C -> S] PTC_KCHECKNN");
				#endif
				//1. make URL
				url = urlbase + Protocol.PTG_KCHECKNN;

				//2. setting form
				//---------------------------------------
				//유저 정보.
				strCreateID = "mtxxxx3";
				strCreatePW = "049000s1i0n7t8445289";
				//---------------------------------------
				_form.AddField("gameid", strCreateID );
				_form.AddField("password", strCreatePW );
				_form.AddField("sid", "333" );								//login에서 받은 sid
				_form.AddField("nickname", "닉네임mt3" );

				//3. sending
				#if NET_DEBUG_MODE
				Debug.Log(" _form:" + SSUtil.getString(_form.data));
				#endif
				StartCoroutine( Handle( new WWW( url, _form ), _onResult ) );
			}
			break;
			//@@@@ 0022 end.

		default:
			Debug.LogError("[error][C -> S] #### error");	
			if ( _onResult != null )
			{
				_onResult ( Protocol.CONNECT_STATE_FAIL , Protocol.CONNECT_STATE_FAIL );
			}
			break;
		}		
		return true;
	}
	

	//--------------------------------------------
	//[C <- S]
	// 2. 보내온 데이타는 data, fun으로 구성됨.
	//--------------------------------------------
	public int parseCode( string _xml ){		
		//1. 변수 선언 및 할당.
		SSParser _parser = new SSParser ();

		//Debug.Log ( _xml );

		_parser.parsing(_xml, "result");
		_parser.next();
		
		int _code 		= _parser.getInt("code");	
		int _resultcode = _parser.getInt("resultcode");
		string _msg 	= _parser.getString("resultmsg");


		//3. 내부 코드.
		switch(_code)
		{
		//@@@@ 2018-09-14 start
		case Protocol.PTS_SERVERTIME:
			{
				#if NET_DEBUG_MODE	
				Debug.Log("[C <- S] PTS_SERVERTIME _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);			
				#endif

				switch(_resultcode){
				case Protocol.RESULT_SUCCESS:
					#if NET_DEBUG_MODE
					Debug.Log(" > 서버시간 > 성공.");				
					#endif
					DateTime.Parse (_parser.getString ("curdate"));

					//현재 서버 시간 2014-11-14 10:49:57.				
					//Callendar.SetServerTime( DateTime.Parse( _parse.getString("curdate") ) );				
					break;
				default:
					#if NET_DEBUG_MODE
					Debug.Log(" > 서버시간 실패. > 팝업처리.");
					#endif
					break;				
				}
			}
			break;
			//@@@@ 2018-09-14 end
		//@@@@ 2018-09-10 start
		case Protocol.PTS_CREATEID:
			#if NET_DEBUG_MODE
			Debug.Log("[C <- S] PTS_CREATEID _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif
			
			switch(_resultcode){
			case Protocol.RESULT_SUCCESS:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_CREATEID > success");
				#endif

				//1. 서버에서 생성된 게스트 아이디 받기.
				strCreateID = _parser.getString("gameid");
				strCreatePW = _parser.getString("password");			//패스워드를 보내준것으로 새팅해야한다.
				SaveIdPwToLocalDB(strCreateID, strCreatePW);

				break;
			case Protocol.RESULT_ERROR_BLOCK_USER:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_CREATEID > error > 블럭처리된 아이디 입니다.");
				#endif
				break;

			case Protocol.RESULT_ERROR_ID_DUPLICATE:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_CREATEID > error > 아이디 중복");
				#endif
				break;
			case Protocol.RESULT_ERROR_ID_CREATE_MAX:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_CREATEID > error > 전화 번호로 허용갯수 초과입니다.");
				#endif
				break;

			case Protocol.RESULT_ERROR_EMAIL_DUPLICATE:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_CREATEID > error > 이메일이 중복입니다.");
				#endif
				break;

			case Protocol.RESULT_ERROR_NICKNAME_DUPLICATE:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_CREATEID > error > 닉네임이 중복입니다.");
				#endif
				break;
			default:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_CREATEID > error > not found error");
				#endif
				break;
			}
			break;
			//@@@@ 2018-09-10 end
			//@@@@ 2018-09-13 start
		case Protocol.PTS_LOGIN:
			#if NET_DEBUG_MODE
			Debug.Log("[C <- S] PTS_LOGIN _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
			#endif

			switch(_resultcode)
			{
			case Protocol.RESULT_SUCCESS:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_LOGIN > success");
				#endif
				//-----------------------------------------------------
				//userinfo.
				// > 유저의 일반 적인 정보가 들어 있음...
				//-----------------------------------------------------
				_parser.parsing ( _xml , "userinfo" );
				if (_parser.next ())
				{
					//************************************
					//이시간을 토대로 시간을 계산한다.
					// > 가장 중요한 부분입니다. 
					// > 별도로 시간 싱크는 계속 보내주면 별도로 맞추고 싶을 때를 위해 별도 프로 토콜을 사용할 수 있습니다.
					//************************************
					DateTime.Parse( _parser.getString("curdate") );	//2018-09-12 18:07:28.53

					//유저 개인정보...
					ServerData.cashcost = _parser.getInt("cashcost");						//캐쉬.(다이아) -> 반드시 property로 2개 이상으로 분해해서 저장하세요.
					//@@@@ 0020 start 
					_parser.getInt("gamecost");						//볼.
					//@@@@ 0020 end
					_parser.getInt("sid");							//세션ID값 -> 이값으로 서버에 요청하는 경우가 있다.
					_parser.getInt("exp");							//누적된 경험치 이다.
					_parser.getInt("level");								
					_parser.getInt("tutorial");						//tutorial -> 튜토리얼 안봄(0), 봄(1)

					//유저가 가입에 입력한 정보.
					_parser.getString("username");					//유저이름.
					ServerData.birthday = _parser.getString("birthday");					//19980801
					_parser.getString("email");						//
					_parser.getString("nickname");					//닉네임(중복검사된것)
					_parser.getString("phone");						//

					//착용아이템의 리스트 인덱스 .
					//listidx -> 유저 아이템 보유 테이블의 listidx 검색해서 해당 아이템을 찾는다.
					_parser.getInt("helmetlistidx");				//
					_parser.getInt("shirtlistidx");					//
					_parser.getInt("pantslistidx");					//
					_parser.getInt("gloveslistidx");				//
					_parser.getInt("shoeslistidx");					//
					_parser.getInt("batlistidx");					//
					_parser.getInt("balllistidx");					//
					_parser.getInt("gogglelistidx");				//
					_parser.getInt("wristbandlistidx");				//
					_parser.getInt("elbowpadlistidx");				//
					_parser.getInt("beltlistidx");					//
					_parser.getInt("kneepadlistidx");				//
					_parser.getInt("sockslistidx");					//

					//개별저장 파라미터(필요에 의해 클라이언트가 저장해서 사용하시면 됩니다.)...
					//저장을 하기 위해서 별도의 클라이언트에 저장하시지 마시고 이 변수를 통해서 저장 읽어 들이세요.
					//별도의 저장 읽기 프로 토콜이 제공됩니다.
					_parser.getInt("param0");						//
					_parser.getInt("param1");						//
					_parser.getInt("param2");						//
					_parser.getInt("param3");						//
					_parser.getInt("param4");						//
					_parser.getInt("param5");						//
					_parser.getInt("param6");						//
					_parser.getInt("param7");						//
					_parser.getInt("param8");						//
					_parser.getInt("param9");						//
				}

				//-----------------------------------------------------
				//itemowner(보유템).
				//_parser.parsing ( "itemowner" );
				//_parser.parsing ( _xml, "itemowner" );
				//-----------------------------------------------------
				ServerData.ReadItemOwner(_parser, _xml, "itemowner");
				/*
				_parser.parsing ( "itemowner" );
				while (_parser.next ())
				{
					_parser.getInt("listidx");						//인벤에서의 인덱스이다. 
					_parser.getInt("invenkind");					//인벤의 종류...
																	//착용인벤 Protocol.USERITEM_INVENKIND_WEAR
																	//조각인벤 Protocol.USERITEM_INVENKIND_PIECE
																	//소비인벤 Protocol.USERITEM_INVENKIND_CONSUME
					_parser.getInt("itemcode");						//아이템 코드.
					_parser.getInt("cnt");							//수량.
					_parser.getInt("randserial");					//랜덤 시리얼을 만들어 두세요...
																	//1. 구매시에는...
																	// SSUtil.getRandSerial() 호출해서 달리 보내면 구매동작을 합니다.
																	// 동일한 씨리어을 보내시면 구매되어 있으면 재구매 안하고...
																	// 안되어 있으면 구매한다.
																	//2. 동일 제품을 구매 할 경우.
																	// > 다른 씨리얼을 보내야한다. 안그러면 구매 안해줌...
				}
				*/

				//-----------------------------------------------------
				//선물정보(우편함 -> 선물, 메세지).
				//GameData.ReadGiftItem ( parser , _xml , "giftitem" );
				//_parser.parsing ( "giftitem" );
				//-----------------------------------------------------
				ServerData.ReadGiftItem(_parser, _xml, "giftitem");

				//_parser.parsing ( "giftitem" );
				//while (_parser.next ())
				//{
				//	_parser.getInt("idx");				//선물 인덱스 번호.			
				//	_parser.getInt("giftkind");			//선물의 종류. (아이템선물, 메세지).
				//	_parser.getString("message");		//  메세지 일경우 메세지 내용.
				//	_parser.getInt("itemcode");			//  아이템 선물일 경우 아이템 코드.
				//	_parser.getInt("cnt");				//            수량.
				//	_parser.getString("giftdate");		//보낸날짜.
				//	_parser.getString("giftid");		//보낸이.		
				//}

				//-----------------------------------------------------
				// 공지사항 정보...
				// 공지사항은 이미지를 웹에서 끌어오니까...
				// 1. 관리 페이지에서 등록 수정 해서 확인하시면됩니다.
				//
				// 2-1. 이미지를 로컬에서 검색 있으면 로컬것 사용...
				// 2-2. 없으면 웹에서 가져오시면 됩니다.
				//
				// 3. 간단한 텍스트 공지를 위해서 comment를 제공합니다.
				//    commnet를 이용해서 텍스트 공지 처리 하시면됩니다.
				//-----------------------------------------------------
				_parser.parsing ( "notice" );
				if (_parser.next ())
				{
					_parser.getString("comfile1");		//이미지 URL.
					_parser.getString("comurl1");		// > 클릭시 점프 URL.
														// > Empty로 오면 없음...
					_parser.getString("comfile2");		
					_parser.getString("comurl2");		
					_parser.getString("comfile3");		
					_parser.getString("comurl3");		
					_parser.getString("comfile4");		
					_parser.getString("comurl4");		
					_parser.getString("comfile5");		
					_parser.getString("comurl5");

					_parser.getString("comment");			
				}


				break;
			case Protocol.RESULT_ERROR_SERVER_CHECKING:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_LOGIN > error > 시스템 점검중입니다. > 게임 종료.");
				#endif
				break;
			case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_LOGIN > error > 아이디를 확인해라 > 다시 로그인.");
				#endif
				break;
			case Protocol.RESULT_NEWVERION_CLIENT_DOWNLOAD:		
				GameData.pathUrl = _parser.getString("patchurl");		//패치URL.
				#if NET_DEBUG_MODE
				Debug.Log("PTS_LOGIN > error > 클라이언트가 새로나왔습니다. > 다시 받아주세요.");
				#endif
				break;
			case Protocol.RESULT_ERROR_BLOCK_USER:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_LOGIN > error > 블럭된 계정입니다. > 다시 로그인.");
				#endif

				break;
			default:
				#if NET_DEBUG_MODE
				Debug.Log("PTS_LOGIN > error > not found error");
				#endif
				break;
			}
			break;
			//@@@@ 2018-09-13 end
			//@@@@ 2018-09-16 start
		case Protocol.PTS_GIFTGAIN:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C <- S] PTS_GIFTGAIN _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
				#endif

				switch(_resultcode){
				case Protocol.RESULT_SUCCESS:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_GIFTGAIN > success");
					#endif	

					//@@@@ 0020 start 
					_parser.getInt("cashcost");		//캐쉬.
					_parser.getInt("gamecost");		//볼.
					//@@@@ 0020 end
					//-----------------------------------------------------
					// 로그인 선물하고 동일
					// 1. 100개가 있어도 최대 전송 수량은 20개까지만 보내준다.
					// 2. 한꺼번에 받기는 하나씩 받는 것을 처리하시면 됩니다.(별도 없음)
					//-----------------------------------------------------
					_parser.parsing ( "giftitem" );
					while (_parser.next ())
					{
						_parser.getInt("idx");				//선물 인덱스 번호.			
						_parser.getInt("giftkind");			//선물의 종류. (아이템선물, 메세지).
						_parser.getString("message");		//  메세지 일경우 메세지 내용.
						_parser.getInt("itemcode");			//  아이템 선물일 경우 아이템 코드.
						_parser.getInt("cnt");				//            수량.
						_parser.getString("giftdate");		//보낸날짜.
						_parser.getString("giftid");		//보낸이.		
					}	


					//-----------------------------------------------------
					// 로그인 동일한 모양이지만 변화된것만 온다.
					// 우편함으로 새롭게 추가된 템리스트만 하나 올 수 있다.
					// 새로운것 -> listidx가 새로운것...
					// 기존것   -> listidx가 기존것을 알려준다.
					//-----------------------------------------------------
					_parser.parsing ( "itemowner" );
					while (_parser.next ())
					{
						_parser.getInt("listidx");						//인벤에서의 인덱스이다. 
						_parser.getInt("invenkind");					//인벤의 종류...
																		//착용인벤 Protocol.USERITEM_INVENKIND_WEAR
																		//조각인벤 Protocol.USERITEM_INVENKIND_PIECE
																		//소비인벤 Protocol.USERITEM_INVENKIND_CONSUME
						_parser.getInt("itemcode");						//아이템 코드.
						_parser.getInt("cnt");							//수량.
						_parser.getInt("randserial");					//랜덤 시리얼을 만들어 두세요...
						//1. 구매시에는...
						// SSUtil.getRandSerial() 호출해서 달리 보내면 구매동작을 합니다.
						// 동일한 씨리어을 보내시면 구매되어 있으면 재구매 안하고...
						// 안되어 있으면 구매한다.
						//2. 동일 제품을 구매 할 경우.
						// > 다른 씨리얼을 보내야한다. 안그러면 구매 안해줌...
					}


					break;
				case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_GIFTGAIN > error > 아이디를 확인해라.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_SESSION_ID_EXPIRE_LOGOUT:		
					Debug.LogError (" >>> 강제 로그 아웃 처리 해주세요(구현우 이것 삭제)");
					#if NET_DEBUG_MODE
					Debug.Log("PTS_GIFTGAIN > error > 세션이 만기 강제로 로그아웃 처리 해야합니다..");	
					#endif
					break;
				case Protocol.RESULT_ERROR_GIFTITEM_NOT_FOUND:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_GIFTGAIN > error > 선물아이템 존재자체를 안함.");
					#endif
					break;
				case Protocol.RESULT_ERROR_GIFTITEM_ALREADY_GAIN:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_GIFTGAIN > error > 지급 및 삭제되었습니다.");
					#endif
					break;
				case Protocol.RESULT_ERROR_NOT_SUPPORT_MODE:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_GIFTGAIN > error > 지원하지 않는 모드값입니다.");
					#endif
					break;
				default:	
					#if NET_DEBUG_MODE
					Debug.Log("PTS_GIFTGAIN > error > not found error");
					#endif
					break;
				}
			}
			break;
			//@@@@ 2018-09-16 end
			//@@@@ 2018-09-15 start
		case Protocol.PTS_USERPARAM:
			{
				#if NET_DEBUG_MODE	
				Debug.Log("[C <- S] PTS_USERPARAM _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);			
				#endif

				switch(_resultcode){
				case Protocol.RESULT_SUCCESS:
					#if NET_DEBUG_MODE
					Debug.Log(" > 서버시간 > 성공.");				
					#endif

					//저장한 정보을 읽어서 보내준다.
					_parser.getInt("param0");
					_parser.getInt("param1");
					_parser.getInt("param2");
					_parser.getInt("param3");
					_parser.getInt("param4");
					_parser.getInt("param5");
					_parser.getInt("param6");
					_parser.getInt("param7");
					_parser.getInt("param8");
					_parser.getInt("param9");	

					break;
				default:
					#if NET_DEBUG_MODE
					Debug.Log(" > 서버시간 실패. > 팝업처리.");
					#endif
					break;				
				}
			}
			break;
			//@@@@ 2018-09-15 end
			//@@@@ 0018 start 
		case Protocol.PTS_SGREADY:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C <- S] PTS_SGREADY _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
				#endif

				switch(_resultcode){
				case Protocol.RESULT_SUCCESS:
					#if NET_DEBUG_MODE
					Debug.Log(" > 게임을 할려고 들어왔다.");
					#endif
					//************************************
					//이시간을 토대로 시간을 계산한다.
					// > 가장 중요한 부분입니다. 
					// > 별도로 시간 싱크는 계속 보내주면 별도로 맞추고 싶을 때를 위해 별도 프로 토콜을 사용할 수 있습니다.
					//************************************
					DateTime.Parse( _parser.getString("curdate") );	//2018-09-12 18:07:28.53

					//유저 개인정보...
					_parser.getInt("curturntime");		//현재 진행중인 회차.
					DateTime.Parse( _parser.getString("curturndate") );	//현재 진행중인 회차가 완료되는 시간.

					break;
				case Protocol.RESULT_ERROR_SERVER_CHECKING:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGREADY > error > 시스템 점검중입니다. > 게임 종료.");
					#endif
					break;
				case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGREADY > error > 아이디를 확인해라.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_BLOCK_USER:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGREADY > error > 블럭처리된 아이디입니다. > 게임 종료.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_SESSION_ID_EXPIRE_LOGOUT:		
					Debug.LogError (" >>> 강제 로그 아웃 처리 해주세요(구현우 이것 삭제)");
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGREADY > error > 세션이 만기 강제로 로그아웃 처리 해야합니다..");	
					#endif
					break;
				case Protocol.RESULT_ERROR_NOT_CALCULATE_LOTTO_WAIT_LOBBY:		
					Debug.LogError (" ERROR 결과를 계산중이여서 (로비에서 대기해서 잠시후에 들어와주세요.)");
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGREADY > error > 결과를 계산중이여서 (로비에서 대기해서 잠시후에 들어와주세요.)");	
					#endif
					break;
				case Protocol.RESULT_ERROR_ITEM_LACK:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGREADY > error > 아이템이 부족합니다.");
					#endif
					break;
				default:
					#if NET_DEBUG_MODE
					Debug.Log(" > 팝업처리.");
					#endif
					break;
				}
			}
			break;
			//@@@@ 0018 end

			//@@@@ 0019 start 
		case Protocol.PTS_SGBET:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C <- S] PTS_SGBET _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
				#endif

				switch(_resultcode){
				case Protocol.RESULT_SUCCESS:
					#if NET_DEBUG_MODE
					Debug.Log(" > 게임을 할려고 들어왔다.");
					#endif
					//************************************
					//이시간을 토대로 시간을 계산한다.
					// > 가장 중요한 부분입니다. 
					// > 별도로 시간 싱크는 계속 보내주면 별도로 맞추고 싶을 때를 위해 별도 프로 토콜을 사용할 수 있습니다.
					//************************************
					//@@@@ 0020 start 
					_parser.getInt("cashcost");
					_parser.getInt("gamecost");
					//@@@@ 0020 end

					DateTime.Parse( _parser.getString("curdate") );	//2018-09-12 18:07:28.53

					//유저 개인정보...
					_parser.getInt("curturntime");		//현재 진행중인 회차.
					DateTime.Parse( _parser.getString("curturndate") );	//현재 진행중인 회차가 완료되는 시간.

					//배팅해서 변경된 아이템정보만 다시 돌아옵니다.
					//소모템 -> 소모템에서 변경된것.
					//조각템 -> 배팅으로 변경된것.
					_parser.parsing ( "itemowner" );
					while (_parser.next ())
					{
						_parser.getInt("listidx");						//인벤에서의 인덱스이다. 
						_parser.getInt("invenkind");					//인벤의 종류...
																		//착용인벤 Protocol.USERITEM_INVENKIND_WEAR
																		//조각인벤 Protocol.USERITEM_INVENKIND_PIECE
																		//소비인벤 Protocol.USERITEM_INVENKIND_CONSUME
						_parser.getInt("itemcode");						//아이템 코드.
						_parser.getInt("cnt");							//수량.
						_parser.getInt("randserial");					//랜덤 시리얼을 만들어 두세요...
																		//1. 구매시에는...
																		// SSUtil.getRandSerial() 호출해서 달리 보내면 구매동작을 합니다.
																		// 동일한 씨리어을 보내시면 구매되어 있으면 재구매 안하고...
																		// 안되어 있으면 구매한다.
																		//2. 동일 제품을 구매 할 경우.
																		// > 다른 씨리얼을 보내야한다. 안그러면 구매 안해줌...
					}
					break;
				case Protocol.RESULT_ERROR_SERVER_CHECKING:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 시스템 점검중입니다. > 게임 종료.");
					#endif
					break;
				case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 아이디를 확인해라.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_BLOCK_USER:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 블럭처리된 아이디입니다. > 게임 종료.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_SESSION_ID_EXPIRE_LOGOUT:		
					Debug.LogError (" >>> 강제 로그 아웃 처리 해주세요(구현우 이것 삭제)");
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 세션이 만기 강제로 로그아웃 처리 해야합니다..");	
					#endif
					break;
				case Protocol.RESULT_ERROR_TURNTIME_WRONG:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 회차정보가 잘못되었다.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_NOT_BET_OVERTIME:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 오버타임이상에서는 배팅불가");	
					#endif
					break;
				case Protocol.RESULT_ERROR_NOT_BET_SAFETIME:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 세이프타임에서는 배팅불가");	
					#endif
					break;
				case Protocol.RESULT_ERROR_NOT_SUPPORT_MODE:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 지원하지 않는 모드입니다.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_PARAMETER:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 파라미터가 잘못되었습니다.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_ITEMCODE_GRADE_CHECK:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 아이템의 등급을 확인해주세요.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_MINUMUN_LACK:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 최소 수량보다 작습니다.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_GAMECOST_LACK:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 볼이 부족합니다.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_ITEM_LACK:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 아이템이 부족합니다.");
					#endif
					break;
				case Protocol.RESULT_ERROR_NOT_CALCULATE_LOTTO_WAIT_LOBBY:		
					Debug.LogError (" ERROR 결과를 계산중이여서 (로비에서 대기해서 잠시후에 들어와주세요.)");
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGBET > error > 결과를 계산중이여서 (로비에서 대기해서 잠시후에 들어와주세요.)");	
					#endif
					break;
				default:
					#if NET_DEBUG_MODE
					Debug.Log(" > 팝업처리.");
					#endif
					break;
				}
			}
			break;
			//@@@@ 0019 end

			//@@@@ 0021 start
		case Protocol.PTS_SGRESULT:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C <- S] PTS_SGRESULT _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
				#endif

				switch(_resultcode){
				case Protocol.RESULT_SUCCESS:
					#if NET_DEBUG_MODE
					Debug.Log(" > 게임을 할려고 들어왔다.");
					#endif
					//************************************
					//이시간을 토대로 시간을 계산한다.
					// > 가장 중요한 부분입니다.
					// > 별도로 시간 싱크는 계속 보내주면 별도로 맞추고 싶을 때를 위해 별도 프로 토콜을 사용할 수 있습니다.
					//************************************
					_parser.getInt("cashcost");
					_parser.getInt("gamecost");
					DateTime.Parse( _parser.getString("curdate") );	//2018-09-12 18:07:28.53

					//유저 개인정보...
					_parser.getInt("nextturntime");						//다음 진행중인 회차.
					DateTime.Parse( _parser.getString("nextturndate") );//다음 진행중인 회차가 완료되는 시간.



					//----------------------------------------------------
					//나눔로또에서 데이타.ok
					//----------------------------------------------------
					//	SELECT_1_NON						= -1,	//스트라이크, 볼 : 	선택안함(-1).
					//	SELECT_1_STRIKE						= 0,	//  				스트라이크(0).
					//	SELECT_1_BALL						= 1,	//     				볼(1).
					//	SELECT_2_NON						= -1,	//직구, 변화구 : 	선택안함(-1).
					//	SELECT_2_FAST						= 0,	//  				직구(0).
					//	SELECT_2_CURVE						= 1,	//     				변화구(1).
					//	SELECT_3_NON						= -1,	//좌, 우. 		: 	선택안함(-1).
					//	SELECT_3_LEFT						= 0,	//  				좌(0).
					//	SELECT_3_RIGHT						= 1,	//     				우(1).
					//	SELECT_4_NON						= -1,	//상, 하 		: 	선택안함(-1).
					//	SELECT_4_UP							= 0,	//  				상(0).
					//	SELECT_4_DOWN						= 1,	//     				하(1).
					_parser.getInt("ltselect1");
					_parser.getInt("ltselect2");
					_parser.getInt("ltselect3");
					_parser.getInt("ltselect4");


					//----------------------------------------------------
					//	//결과 플레그정보.
					//	RESULT_SELECT_NON					= -1,
					//	RESULT_SELECT_LOSE					=  0,
					//	RESULT_SELECT_WIN					=  1,
					//----------------------------------------------------
					_parser.getInt("rselect1");
					_parser.getInt("rselect2");
					_parser.getInt("rselect3");
					_parser.getInt("rselect4");


					//----------------------------------------------------
					// 성공하면 획득 수량...
					//----------------------------------------------------
					_parser.getInt("rcnt1");
					_parser.getInt("rcnt2");
					_parser.getInt("rcnt3");
					_parser.getInt("rcnt4");

					//----------------------------------------------------
					//	//배팅결과.
					//	GAME_RESULT_ING						= -1,
					//	GAME_RESULT_OUT						= 0,
					//	GAME_RESULT_ONEHIT					= 1,
					//	GAME_RESULT_TWOHIT					= 2,
					//	GAME_RESULT_THREEHIT				= 3,
					//	GAME_RESULT_HOMERUN					= 4,
					//----------------------------------------------------
					_parser.getInt("gameresult");

					//-----------------------------------------------------
					//레벨업으로 박스가 선물된다.(우편함 -> 선물, 메세지).
					//GameData.ReadGiftItem ( parser , _xml , "giftitem" );
					//_parser.parsing ( "giftitem" );
					//로그인하고 동일합니다. (전체를 보내드립니다.)
					//-----------------------------------------------------
					_parser.parsing ( "giftitem" );
					while (_parser.next ())
					{
						_parser.getInt("idx");				//선물 인덱스 번호.
						_parser.getInt("giftkind");			//선물의 종류. (아이템선물, 메세지).
						_parser.getString("message");		//  메세지 일경우 메세지 내용.
						_parser.getInt("itemcode");			//  아이템 선물일 경우 아이템 코드.
						_parser.getInt("cnt");				//            수량.
						_parser.getString("giftdate");		//보낸날짜.
						_parser.getString("giftid");		//보낸이.
					}

					break;
				case Protocol.RESULT_ERROR_SERVER_CHECKING:
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGRESULT > error > 시스템 점검중입니다. > 게임 종료.");
					#endif
					break;
				case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGRESULT > error > 아이디를 확인해라.");
					#endif
					break;
				case Protocol.RESULT_ERROR_BLOCK_USER:
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGRESULT > error > 블럭처리된 아이디입니다. > 게임 종료.");
					#endif
					break;
				case Protocol.RESULT_ERROR_SESSION_ID_EXPIRE_LOGOUT:
					Debug.LogError (" >>> 강제 로그 아웃 처리 해주세요(구현우 이것 삭제)");
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGRESULT > error > 세션이 만기 강제로 로그아웃 처리 해야합니다..");
					#endif
					break;
				case Protocol.RESULT_ERROR_PARAMETER:
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGRESULT > error > 파라미터가 잘못되었습니다.");
					#endif
					break;
				case Protocol.RESULT_ERROR_NOT_CALCULATE_LOTTO_LOGOUT:
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGRESULT > error > 로또데이타가 안들어왔음(10분이 경과해도 그래서 강제로 로그아웃).");
					#endif
					break;
				case Protocol.RESULT_ERROR_NOT_INPUT_SUPERBALL_5TRY:
					#if NET_DEBUG_MODE
					Debug.Log("PTS_SGRESULT > error > 아직 로또 데이타가 안들어옴(5초 후에 다시 요청해주세요).");
					#endif
					break;
				default:
					#if NET_DEBUG_MODE
					Debug.Log(" > 팝업처리.");
					#endif
					break;
				}
			}
			break;
			//@@@@ 0021 end

			//@@@@ 0017 start 
		case Protocol.PTS_SYSINQUIRE:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C <- S] PTS_SYSINQUIRE _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
				#endif

				switch(_resultcode){
				case Protocol.RESULT_SUCCESS:
					#if NET_DEBUG_MODE
					Debug.Log(" > 게임 문의를 등록했습니다.");
					#endif
					break;
				default:
					#if NET_DEBUG_MODE
					Debug.Log(" > 팝업처리.");
					#endif
					break;
				}
			}
			break;
			//@@@@ 0017 end

			//@@@@ 0022 start 
		case Protocol.PTS_KCHECKNN:
			{
				#if NET_DEBUG_MODE
				Debug.Log("[C <- S] PTS_KCHECKNN _resultcode:" + _resultcode + " _msg:" + _msg + "\n" + _xml);
				#endif

				switch(_resultcode){
				case Protocol.RESULT_SUCCESS:
					#if NET_DEBUG_MODE
					Debug.Log(" > 게임을 할려고 들어왔다.");
					#endif
					//************************************
					//이시간을 토대로 시간을 계산한다.
					// > 가장 중요한 부분입니다. 
					// > 별도로 시간 싱크는 계속 보내주면 별도로 맞추고 싶을 때를 위해 별도 프로 토콜을 사용할 수 있습니다.
					//************************************
					_parser.getInt("cashcost");
					_parser.getInt("gamecost");

					break;
				case Protocol.RESULT_ERROR_NOT_FOUND_GAMEID:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_KCHECKNN > error > 아이디를 확인해라.");	
					#endif
					break;
				case Protocol.RESULT_ERROR_SESSION_ID_EXPIRE_LOGOUT:		
					Debug.LogError (" >>> 강제 로그 아웃 처리 해주세요(구현우 이것 삭제)");
					#if NET_DEBUG_MODE
					Debug.Log("PTS_KCHECKNN > error > 세션이 만기 강제로 로그아웃 처리 해야합니다..");	
					#endif
					break;
				case Protocol.RESULT_ERROR_CANNOT_USED_NICKNAME:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_KCHECKNN > error > 닉네임을 누가 사용하고 있습니다.(popup)");
					#endif
					break;
				case Protocol.RESULT_ERROR_CASHCOST_LACK:		
					#if NET_DEBUG_MODE
					Debug.Log("PTS_KCHECKNN > error > 캐쉬(다이아)가 부족합니다.(popup).");
					#endif
					break;
				default:
					#if NET_DEBUG_MODE
					Debug.Log(" > 팝업처리.");
					#endif
					break;
				}
			}
			break;
			//@@@@ 0022 end
		default:
			Debug.LogError("[error]:[C -> S] not define code\n" + _xml);
			break;
		}

		return _resultcode;
	}

	[HideInInspector] public int debug 			= 0;
	[HideInInspector] public float debugDelay 	= 0f;
	[HideInInspector] public int debugErrCode 	= 0;

	public IEnumerator Handle(WWW _www, VOID_FUN_INTINT _onResult )
	{
		if ( debug > 0 )
		{
			Debug.Log("test fail net("+debug+")");
			
			debug--;

			yield return new WaitForSeconds(debugDelay);

			if ( _onResult != null ) {
				_onResult ( Protocol.CONNECT_STATE_SUCCESS , debugErrCode );
			}

			StartCoroutine ( DealyKill ( _www ) );
		}
		else 
		{
			float _timeOut = Time.realtimeSinceStartup + Protocol.LIMIT_CONNECT_TIME;

			while( !_www.isDone && Time.realtimeSinceStartup < _timeOut && string.IsNullOrEmpty( _www.error ) ){
				nConnectState = Protocol.CONNECT_STATE_WAIT;	
				yield return 0;
			}

			if( string.IsNullOrEmpty( _www.error ) && _www.isDone)
			{
				nConnectState = Protocol.CONNECT_STATE_SUCCESS;
				int _detail = parseCode ( _www.text.Trim() );

				if ( _onResult != null ) {
					_onResult ( Protocol.CONNECT_STATE_SUCCESS , _detail );
				}

				_www.Dispose();
			}
			else if(Time.realtimeSinceStartup >= _timeOut)
			{
				nConnectState = Protocol.CONNECT_STATE_TIMEOVER;
				if ( _onResult != null ) {
					_onResult ( Protocol.CONNECT_STATE_FAIL , Protocol.CONNECT_STATE_FAIL );
				}

				StartCoroutine ( DealyKill ( _www ) );
			}
			else 
			{
				nConnectState = Protocol.CONNECT_STATE_FAIL;
				Debug.Log("err connect");

				if ( _onResult != null ) {
					_onResult ( Protocol.CONNECT_STATE_FAIL , Protocol.CONNECT_STATE_FAIL );
				}

				StartCoroutine ( DealyKill ( _www ) );
			}
		}
	}

	private IEnumerator DealyKill ( WWW _www )
	{
		while ( _www.isDone == false  ) 
		{
			yield return null;
		}
		
		_www.Dispose ();
	}

	private const string KEY_ID = "laDjeijfsS";
	private const string KEY_PW = "v209Z78as34S";
	public static void SaveIdPwToLocalDB( string _id, string _pw )
	{
		PlayerPrefs.SetString(KEY_ID, _id);
		PlayerPrefs.SetString(KEY_PW, _pw);
		PlayerPrefs.Save();
	}
	public static void ClearIdPw()
	{
		PlayerPrefs.SetString(KEY_ID, Constant.NULL_STRING);
		PlayerPrefs.SetString(KEY_PW, Constant.NULL_STRING);
		PlayerPrefs.Save();
	}
}
































