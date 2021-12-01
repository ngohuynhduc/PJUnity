using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using System.Linq;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Button btnBack;
    public Sprite btnBackIdle;
    public Sprite btnBackHover;
    public TMP_Dropdown resDropdown;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resDropdown.ClearOptions();
        //Chuyển mảng thành Strings
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i=0;i<resolutions.Length;i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            {
                if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                {
                    currentResolutionIndex = i;
                }
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResolutionIndex;
        resDropdown.RefreshShownValue();
    }
    public void BackClick()
    {
        SceneManager.LoadScene(0);
    }
    public void BackButtonIdle()
    {
        btnBack.GetComponent<Image>().sprite = btnBackIdle;
    }
    public void PlayButtonHover()
    {
        btnBack.GetComponent<Image>().sprite = btnBackHover;
    }
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}

