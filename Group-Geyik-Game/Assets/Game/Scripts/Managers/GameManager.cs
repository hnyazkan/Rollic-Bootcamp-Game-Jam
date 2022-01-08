using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ItemSelectUI itemSelectUI;

    [SerializeField] private Transform maleModel;
    [SerializeField] private Transform femaleModel;

    [SerializeField] private Transform male2dImage;
    [SerializeField] private Transform female2dImage;

    private bool isMale = true;

    private void Awake()
    {
        maleModel.gameObject.SetActive(false);
        femaleModel.gameObject.SetActive(true);

        male2dImage.gameObject.SetActive(false);
        female2dImage.gameObject.SetActive(true);
    }
    private void Start()
    {
        itemSelectUI.OnThreeStagesCompleted += ÝtemSelectUI_OnThreeStagesCompleted;
    }

    private void ÝtemSelectUI_OnThreeStagesCompleted(object sender, System.EventArgs e)
    {
        isMale = !isMale;
        ChangeModel();
        Change2dImage();
    }
    private void ChangeModel()
    {
        if (isMale)
        {
            maleModel.gameObject.SetActive(false);
            femaleModel.gameObject.SetActive(true);
        }
        else
        {
            maleModel.gameObject.SetActive(true);
            femaleModel.gameObject.SetActive(false);
        }
    }
    private void Change2dImage()
    {
        bool i = UnityEngine.Random.Range(0, 2) < 1;

        if (i)
        {
            male2dImage.gameObject.SetActive(false);
            female2dImage.gameObject.SetActive(true);
        }
        else
        {
            male2dImage.gameObject.SetActive(true);
            female2dImage.gameObject.SetActive(false);
        }
    }

}
