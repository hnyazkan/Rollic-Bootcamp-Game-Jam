using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Datayý çeker ve tarifi oluþturur
/// </summary>
public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance { get; private set; }

    //istenen parçalar
    private HairSO recipedHair;
    private DressSO recipedDress;
    private BodySO recipedBody;
    private EyeSO recipedEye;
    private LipsSO recipedLips;

    //sadece rengi deðiþmeyenler
    private HairTypeListSO hairList;
    private DressTypeListSO dressList;
    private BodyTypeListSO bodyList;

    //sadece rengi deðiþenler
    private EyeListSO eyeList;
    private LipListSO lipList;

    private void Awake()
    {
        Instance = this;

        InitData();
    }

    private void InitData()
    {
        //datalarýmýz
        hairList = Resources.Load<HairTypeListSO>(typeof(HairTypeListSO).Name);
        dressList = Resources.Load<DressTypeListSO>(typeof(DressTypeListSO).Name);
        eyeList = Resources.Load<EyeListSO>(typeof(EyeListSO).Name);
        bodyList = Resources.Load<BodyTypeListSO>(typeof(BodyTypeListSO).Name);
        lipList = Resources.Load<LipListSO>(typeof(LipListSO).Name);
    }
    public void CreateRandomRecipeParts()
    {
        recipedHair = hairList.list[UnityEngine.Random.Range(0, hairList.list.Count)];
        recipedDress = dressList.list[UnityEngine.Random.Range(0, dressList.list.Count)];
        recipedBody = bodyList.list[UnityEngine.Random.Range(0, bodyList.list.Count)];
        recipedEye = eyeList.list[UnityEngine.Random.Range(0, eyeList.list.Count)];
        recipedLips = lipList.list[UnityEngine.Random.Range(0, lipList.list.Count)];
    }
    private void CreateRecipe()
    {
        //zombie code
        recipedHair = hairList.list[0];
        recipedDress = dressList.list[0];
        recipedBody = bodyList.list[0];
        recipedEye = eyeList.list[0];
        recipedLips = lipList.list[0];
    }
    public HairSO GetRecipedHair()
    {
        return recipedHair;
    }
    public DressSO GetRecipedDress()
    {
        return recipedDress;
    }
    public BodySO GetRecipedBody()
    {
        return recipedBody;
    }
    public EyeSO GetRecipedEye()
    {
        return recipedEye;
    }
    public LipsSO GetRecipedLips()
    {
        return recipedLips;
    }


}
