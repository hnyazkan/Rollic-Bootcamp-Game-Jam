using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIInfoText : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    public TextMeshProUGUI speakingText;

    private void Awake()
    {
        speakingText = gameObject.GetComponent<TextMeshProUGUI>();
        
    }

    private void Start()
    {
        
        //speakingText.text = "aaaaaaa";
        textWriter.AddWriter(speakingText, "Create My Perfect Match!", 0.2f);
        

    }
}
