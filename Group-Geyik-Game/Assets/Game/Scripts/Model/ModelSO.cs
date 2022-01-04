using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Model/FullModel", order = -1)]
public class ModelSO : ScriptableObject
{
    public BodySO body; //kýz, erkek
    public HairSO hair;
    public DressSO dress;
    public EyeSO eye;
    public LipsSO lips;
}
