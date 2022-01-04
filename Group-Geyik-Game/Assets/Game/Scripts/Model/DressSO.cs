using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Model/Dress")]
public class DressSO : ScriptableObject
{
    public GameObject dressModel; // giysi tipi
    public Sprite sprite; // UI ekraný için 2d resmi
    
    public Color color;
    public string colorHex; 
    public string colorName;
    public string GetRecipeText()
    {
        return $" <color=#{colorHex}>{colorName}</color> Dress";
    }

}
