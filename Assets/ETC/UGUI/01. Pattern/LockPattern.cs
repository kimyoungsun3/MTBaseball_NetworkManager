using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UGUIPattern{
	public class LockPattern : MonoBehaviour {
		public GameObject prefabTest;
		public GameObject prefabCircle;
		public int count = 9;
		public Dictionary<int, Circle> dicCircle = new Dictionary<int, Circle>();
		bool unLocking = false;

		public GameObject prefabLine;
		public Canvas canvas;
		public List<Circle> listLine = new List<Circle> ();

		private GameObject lineOnEdit;
		private RectTransform lineOnEditRcts;
		private Circle circleOnEdit;

		// Use this for initialization
		void Start () {
			DestroyImmediate (prefabTest);
			GameObject _go;
			Circle _circle;
			EventTrigger _trigger;
			for (int i = 0; i < count; i++) {
				_go = Instantiate (prefabCircle, transform);
				_circle = _go.GetComponent<Circle> ();
				_circle.id = i;
				_circle.name += i.ToString ();

				_trigger = _go.GetComponent<EventTrigger> ();
				AddListener( _trigger, EventTriggerType.PointerEnter, OnMouseEnterCircle);
				AddListener( _trigger, EventTriggerType.PointerExit, OnMouseExitCircle);
				AddListener( _trigger, EventTriggerType.PointerDown, OnMouseDownCircle);
				AddListener( _trigger, EventTriggerType.PointerUp, OnMouseUpCircle);

				dicCircle.Add (_circle.id, _circle);
			}			
		}

		public void OnMouseEnterCircle(PointerEventData _data){
			//Debug.Log ("OnMouseEnterCircle:" + _data);
			//Circle _c = _data.pointerEnter.GetComponent<Circle>();

			if (unLocking && _data.pointerEnter != null) {
				//라인 만들고 회전...
				GameObject _newCircleGO = _data.pointerEnter;
				Circle _c = _newCircleGO.GetComponent<Circle> ();
				lineOnEditRcts.sizeDelta = new Vector2(
					lineOnEditRcts.sizeDelta.x, 
					//Vector3.Distance(circleOnEdit.transform.localPosition, _newCircleGO.transform.localPosition)
					Vector3.Distance(lineOnEdit.transform.localPosition, _newCircleGO.transform.localPosition)
				);

				lineOnEditRcts.localRotation = Quaternion.FromToRotation(
					Vector3.up,
					//(_newCircleGO.transform.localPosition - circleOnEdit.transform.localPosition)
					(_newCircleGO.transform.localPosition - lineOnEdit.transform.localPosition)
				);

				//신규 라인 생성...
				CreateLine (_c.transform.localPosition, _c.id);
			}
		}

		public void OnMouseExitCircle(PointerEventData _data){
			//Debug.Log ("OnMouseExitCircle:" + _data);
			Circle _c = _data.pointerEnter.GetComponent<Circle>();
		}

		public void OnMouseDownCircle(PointerEventData _data){
			//Debug.Log ("OnMouseDownCircle:" + _data);
			if (_data.pointerEnter != null) {
				Circle _c = _data.pointerEnter.GetComponent<Circle> ();
				unLocking = true;

				CreateLine (_c.transform.localPosition, _c.id);
			}
		}

		void CreateLine(Vector3 _localPos, int _id){
			GameObject _go = null;
			//라인이 존재하는가?
			if (TrySetLineEdit (_id)) {
				return;
			}

			//라인이 없어서 생성해준다.
			_go = Instantiate (prefabLine, canvas.transform);
			_go.transform.localPosition = _localPos;
			Circle _c = _go.GetComponent<Circle> ();
			_c.id = _id;

			//관리요 리스트에 넣어주기...
			listLine.Add (_c);

			//마지막에 생성된것...
			lineOnEdit = _go;
			lineOnEditRcts = _go.GetComponent<RectTransform> ();
			circleOnEdit = _c;
		}

		bool TrySetLineEdit(int _id){
			bool _bFind = false;
			foreach (Circle _c in listLine) {
				if (_c.id == _id) {
					_bFind = true;
					break;
				}
			}
			return _bFind;
		}

		public void OnMouseUpCircle(PointerEventData _data){
			//Debug.Log ("OnMouseUpCircle:" + _data);
			//Circle _c = _data.pointerEnter.GetComponent<Circle>();

			if (listLine.Count > 0) {
				if (unLocking) {
					//원 페이드.
					foreach (Circle _c in listLine) {
						EnableColorFade(dicCircle[_c.id].gameObject.GetComponent<Animator>());
					}

					Destroy (listLine[listLine.Count - 1].gameObject);
					listLine.RemoveAt (listLine.Count - 1);

					//라인 페이디...
					foreach (Circle _c in listLine) {
						EnableColorFade (_c.GetComponent<Animator> ());
					}

					StartCoroutine (CoRelease ());

					//마지막 링크 클리어...
					lineOnEdit 		= null;
					lineOnEditRcts 	= null;
					circleOnEdit 	= null;
					//bAnimation 		= false;
				}
			}

			unLocking = false;
		}

		IEnumerator CoRelease(){
			yield return new WaitForSeconds (1f);

			//오브젝트 제거, 리스트 클리어...
			foreach (Circle _c in listLine) {
				Destroy(_c.gameObject);
			}

			listLine.Clear ();

		}

		void EnableColorFade(Animator _animator){
			_animator.enabled = true;
			_animator.Rebind ();
		}

		Vector2 sizeDelta;
		bool bAnimation;
		void Update(){
			if (bAnimation) {
				return;
			}

			if (unLocking) {
				Vector3 _mousePos = canvas.transform.InverseTransformPoint (Input.mousePosition);
				//Debug.Log (Input.mousePosition + " > " + _mousePos);
				//Debug.Log (circleOnEdit.transform.position + " > " + circleOnEdit.transform.localPosition);

				sizeDelta.Set(
					lineOnEditRcts.sizeDelta.x, 
					Vector3.Distance(_mousePos, circleOnEdit.transform.localPosition)
				);
				lineOnEditRcts.sizeDelta = sizeDelta;

				lineOnEditRcts.rotation = Quaternion.FromToRotation (Vector3.up, _mousePos - circleOnEdit.transform.localPosition);

			}
		}

		public static void AddListener( EventTrigger _trigger, EventTriggerType _type, System.Action<PointerEventData> _on )
		{
			//EventTrigger trigger = _go.GetComponent<EventTrigger>();
			EventTrigger.Entry _entry = new EventTrigger.Entry();
			_entry.eventID = _type;
			_entry.callback.AddListener ((data) => { _on((PointerEventData)data); });
			_trigger.triggers.Add(_entry);
			//EventTrigger trigger = _go.GetComponent<EventTrigger>();
			//EventTrigger.Entry entry = new EventTrigger.Entry();
			//entry.eventID = EventTriggerType.PointerDown;
			//entry.callback.AddListener((data) => { OnMouseUpCircle((PointerEventData)data); });
			//trigger.triggers.Add(entry);
		}
	}
}
