using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Model/FullModel", order = -1)]
public class ModelSO : ScriptableObject
{
    [SerializeField] BodySO body; //kýz, erkek
    [SerializeField] HairSO hair;
    [SerializeField] DressSO dress;
    [SerializeField] EyeSO eye;
    [SerializeField] LipsSO lips;
}
