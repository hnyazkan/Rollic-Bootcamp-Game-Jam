using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;


public class ItemSelectUI : MonoBehaviour
{
    [SerializeField] private List<Transform> itemList;

    private HairTypeListSO hairTypeList;
    private EyeListSO eyeList;


    private void Awake()
    {
        //datalarýmýz
        hairTypeList = Resources.Load<HairTypeListSO>(typeof(HairTypeListSO).Name);
        eyeList = Resources.Load<EyeListSO>(typeof(EyeListSO).Name);

        GetHairs();

    }

    [Button]
    private void GetHairs()
    {
        int index = 0;
        foreach (Transform transform in itemList)
        {
            Image image = transform.Find(StringData.IMAGE).GetComponent<Image>();
            image.sprite = hairTypeList.list[index].sprite;
            image.color = UtilsClass.GetColorFromString(hairTypeList.list[index].colorHex);
            index++;
        }
    }

    [Button]
    private void GetEyes()
    {
        int index = 0;
        foreach (Transform transform in itemList)
        {
            Image image = transform.Find(StringData.IMAGE).GetComponent<Image>();
            image.sprite = eyeList.list[index].sprite;
            image.color = UtilsClass.GetColorFromString(eyeList.list[index].colorHex);
            index++;
        }
    }
}
