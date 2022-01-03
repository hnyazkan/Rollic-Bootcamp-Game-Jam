using UnityEngine;
using NaughtyAttributes;

public class ProgressBarUI : MonoBehaviour
{
    private Transform barTransform;
    private float currentProgress = 0f; //yapýlan görev
    private float maxProgress = 3f; //toplam görev

    [SerializeField] private float lerpSpeed = 2f; //yeþil bar dolma hareket hýzý

    private void Awake()
    {
        barTransform = transform.Find(StringData.BAR);
    }

    private void Start()
    {
        barTransform.localScale = new Vector3(0f, 1f, 1f);
    }
    private void Update()
    {
        CheckGreenBar();
    }
    
    private void CheckGreenBar()
    {
        //yeþil barýn görev tamamlandýkça yavaþça artmasý
        barTransform.localScale = new Vector3(Mathf.Lerp(barTransform.localScale.x, UpdateProgressAmountNormalized(), lerpSpeed * Time.deltaTime), 1f, 1f);
    }

    [Button]
    private void OneTaskDone()
    {
        currentProgress += 1;
        UpdateProgressAmountNormalized();
    }
    private float UpdateProgressAmountNormalized()
    {
        return (currentProgress / maxProgress);
    }
}
