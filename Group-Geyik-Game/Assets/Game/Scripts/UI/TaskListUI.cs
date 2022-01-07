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
    [SerializeField] private List<Transform> xMarkImageList;
    [SerializeField] private List<Transform> questionMarkList;

    private Dictionary<int, Sprite> imageDic;
    private Dictionary<int, string> colorDic;

    private List<int> tempList;
    private Dictionary<int, bool> tempQuestionMarkDic;

    private const int maxDifferentPartType = 5; // lips, body, hair, eye, dress

    private int maxTaskCount;

    private void Awake()
    {
        Instance = this;

        imageDic = new Dictionary<int, Sprite>();
        colorDic = new Dictionary<int, string>();
        tempList = new List<int>();
        tempQuestionMarkDic = new Dictionary<int, bool>();

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
        foreach (Transform tra in xMarkImageList)
        {
            tra.GetComponent<Image>().gameObject.SetActive(false);
        }

        tempQuestionMarkDic.Clear();
        for (int i = 0; i < questionMarkList.Count; i++)
        {
            bool haveQuestion = UnityEngine.Random.Range(0, 11) > 8;
            tempQuestionMarkDic[i] = haveQuestion;

            if (haveQuestion)
            {
                questionMarkList[i].GetComponent<Image>().gameObject.SetActive(true);
            }
            else
            {
                questionMarkList[i].GetComponent<Image>().gameObject.SetActive(false);
            }
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
    }
    public int GetTempList(int index)
    {
        return tempList[index];
    }
    public bool CheckHaveQuestionMark(int index) //0-1-2 gelir. Question'ý varsa true döndürür
    {
        return tempQuestionMarkDic[index];
    }
    public void SetActiveTick(int index)
    {
        tickImageList[index].gameObject.SetActive(true);
    }
    public void SetActiveXMark(int index)
    {
        xMarkImageList[index].gameObject.SetActive(true);
    }
    public Dictionary<int,string> GetTrueColorDictionary()
    {
        return colorDic;
    }

}
