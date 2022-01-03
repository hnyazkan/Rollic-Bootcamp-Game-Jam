using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Model/Body")]
public class BodySO : ScriptableObject
{
    [SerializeField] private GameObject bodyType; //kadýn, erkek, uzaylý
    [SerializeField] private Color color;  //ten rengi
}
