using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance { get; private set; }

    [SerializeField] private Animator inGameUI;
    [SerializeField] private Animator model;

    private void Awake()
    {
        Instance = this;
    }

    [Button]
    public void ActivateInGameUI()
    {
        inGameUI.SetBool(StringData.ISACTIVE, true);
    }
    [Button]
    public void DeactivateInGameUI()
    {
        inGameUI.SetBool(StringData.ISACTIVE, false);
    }
    [Button]
    public void ActivateDanceFemale()
    {
        model.SetBool(StringData.ISDANCING, true);
    }
    [Button]
    public void DeactivateDanceFemale()
    {
        model.SetBool(StringData.ISDANCING, false);
    }

}
