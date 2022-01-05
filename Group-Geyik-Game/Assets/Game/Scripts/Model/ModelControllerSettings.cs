using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Settings/ModelController")]
public class ModelControllerSettings : ScriptableObject
{
    [SerializeField] private float voiceVolume = 1f;

    public float VoiceVolume => voiceVolume;
}

