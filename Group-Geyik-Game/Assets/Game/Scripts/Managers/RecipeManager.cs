using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void CreateRecipe()
    {

    }


}
