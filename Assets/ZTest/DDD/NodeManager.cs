using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour {
	public enum Direction { None, Forward, Left };

	public float speed = 2f;
	public Transform nodePrefabForward;
	public Transform nodePrefabLeft;
	public List<Transform> list = new List<Transform> ();

	Transform nodeTrans;
	Direction nodeDir = Direction.Forward;
	Vector3 nodePos = Vector3.zero;

	void Start(){
		CreateNode ( Direction.None );
	}

	void CreateNode( Direction _dir ){
		Vector3 _pos = Vector3.zero;
		Quaternion _rot = Quaternion.identity;
		switch (_dir) {
		case Direction.None:
			nodeDir = Direction.Forward;
			_pos 	= Vector3.zero;
			_rot 	= Quaternion.identity;
			nodeTrans = Instantiate (nodePrefabForward, _pos, _rot);
			break;
		case Direction.Left:
			nodeDir = Direction.Forward;
			_pos 	= nodeTrans.position + nodeTrans.localScale + new Vector3(-.5f, -1f, -.5f);
			_rot 	= Quaternion.identity;
			nodeTrans = Instantiate (nodePrefabForward, _pos, _rot);
			break;
		case Direction.Forward:
			nodeDir = Direction.Left;
			_pos 	= nodeTrans.position + nodeTrans.localScale + new Vector3(-.5f, -1f, -.5f);
			_rot 	= Quaternion.identity;
			nodeTrans = Instantiate (nodePrefabLeft, _pos, _rot);
			break;
		}

		list.Add (nodeTrans);
	}

	void Update () {
		if( Input.GetKeyDown(KeyCode.C) ){
			CreateNode ( nodeDir );
		}else if ( nodeTrans != null ) {
			Vector3 _scale = nodeTrans.localScale;
			if (nodeDir == Direction.Forward) {
				_scale.z += Time.deltaTime * speed;
			} else {
				_scale.x += Time.deltaTime * speed;
			}
			nodeTrans.localScale = _scale;
		}
		//Debug.Log (nodeDir + ":" + nodeTrans.position);
	}
}
