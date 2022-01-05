using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator inGameUI;

    [Button]
    private void DeactivateInGameUI()
    {
        inGameUI.SetBool(StringData.ISACTIVE, false);
    }

    [Button]
    private void ActivateInGameUI()
    {
        inGameUI.SetBool(StringData.ISACTIVE, true);
    }

}
