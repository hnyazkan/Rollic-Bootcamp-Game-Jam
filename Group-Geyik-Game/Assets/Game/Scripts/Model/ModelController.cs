using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ModelController : MonoBehaviour
{
    // Settings=ses seviyesi, hareket hızı gibi oyun açıkken değiştirmek isticeğimiz oyun ayarları
    [SerializeField] private ModelControllerSettings modelSettings;
    
    //kıyafetleri gözü ağzı birleşmiş hali = model
    [SerializeField] private ModelSO model;

}