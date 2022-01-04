using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskListUI : MonoBehaviour
{
    [SerializeField] private List<Transform> taskTransformList;
    
    private Dictionary<int, string> stringDic; //partlarýn tamamen rastgele gelmesi için

    private const int maxDifferentPartType = 5; // lips, body, hair, eye, dress
    private const int maxTaskCount = 3;

    private void Awake()
    {
        stringDic = new Dictionary<int, string>();

        SetDictionary();
        GetRandomRecipes();
    }

    private void SetDictionary()
    {
        stringDic.Clear();

        stringDic[0] = RecipeManager.Instance.GetRecipedHair().GetRecipeText();
        stringDic[1] = RecipeManager.Instance.GetRecipedEye().GetRecipeText();
        stringDic[2] = RecipeManager.Instance.GetRecipedDress().GetRecipeText();
        stringDic[3] = RecipeManager.Instance.GetRecipedBody().GetRecipeText();
        stringDic[4] = RecipeManager.Instance.GetRecipedLips().GetRecipeText();
    }

    private void GetRandomRecipes()
    {
        List<int> tempList = new List<int>();
        foreach (Transform transform in taskTransformList)
        {
            bool isAllTaskSlotsFilled = maxTaskCount == tempList.Count;
            while (!isAllTaskSlotsFilled)
            {
                int randomIndex = UnityEngine.Random.Range(0, maxDifferentPartType);
                if (!tempList.Contains(randomIndex))
                {
                    tempList.Add(randomIndex);
                    taskTransformList[tempList.Count - 1].GetComponent<TextMeshProUGUI>().SetText(tempList.Count.ToString() + ")" + stringDic[randomIndex]);

                    isAllTaskSlotsFilled = true;
                }
            }
        }
        tempList.Clear();
    }



}
