using UnityEngine;
using UnityEditor;

static class CountryUnityIntegration {

	[MenuItem("Assets/Create/CountryAsset")]
	public static void CreateYourScriptableObject() {
		ScriptableObjectUtility2.CreateAsset<CountryAsset>();
	}

}
