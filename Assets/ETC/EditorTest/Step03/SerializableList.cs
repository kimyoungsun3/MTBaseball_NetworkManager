using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using UnityEngine;


[Serializable]
public class SerializableList<T> : Collection<T>, ISerializationCallbackReceiver
{
	[SerializeField]
	List<T> items;

	public void OnBeforeSerialize()
	{
		items = (List<T>)Items;
	}

	public void OnAfterDeserialize()
	{
		Clear();
		foreach (var item in items)
			Add(item);
	}

	public string ToJson()
	{
		var result = "[]";
		var json = JsonUtility.ToJson(this);
		var regex = new Regex("^{\"items\":(?<array>.*)}$");
		var match = regex.Match(json);
		if (match.Success)
			result = match.Groups["array"].Value;

		return result;
	}
}

