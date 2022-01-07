using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// Task'ler burada üretilir. Göz ve rengi üretildi diyelim. ItemUI'a bunun haberi gider ve ona göre slot üretir.
/// </summary>
public class TaskListUI : MonoBehaviour
{
    public static TaskListUI Instance { get; private set; }
    [SerializeField] private List<Transform> imagePartList;
    [SerializeField] private List<Transform> tickImageList;

    private Dictionary<int, Sprite> imageDic;
    private Dictionary<int, string> colorDic;

    List<int> tempList = new List<int>();

    private const int maxDifferentPartType = 5; // lips, body, hair, eye, dress

    private int maxTaskCount;

    private void Awake()
    {
        Instance = this;

        imageDic = new Dictionary<int, Sprite>();
        colorDic = new Dictionary<int, string>();

        maxTaskCount = imagePartList.Count;
        CreatRandomRecipe();
    }

    public void CreatRandomRecipe()
    {
        RecipeManager.Instance.CreateRandomRecipeParts();
        SetDictionaries();
        GetRandomRecipes();
    }

    private void SetDictionaries()
    {
        imageDic.Clear();
        colorDic.Clear();

        imageDic[0] = RecipeManager.Instance.GetRecipedHair().taskSprite;
        imageDic[1] = RecipeManager.Instance.GetRecipedEye().taskSprite;
        imageDic[2] = RecipeManager.Instance.GetRecipedDress().taskSprite;
        imageDic[3] = RecipeManager.Instance.GetRecipedBody().taskSprite;
        imageDic[4] = RecipeManager.Instance.GetRecipedLips().taskSprite;

        colorDic[0] = RecipeManager.Instance.GetRecipedHair().colorHex;
        colorDic[1] = RecipeManager.Instance.GetRecipedEye().colorHex;
        colorDic[2] = RecipeManager.Instance.GetRecipedDress().colorHex;
        colorDic[3] = RecipeManager.Instance.GetRecipedBody().colorHex;
        colorDic[4] = RecipeManager.Instance.GetRecipedLips().colorHex;
    }

    private void GetRandomRecipes()
    {
        foreach (Transform tra in tickImageList)
        {
            tra.GetComponent<Image>().gameObject.SetActive(false);
        }
        tempList.Clear();
        foreach (Transform transform in imagePartList)
        {
            bool isAllTaskSlotsFilled = maxTaskCount == tempList.Count;
            while (!isAllTaskSlotsFilled)
            {
                int randomIndex = UnityEngine.Random.Range(0, maxDifferentPartType); //0, 1, 2, 3, 4

                if (!tempList.Contains(randomIndex))
                {
                    tempList.Add(randomIndex);

                    //task bar sprite'lar setlenir
                    Image image = imagePartList[tempList.Count - 1].GetComponent<Image>();
                    image.sprite = imageDic[randomIndex];
                    image.SetNativeSize();

                    //sprite color kutucuklarý belirlenir
                    imagePartList[tempList.Count - 1].Find(StringData.IMAGECOLOR).GetComponent<Image>().color =
                        UtilsClass.GetColorFromString(colorDic[randomIndex]);

                    isAllTaskSlotsFilled = true;
                }
            }
        }
        //ItemSelectUI.Instance.SetTaskParts(tempList);

    }
    public int GetTempList(int index)
    {
        return tempList[index];
    }
    public void SetActiveTick(int index)
    {
        tickImageList[index].gameObject.SetActive(true);
    }

}
