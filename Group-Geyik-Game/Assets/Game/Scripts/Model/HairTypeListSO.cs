using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/List/HairTypeList")]
public class HairTypeListSO : ScriptableObject
{
    [SerializeField] private List<HairSO> hairTypeList;
}
