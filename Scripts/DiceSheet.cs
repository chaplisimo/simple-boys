using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dice", menuName = "New Dice", order = 1)]
public class DiceSheet : ScriptableObject {

	public PhysicMaterial physicMaterial;
	
}

/*public class MakeScriptableObject {
    [MenuItem("Assets/Create/New Dice")]
    public static void CreateMyAsset()
    {
        DiceSheet asset = ScriptableObject.CreateInstance<DiceSheet>();

        AssetDatabase.CreateAsset(asset, "Assets/New Dice.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}*/
