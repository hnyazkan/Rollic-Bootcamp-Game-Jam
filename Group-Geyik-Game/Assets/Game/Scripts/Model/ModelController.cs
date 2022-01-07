using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class ModelController : MonoBehaviour
{
    [SerializeField] private ItemSelectUI itemSelectUI;

    [SerializeField] private Transform[] dress, eye, lip, body, hair;

    private int dressIndex, eyeIndex, lipIndex, bodyIndex, hairIndex;

    private void Start()
    {
        InitObserver();
        CreateNewCharacter();
    }

    private void InitObserver()
    {
        itemSelectUI.OnHairColorChanged += Ui_OnHairColorChanged;
        itemSelectUI.OnBodyColorChanged += Ui_OnBodyColorChanged;
        itemSelectUI.OnDressColorChanged += Ui_OnDressColorChanged;
        itemSelectUI.OnLipColorChanged += Ui_OnLipColorChanged;
        itemSelectUI.OnEyeColorChanged += Ui_OnEyeColorChanged;
        itemSelectUI.OnThreeStagesCompleted += Ui_OnThreeStagesCompleted;
    }

    #region Observer
    private void Ui_OnEyeColorChanged(object sender, ItemSelectUI.OnEyeColorChangedEventArgs e)
    {
        ChangeColor(UtilsClass.GetColorFromString(e.str), eye[eyeIndex]);
    }

    private void Ui_OnLipColorChanged(object sender, ItemSelectUI.OnLipColorChangedEventArgs e)
    {
        ChangeColor(UtilsClass.GetColorFromString(e.str), lip[lipIndex]);
    }

    private void Ui_OnDressColorChanged(object sender, ItemSelectUI.OnDressColorChangedEventArgs e)
    {
        //ChangeMultipleColor(UtilsClass.GetColorFromString(e.str), dress[dressIndex]);
        ChangeColor(UtilsClass.GetColorFromString(e.str), dress[dressIndex]);
    }

    private void Ui_OnBodyColorChanged(object sender, ItemSelectUI.OnBodyColorChangedEventArgs e)
    {
        ChangeColor(UtilsClass.GetColorFromString(e.str), body[bodyIndex]);
    }

    private void Ui_OnHairColorChanged(object sender, ItemSelectUI.OnHairColorChangedEventArgs e)
    {
        //ChangeMultipleColor(UtilsClass.GetColorFromString(e.str), hair[hairIndex]);
        ChangeColor(UtilsClass.GetColorFromString(e.str), hair[hairIndex]);

    }
    private void Ui_OnThreeStagesCompleted(object sender, System.EventArgs e)
    {
        CreateNewCharacter();
    }
    #endregion

    [Button]
    private void CreateNewCharacter()
    {
        dressIndex = UnityEngine.Random.Range(0, dress.Length);
        CreateOnePart(dress, dressIndex);
        eyeIndex = UnityEngine.Random.Range(0, eye.Length);
        CreateOnePart(eye, eyeIndex);
        lipIndex = UnityEngine.Random.Range(0, lip.Length);
        CreateOnePart(lip, lipIndex);
        bodyIndex = UnityEngine.Random.Range(0, body.Length);
        CreateOnePart(body, bodyIndex);
        hairIndex = UnityEngine.Random.Range(0, hair.Length);
        CreateOnePart(hair, hairIndex);
    }

    private void CreateOnePart(Transform[] transformList, int index)
    {
        foreach (Transform transform in transformList)
        {
            transform.gameObject.SetActive(false);
        }
        transformList[index].transform.gameObject.SetActive(true);
    }
    private void ChangeColor(Color color, Transform part)
    {
        part.GetComponent<SkinnedMeshRenderer>().material.color = color;
    }
    private void ChangeMultipleColor(Color color, Transform part)
    {
        foreach (Transform transform in part)
        {
            transform.GetComponentInChildren<SkinnedMeshRenderer>().material.color = color;
        }
    }

}