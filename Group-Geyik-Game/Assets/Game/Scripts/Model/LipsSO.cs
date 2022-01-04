using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Model/Lips")]
public class LipsSO : ScriptableObject
{
    public Color color; //dudak rengi
    public string colorHex;
    public string colorName;

    public string GetRecipeText()
    {
        return $" <color=#{colorHex}>{colorName}</color> Lips";
    }
}
