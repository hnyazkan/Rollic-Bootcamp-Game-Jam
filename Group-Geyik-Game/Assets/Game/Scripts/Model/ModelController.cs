using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class ModelController : MonoBehaviour
{
    //public static ModelController Instance { get; private set; }

    public ItemSelectUI ui;

    [SerializeField] private List<Transform> hairList;
    [SerializeField] private Transform dress;
    [SerializeField] private Transform eye;
    [SerializeField] private Transform lip;
    [SerializeField] private Transform body;
    private void Awake()
    {
        //Instance = this;
    }
    private void Start()
    {
        ui.OnHairColorChanged += Ui_OnHairColorChanged;
        ui.OnBodyColorChanged += Ui_OnBodyColorChanged;
        ui.OnDressColorChanged += Ui_OnDressColorChanged;
        ui.OnLipColorChanged += Ui_OnLipColorChanged;
        ui.OnEyeColorChanged += Ui_OnEyeColorChanged;
    }

    private void Ui_OnEyeColorChanged(object sender, ItemSelectUI.OnEyeColorChangedEventArgs e)
    {
        ChangeEyesColor(UtilsClass.GetColorFromString(e.str));
    }

    private void Ui_OnLipColorChanged(object sender, ItemSelectUI.OnLipColorChangedEventArgs e)
    {
        ChangeLipColor(UtilsClass.GetColorFromString(e.str));
    }

    private void Ui_OnDressColorChanged(object sender, ItemSelectUI.OnDressColorChangedEventArgs e)
    {
        ChangeDressColor(UtilsClass.GetColorFromString(e.str));
    }

    private void Ui_OnBodyColorChanged(object sender, ItemSelectUI.OnBodyColorChangedEventArgs e)
    {
        ChangeBodyColor(UtilsClass.GetColorFromString(e.str));
    }

    private void Ui_OnHairColorChanged(object sender, ItemSelectUI.OnHairColorChangedEventArgs e)
    {
        ChangeHairColor(UtilsClass.GetColorFromString(e.str));
    }

    public void ChangeHairColor(Color color)
    {
        foreach (Transform transform in hairList)
        {
            transform.GetComponent<MeshRenderer>().material.color = color;
        }
    }
    public void ChangeDressColor(Color color)
    {
        dress.GetComponent<MeshRenderer>().material.color = color;
    }
    public void ChangeEyesColor(Color color)
    {
        eye.GetComponent<MeshRenderer>().material.color = color;
    }
    public void ChangeBodyColor(Color color)
    {
        body.GetComponent<MeshRenderer>().material.color = color;
    }
    public void ChangeLipColor(Color color)
    {
        lip.GetComponent<MeshRenderer>().material.color = color;
    }

}