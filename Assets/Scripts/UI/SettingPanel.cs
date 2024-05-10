using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private Image[] settingImages;

    [SerializeField] private Sprite[] settingSprites;

    private bool IsVolumeOn = true;
    private bool IsVibrateOn = true;

    private void Start()
    {
        IsVolumeOn = (AudioManager.VolumeOn == 1) ? true : false;
        IsVibrateOn = (AudioManager.VibrateOn == 1) ? true : false;
    }

    public void TapBtnVolumeSetting()
    {
        IsVolumeOn = !IsVolumeOn;
        AudioManager.VolumeOn = IsVolumeOn ? 1 : 0;
        /*ChangeSpriteBtnVolumeSetting();*/
    }

    public void TapBtnVibrateSetting()
    {
        IsVibrateOn = !IsVibrateOn;
        AudioManager.VibrateOn = IsVibrateOn ? 1 : 0;
        /*ChangeSpriteBtnVibrateSetting();*/
    }

    public void BackBTN()
    {
        gameObject.SetActive(false);
    }

    private void ChangeSpriteBtnVolumeSetting()
    {
        if (IsVolumeOn)
        {
            settingImages[0].sprite = settingSprites[0];
        }
        else
        {
            settingImages[0].sprite = settingSprites[1];
        }
    }

    private void ChangeSpriteBtnVibrateSetting()
    {
        if (IsVibrateOn)
        {
            settingImages[1].sprite = settingSprites[2];
        }
        else
        {
            settingImages[1].sprite = settingSprites[3];
        }
    }

    private void Update()
    {
        if (IsVolumeOn)
        {
            settingImages[0].sprite = settingSprites[0];
        }
        else
        {
            settingImages[0].sprite = settingSprites[1];
        }

        if (IsVibrateOn)
        {
            settingImages[1].sprite = settingSprites[2];
        }
        else
        {
            settingImages[1].sprite = settingSprites[3];
        }
    }
}