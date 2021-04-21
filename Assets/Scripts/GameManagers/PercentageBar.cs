using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class PercentageBar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image mask;
    void Start()
    {
        
    }

    void Update()
    {
        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        //alınan değere göre barın yüzde kaç kaldığının hesaplanması
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
