using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/List/EyeList")]
public class EyeListSO : ScriptableObject
{
    public List<EyeSO> list;
}
