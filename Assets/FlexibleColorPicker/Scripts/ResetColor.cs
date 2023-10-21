using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ResetColor : MonoBehaviour
{
    private float first, second, third;
    public FlexibleColorPicker colorPicker;

    public void ResetColorFirstInt(float one)
    {
        first = coloNumberConversion(one);
    }
    public void ResetColorSecondInt(float two)
    {
        second = coloNumberConversion(two);
    }
    public void ResetColorThirdInt(float three)
    {
        third = coloNumberConversion(three);
    }
    public void ResetMaterialColor()
    {
        colorPicker.SetColor(new Color(first, second, third));
    }

    public void SetNewStartingColor()
    {
        colorPicker.startingColor = colorPicker.GetColor();
    }


    private float coloNumberConversion(float num)
    {
        return (num / 255.0f);
    }

}
