using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskListUI : MonoBehaviour
{
    [SerializeField] private List<Transform> taskTransformList;

    private void Awake()
    {
        GetRecipes();
    }
    private void GetRecipes()
    {
        taskTransformList[0].GetComponent<TextMeshProUGUI>().SetText("1)" + RecipeManager.Instance.GetRecipedHair().GetRecipeText());
        taskTransformList[1].GetComponent<TextMeshProUGUI>().SetText("2)" + RecipeManager.Instance.GetRecipedEye().GetRecipeText());
        taskTransformList[2].GetComponent<TextMeshProUGUI>().SetText("3)" + RecipeManager.Instance.GetRecipedDress().GetRecipeText());
    }



}
