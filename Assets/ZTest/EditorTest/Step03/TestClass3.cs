using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using UnityEngine;


public class TestClass3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(JsonUtility.ToJson(new Example(), true));	

		var serializedList = new SerializableList<Example> {
			new Example (),
			new Example ()
		};

		Debug.Log(JsonUtility.ToJson(serializedList));	
		Debug.Log(serializedList.ToJson());	
	}

	[System.Serializable]
	public class Example{
		[SerializeField] string name = "hoge";
		[SerializeField] int number = 10;
	}

	public static string ToJson(string key, UnityEngine.Object[] objs){
		//var json = objs.Select (obj => EditorJsonUtility.ToJson (obj)).ToArray ();
		//var values = string.Join (",", json);
		//return string.Format ("{\"{0}\":{1}]}", key, values);
		return "";
	}
}
