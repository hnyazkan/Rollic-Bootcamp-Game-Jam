using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;
using UnityEngine.UI;


public class WheelUI : MonoBehaviour
{
    [SerializeField] private List<Transform> wheelPartList;
    [SerializeField] private ItemSelectUI itemSelectUI;

    private Dictionary<int, string> trueColorDic;

    private HairTypeListSO hairList;
    private DressTypeListSO dressList;
    private BodyTypeListSO bodyList;
    private EyeListSO eyeList;
    private LipListSO lipList;

    private int taskPartOne, taskPartTwo, taskPartThree; //task manager'dan gelen saç mý göz mü onlar
    private int stage = 1;

    private void Awake()
    {
        trueColorDic = new Dictionary<int, string>();
    }
    private void Start()
    {
        itemSelectUI.OnThreeStagesCompleted += ÝtemSelectUI_OnThreeStagesCompleted;
        itemSelectUI.OnOnePartChanged += ÝtemSelectUI_OnOnePartChanged;

        SetTaskParts();
        GetWheelStage(taskPartOne);
    }

    private void ÝtemSelectUI_OnOnePartChanged(object sender, EventArgs e)
    {
        Debug.Log("cahnged");
        CheckStage();
    }

    private void ÝtemSelectUI_OnThreeStagesCompleted(object sender, EventArgs e)
    {
        Debug.Log("3cahnged");
        SetTaskParts();
        GetWheelStage(taskPartOne);
    }

    private void SetTaskParts()
    {
        //indeksler 0'dan 4'e kadar
        taskPartOne = TaskListUI.Instance.GetTempList(0);   //indexList[0]; // örn. saç indeksi neyse o olur
        taskPartTwo = TaskListUI.Instance.GetTempList(1);   //indexList[1]; // örn. el indeksi neyse o olur
        taskPartThree = TaskListUI.Instance.GetTempList(2); //= indexList[2]; // örn. vücut indeksi neyse o olur
    }
    private void GetWheelStage(int stage)
    {
        switch (stage)
        {
            case 0:
                hairList = Resources.Load<HairTypeListSO>(typeof(HairTypeListSO).Name);
                for (int i = 0; i < hairList.list.Count; i++)
                {
                    wheelPartList[i].GetComponent<Image>().color = UtilsClass.GetColorFromString(hairList.list[i].colorHex);
                }
                break;
            case 1:
                eyeList = Resources.Load<EyeListSO>(typeof(EyeListSO).Name);
                for (int i = 0; i < eyeList.list.Count; i++)
                {
                    wheelPartList[i].GetComponent<Image>().color = UtilsClass.GetColorFromString(eyeList.list[i].colorHex);
                }
                break;
            case 2:
                dressList = Resources.Load<DressTypeListSO>(typeof(DressTypeListSO).Name);
                for (int i = 0; i < dressList.list.Count; i++)
                {
                    wheelPartList[i].GetComponent<Image>().color = UtilsClass.GetColorFromString(dressList.list[i].colorHex);
                }
                break;
            case 3:
                bodyList = Resources.Load<BodyTypeListSO>(typeof(BodyTypeListSO).Name);
                for (int i = 0; i < bodyList.list.Count; i++)
                {
                    wheelPartList[i].GetComponent<Image>().color = UtilsClass.GetColorFromString(bodyList.list[i].colorHex);
                }
                break;
            case 4:
                lipList = Resources.Load<LipListSO>(typeof(LipListSO).Name);
                for (int i = 0; i < lipList.list.Count; i++)
                {
                    wheelPartList[i].GetComponent<Image>().color = UtilsClass.GetColorFromString(lipList.list[i].colorHex);
                }
                break;
        }
    }
    private void CheckStage()
    {
        //UI'da týkladýktan sonraki check iþlemi
        switch (stage)
        {
            case 1:
                stage++;
                GetWheelStage(taskPartTwo);
                break;
            case 2:
                stage++;
                GetWheelStage(taskPartThree);
                break;
            case 3:
                stage = 1;
                break;
        }
    }
}
