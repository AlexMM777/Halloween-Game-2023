using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class SettingsButtonUI : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    Resolution[] resolutions;
    private Resolution[] reversedResolutions;
    public TMP_Dropdown resolutionDropdown;
    public AudioMixer audioMixer;
    public TMP_Dropdown graphics;
    public int initialRun;

    void Start()
    {
        //mainMenu.SetActive(true);
        //quit.SetActive(false);
        //settings.SetActive(false); 
        CreateResDropdown();
    }

    void Update()
    {

    }

    public void CreateResDropdown()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutions.Reverse();
        reversedResolutions = resolutions;
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        graphics.value = PlayerPrefs.GetInt("GraphicQuality");
    }

    public void LoadScene(string sceneToLoad)
    {
        StartCoroutine(LoadAsync(sceneToLoad));

        //SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator LoadAsync (string sceneToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01( operation.progress / .9f );
            slider.value = progress;
            yield return null;
        }
    }

    public void Enable(GameObject item)
    {
        item.SetActive(true);
    }

    public void Disable(GameObject item)
    {
        item.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        if (initialRun >= 1)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
            PlayerPrefs.SetInt("GraphicQuality", qualityIndex);
        }
        initialRun++;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("masterVol", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVol", volume);
    }
    public void SetSoundEffectsVolume(float volume)
    {
        audioMixer.SetFloat("sfxVol", volume);
    }
}
