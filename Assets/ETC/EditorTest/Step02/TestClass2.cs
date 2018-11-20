using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
//[RequireComponent(typeof(Animator))]
[DisallowMultipleComponent]
[AddComponentMenu("MyUUI/Tween Color")]
public class TestClass2 : MonoBehaviour {
	//--------------------------------
	[Range(0, 10)] public int num1;
	[Range(0, 10)] public float num2;
	[Range(0, 10)] public long num3;
	[Range(0, 10)] public double num4;

	//--------------------------------
	[Space]
	[Multiline(5)] public string multiline;
	[TextArea(3, 5)] public string textarea;

	//--------------------------------
	[Space(40)]
	[Header("아 변수에 오른 마우스 올려서 Random,Reset")]
	[ContextMenuItem("Random", "RandomNumber")]
	[ContextMenuItem("Reset", "ResetNumber")]
	[Tooltip("마우스 올리고 오른쪽 클릭")]
	public int number;
	void RandomNumber(){
		number = Random.Range (0, 10);
		//Debug.Log ("Call RandomNumber");
	}

	void ResetNumber(){
		number = 0;
	}

	[ContextMenu("RandomNumber2")]
	void RandomNumber2(){
		number = Random.Range (0, 10);
		//Debug.Log ("Call RandomNumber");
	}


	//--------------------------------
	[Space]
	public Color color;
	[ColorUsage(false)] public Color color2;
	[ColorUsage(true, true, 0, 8, 0.125f, 3)]public Color Color3;


	//--------------------------------
	[HideInInspector] public string str;


}
