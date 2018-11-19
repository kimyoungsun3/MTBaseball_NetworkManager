using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace EditorStep01{
	public class TestClass : MonoBehaviour {

		void Start(){

		}

		/*
		 * can't not run
		[MenuItem("Examples/Load Editor Texture Example")]
		static void loadExample()
		{
			Texture tex  = (Texture)EditorGUIUtility.Load("aboutwindow");
			Debug.Log (tex);
			Debug.Log("Got: " + tex.name + " !");

			Renderer r = GameObject.Find("Cube").GetComponent<Renderer>();
			r.sharedMaterial.mainTexture = tex;
		}
		*/
	}
}
