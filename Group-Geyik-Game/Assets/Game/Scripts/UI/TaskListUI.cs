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

    //[SerializeField] private List<Transform> taskTransformList;
    [SerializeField] private List<Transform> imagePartList;

    //private Dictionary<int, string> stringDic; //rastgele gelen partlarýn yazýlarýný tutmak için
    private Dictionary<int, Sprite> imageDic;
    private Dictionary<int, string> colorDic;
    private List<int> dicIndexes;

    private const int maxDifferentPartType = 5; // lips, body, hair, eye, dress

    private int maxTaskCount;

    private void Awake()
    {
        //stringDic = new Dictionary<int, string>();
        imageDic = new Dictionary<int, Sprite>();
        colorDic = new Dictionary<int, string>();
        dicIndexes = new List<int>();

        maxTaskCount = imagePartList.Count;
        SetDictionary();
        GetRandomRecipes();
    }
    private void SetDictionary()
    {
        //stringDic.Clear();
        imageDic.Clear();
        colorDic.Clear();
        dicIndexes.Clear();

        //stringDic[0] = RecipeManager.Instance.GetRecipedHair().GetRecipeText();
        //stringDic[1] = RecipeManager.Instance.GetRecipedEye().GetRecipeText();
        //stringDic[2] = RecipeManager.Instance.GetRecipedDress().GetRecipeText();
        //stringDic[3] = RecipeManager.Instance.GetRecipedBody().GetRecipeText();
        //stringDic[4] = RecipeManager.Instance.GetRecipedLips().GetRecipeText();

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
        List<int> tempList = new List<int>();
        foreach (Transform transform in imagePartList)
        {
            bool isAllTaskSlotsFilled = maxTaskCount == tempList.Count;
            while (!isAllTaskSlotsFilled)
            {
                int randomIndex = UnityEngine.Random.Range(0, maxDifferentPartType); //0, 1, 2, 3, 4

                if (!tempList.Contains(randomIndex))
                {
                    tempList.Add(randomIndex);
                    dicIndexes.Add(randomIndex);
                    //taskTransformList[tempList.Count - 1].GetComponent<TextMeshProUGUI>().SetText(tempList.Count.ToString() + ")" + stringDic[randomIndex]);

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
        ItemSelectUI.Instance.SetTaskParts(tempList);
        tempList.Clear();
    }



}
