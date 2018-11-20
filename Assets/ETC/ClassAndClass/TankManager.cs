using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassAndClass{
	[System.Serializable]
	public class TankManager {
		public Color color;
		public Transform spawnPoint;

		[HideInInspector] public Transform tankTrans;

		public void SetTank(Transform _tankTrans){			
			tankTrans = _tankTrans;

			MeshRenderer[] _meshs = tankTrans.GetComponentsInChildren<MeshRenderer> ();
			for (int i = 0, iMax = _meshs.Length; i < iMax; i++) {
				_meshs [i].material.color = color;
			}
		}

		public void ResetPosition(){
			tankTrans.position = spawnPoint.position;
			tankTrans.rotation = spawnPoint.rotation;
		}
	}
}
