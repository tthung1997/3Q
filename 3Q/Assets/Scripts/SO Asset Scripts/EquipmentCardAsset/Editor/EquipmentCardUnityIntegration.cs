using UnityEngine;
using UnityEditor;

static class EquipmentCardUnityIntegration 
{

	[MenuItem("Assets/Create/EquipmentCardAsset")]
	public static void CreateYourScriptableObject() {
		ScriptableObjectUtility2.CreateAsset<EquipmentCardAsset>();
	}

}
