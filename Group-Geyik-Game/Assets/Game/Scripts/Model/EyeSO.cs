using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Model/Eye")]
public class EyeSO : ScriptableObject
{
    public Color color; // göz rengi
    public string colorHex; // göz rengi
    public Sprite sprite;   // UI ekraný için 2d resmi
}
