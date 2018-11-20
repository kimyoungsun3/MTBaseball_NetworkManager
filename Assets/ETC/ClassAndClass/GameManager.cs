using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassAndClass{
	public class GameManager : MonoBehaviour {
		public GameObject prefabTank;
		public float readyTime = 2f;
		public float endTime = 2f;
		public List<TankManager> tankList = new List<TankManager> ();


		IEnumerator Start () {
			yield return StartCoroutine (CoReady());			
			yield return StartCoroutine (CoGaming());			
			yield return StartCoroutine (CoEnding());			
		}

		IEnumerator CoReady(){
			Debug.Log ("Ready");
			Transform _t;
			TankManager _tm;
			for (int i = 0; i < tankList.Count; i++) {
				_tm = tankList [i];
				_t = Instantiate (prefabTank, _tm.spawnPoint.position, _tm.spawnPoint.rotation).transform;
				_tm.SetTank (_t);
			}
			yield return new WaitForSeconds (readyTime);
		}

		IEnumerator CoGaming(){
			Debug.Log ("Gaming");
			while (CheckAliveTank () > 1) {
				yield return null;
			}
		}

		int CheckAliveTank(){
			int _aliveCount = 0;
			for (int i = 0; i < tankList.Count; i++) {
				if (tankList [i].tankTrans.gameObject.activeSelf) {
					_aliveCount++;
				}
			}
			return _aliveCount;
		}

		IEnumerator CoEnding(){
			Debug.Log ("End");
			yield return new WaitForSeconds (readyTime);
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}

