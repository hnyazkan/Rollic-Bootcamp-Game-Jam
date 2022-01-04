using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance { get; private set; }

    //private Dictionary<HairTypeListSO, Transform> list;

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
        CreateRecipe();
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

    private void CreateRecipe()
    {
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
