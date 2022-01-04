using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/List/LipList")]
public class LipListSO : ScriptableObject
{
    public List<LipsSO> list;
}
