using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUI : MonoBehaviour
{
    [SerializeField] private Transform inGameUI;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            inGameUI.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
