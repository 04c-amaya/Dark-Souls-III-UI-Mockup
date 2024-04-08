using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsUIManager : MonoBehaviour
{
    public GameObject gameSettings;
    public GameObject cameraSettings;
    public GameObject soundSettings;
    public GameObject brightnessSettings;
    public GameObject networkSettings;
    public VisualElement activePage;
    public Sprite textBackgroundImage;
    public Sprite buttonBackgroundImage;

    UiDocumentManager uiManager;
    public VisualElement gameSettingsRoot;
    public VisualElement cameraSettingsRoot;
    public VisualElement soundSettingsRoot;
    public VisualElement brightnessSettingsRoot;
    public VisualElement networkSettingsRoot;

    [Header("options")]
    VisualElement gameOptions;
    VisualElement cameraOptions;
    VisualElement soundOptions;
    VisualElement brightnessOptions;
    VisualElement networkOptions;

    [Header("cameraOptions")]
    ProgressBar cameraSpeedBar;

    [Header("soundOptions")]
    ProgressBar musicBar;
    ProgressBar soundEffectBar;
    ProgressBar voiceBar;

    [Header("brightnessOptions")]
    ProgressBar brightnessBar;

    [Header("BackgroundImages")]
    #region BackgroundImgaes
    //Game
    VisualElement toggleAutoLockOnButtonImage;
    VisualElement autoTargetButtonImage;
    VisualElement manualAttackAimingButtonImage;
    VisualElement vibrationButtonImage;
    VisualElement gameOptionDefaultButtonImage;
    VisualElement toggleAutoLockOnTextImage;
    VisualElement autoTargetTextImage;
    VisualElement manualAttackAimingTextImage;
    VisualElement vibrationTextImage;
    //Camera
    VisualElement cameraX_AxisButtonImage;
    VisualElement cameraY_AxisButtonImage;
    VisualElement resetCameraY_AxisButtonImage;
    VisualElement cameraAutoWallRecoveryButtonImage;
    VisualElement cinematicEffectsButtonImage;
    VisualElement cameraDefaultButtonImage;
    VisualElement cameraSpeedTextImage;
    VisualElement cameraX_AxisTextImage;
    VisualElement cameraY_AxisTextImage;
    VisualElement resetCameraY_AxisTextImage;
    VisualElement cameraAutoWallRecoveryTextImage;
    VisualElement cinematicEffectsTextImage;
    //sound
    VisualElement bloodButtonImage;
    VisualElement subtitlesButtonImage;
    VisualElement hudButtonImage;
    VisualElement soundDefaultButtonImage;
    VisualElement bloodTextImage;
    VisualElement subtitlesTextImage;
    VisualElement hudTextImage;
    VisualElement musicTextImage;
    VisualElement sfxTextImage;
    VisualElement voiceTextImage;
    //Brightness
    VisualElement brightnessTextImage;
    //Network
    VisualElement crossRegionButtonImage;
    VisualElement passwordMatchingTextImage;
    VisualElement passwordMatchingButtonImage;
    VisualElement summonSignButtonImage;
    VisualElement voiceChatButtonImage;
    VisualElement playerNameButtonImage;
    VisualElement launchSettingButtonImage;
    VisualElement networkDefaultButtonImage;
    VisualElement crossRegionTextImage;
    VisualElement summonSignTextImage;
    VisualElement voiceChatTextImage;
    VisualElement playerNameTextImage;
    VisualElement launchSettingTextImage;
    #endregion
    Label description;

    public bool gameSettingsIsActive;
    public bool cameraSettingsIsActive;
    public bool soundSettingsIsActive;
    public bool brightnessSettingsIsActive;
    public bool networkSettingsIsActive;
    private void Awake()
    {
        uiManager = GetComponentInParent<UiDocumentManager>();
        gameSettingsRoot = gameSettings.GetComponent<UIDocument>().rootVisualElement;
        soundSettingsRoot = soundSettings.GetComponent<UIDocument>().rootVisualElement;
        cameraSettingsRoot = cameraSettings.GetComponent<UIDocument>().rootVisualElement;
        brightnessSettingsRoot = brightnessSettings.GetComponent<UIDocument>().rootVisualElement;
        networkSettingsRoot = networkSettings.GetComponent<UIDocument>().rootVisualElement;
        GetNetworkOptions();
        GetBrightnessOptions();
        GetSoundOptions();
        GetCameraOptions();
        GetGameOptions();
        GameOptionsActive();
    }
    #region OptionsAwake
    void GetGameOptions()
    {
        gameOptions = gameSettingsRoot.Query<VisualElement>("Game");
    }
    void GetCameraOptions()
    {
        cameraOptions = cameraSettingsRoot.Query<VisualElement>("Camera");
        cameraSpeedBar = cameraSettingsRoot.Query<ProgressBar>("cameraSpeedBar");
    }
    void GetSoundOptions()
    {
        soundOptions = soundSettingsRoot.Query<VisualElement>("Sound");
        musicBar = soundSettingsRoot.Query<ProgressBar>("MusicBar");
        soundEffectBar = soundSettingsRoot.Query<ProgressBar>("SoundEffectBar");
        voiceBar = soundSettingsRoot.Query<ProgressBar>("VoiceBar");
    }
    void GetBrightnessOptions()
    {
        brightnessOptions = brightnessSettingsRoot.Query<VisualElement>("Brightness");
        brightnessBar = brightnessSettingsRoot.Query<ProgressBar>("BrightnessBar");
    }
    void GetNetworkOptions()
    {
        networkOptions = networkSettingsRoot.Query<VisualElement>("Network");
    }
    #endregion
    private void Update()
    {
        description = activePage.Query<Label>("Description");
        if (uiManager.optionsIsActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameOptionsActive();
                uiManager.MainMenuActive();
            }
            gameSettingsRoot.RegisterCallback<MouseOverEvent>(GameSettingsHover);
            gameSettingsRoot.RegisterCallback<ClickEvent>(SettingsClicked);


            cameraSettingsRoot.RegisterCallback<MouseOverEvent>(CameraSettingsHover);
            cameraSettingsRoot.RegisterCallback<ClickEvent>(SettingsClicked);


            soundSettingsRoot.RegisterCallback<MouseOverEvent>(SoundSettingsHover);
            soundSettingsRoot.RegisterCallback<ClickEvent>(SettingsClicked);

            brightnessSettingsRoot.RegisterCallback<MouseOverEvent>(BrightnessSetttingsHover);
            brightnessSettingsRoot.RegisterCallback<ClickEvent>(SettingsClicked);


            networkSettingsRoot.RegisterCallback<MouseOverEvent>(NetworkSettingsHover);
            networkSettingsRoot.RegisterCallback<ClickEvent>(SettingsClicked);
        }

    }
    #region WhatOptionPageIsActive
    void GameOptionsActive()
    {
        ActiveState(gameSettingsRoot, soundSettingsRoot, cameraSettingsRoot, brightnessSettingsRoot, networkSettingsRoot);
        ChangeSortOrder(gameSettings, cameraSettings, soundSettings, brightnessSettings, networkSettings);
        activePage = gameSettingsRoot;
        gameSettingsIsActive= true;
        cameraSettingsIsActive= false;
        soundSettingsIsActive= false;
        brightnessSettingsIsActive= false;
        networkSettingsIsActive= false;

    toggleAutoLockOnButtonImage = gameSettingsRoot.Query<VisualElement>("ToggleAutoLockOnButtonImage");
        autoTargetButtonImage = gameSettingsRoot.Query<VisualElement>("AutoTargetButtonImage");
        manualAttackAimingButtonImage = gameSettingsRoot.Query<VisualElement>("ManualAttackAimingButtonImage");
        vibrationButtonImage = gameSettingsRoot.Query<VisualElement>("VibrationButtonImage");
        gameOptionDefaultButtonImage = gameSettingsRoot.Query<VisualElement>("GameOptionDefaultButtonImage");

        toggleAutoLockOnTextImage = gameSettingsRoot.Query<VisualElement>("ToggleAutoLockOnTextImage");
        autoTargetTextImage = gameSettingsRoot.Query<VisualElement>("AutoTargetTextImage");
        manualAttackAimingTextImage = gameSettingsRoot.Query<VisualElement>("ManualAttackAimingTextImage");
        vibrationTextImage = gameSettingsRoot.Query<VisualElement>("VibrationTextImage");
    }
    void CameraOptionsActive()
    {
        ActiveState(cameraSettingsRoot, soundSettingsRoot, gameSettingsRoot, brightnessSettingsRoot, networkSettingsRoot);
        ChangeSortOrder(cameraSettings, gameSettings, soundSettings, brightnessSettings, networkSettings);
        activePage = cameraSettingsRoot;
        gameSettingsIsActive = false;
        cameraSettingsIsActive = true;
        soundSettingsIsActive = false;
        brightnessSettingsIsActive = false;
        networkSettingsIsActive = false;

        cameraX_AxisButtonImage = cameraSettingsRoot.Query<VisualElement>("CameraX_AxisButtonImage");
        cameraY_AxisButtonImage = cameraSettingsRoot.Query<VisualElement>("CameraY_AxisButtonImage");
        resetCameraY_AxisButtonImage = cameraSettingsRoot.Query<VisualElement>("ResetCameraY_AxisButtonImage");
        cameraAutoWallRecoveryButtonImage = cameraSettingsRoot.Query<VisualElement>("CameraAutoWallRecoveryButtonImage");
        cinematicEffectsButtonImage = cameraSettingsRoot.Query<VisualElement>("CinematicEffectsButttonImage");
        cameraDefaultButtonImage = cameraSettingsRoot.Query<VisualElement>("CameraDefaultImage");

        cameraX_AxisTextImage = cameraSettingsRoot.Query<VisualElement>("CameraX_AxisTextImage");
        cameraY_AxisTextImage = cameraSettingsRoot.Query<VisualElement>("CameraY_AxisTextImage");
        resetCameraY_AxisTextImage = cameraSettingsRoot.Query<VisualElement>("ResetCameraY_AxisTextImage");
        cameraAutoWallRecoveryTextImage = cameraSettingsRoot.Query<VisualElement>("CameraAutoWallRecoveryTextImage");
        cinematicEffectsTextImage = cameraSettingsRoot.Query<VisualElement>("CinematicEffectsTextImage");
        cameraSpeedTextImage = cameraSettingsRoot.Query<VisualElement>("CameraSpeedTextImage");
    }
    void SoundOptionsActive()
    {
        ActiveState(soundSettingsRoot, gameSettingsRoot, cameraSettingsRoot, brightnessSettingsRoot, networkSettingsRoot);
        ChangeSortOrder(soundSettings, cameraSettings, gameSettings, brightnessSettings, networkSettings);
        activePage = soundSettingsRoot;
        gameSettingsIsActive = false;
        cameraSettingsIsActive = false;
        soundSettingsIsActive = true;
        brightnessSettingsIsActive = false;
        networkSettingsIsActive = false;

        bloodButtonImage = soundSettingsRoot.Query<VisualElement>("BloodButtonImage");
        subtitlesButtonImage = soundSettingsRoot.Query<VisualElement>("SubtitlesButtonImage");
        hudButtonImage = soundSettingsRoot.Query<VisualElement>("HUDButtonImage");
        soundDefaultButtonImage = soundSettingsRoot.Query<VisualElement>("SoundDefaultImage");
        bloodTextImage = soundSettingsRoot.Query<VisualElement>("BloodTextImage");
        subtitlesTextImage = soundSettingsRoot.Query<VisualElement>("SubtitlesTextImage");
        hudTextImage = soundSettingsRoot.Query<VisualElement>("HUDTextImage");
        musicTextImage = soundSettingsRoot.Query<VisualElement>("MusicTextImage");
        sfxTextImage = soundSettingsRoot.Query<VisualElement>("SoundEffectsImage");
        voiceTextImage= soundSettingsRoot.Query<VisualElement>("VoiceTextImage");


    }
    void BrightnessOptionsActive()
    {
        ActiveState(brightnessSettingsRoot, soundSettingsRoot, cameraSettingsRoot, gameSettingsRoot, networkSettingsRoot);
        ChangeSortOrder(brightnessSettings, cameraSettings, soundSettings, gameSettings, networkSettings);
        activePage = brightnessSettingsRoot;
        gameSettingsIsActive = false;
        cameraSettingsIsActive = false;
        soundSettingsIsActive = false;
        brightnessSettingsIsActive = true;
        networkSettingsIsActive = false;
        brightnessTextImage = brightnessSettingsRoot.Query<VisualElement>("BrightnessTextImage");
    }
    void NetworkOptionsActive()
    {
        ActiveState(networkSettingsRoot, soundSettingsRoot, cameraSettingsRoot, brightnessSettingsRoot, gameSettingsRoot);
        ChangeSortOrder(networkSettings, cameraSettings, soundSettings, brightnessSettings, gameSettings);
         activePage = networkSettingsRoot;
        gameSettingsIsActive = false;
        cameraSettingsIsActive = false;
        soundSettingsIsActive = false;
        brightnessSettingsIsActive = false;
        networkSettingsIsActive = true;

        crossRegionButtonImage = networkSettingsRoot.Query<VisualElement>("CrossRegionButtonImage");
        passwordMatchingTextImage = networkSettingsRoot.Query<VisualElement>("PasswordMatchingTextImage");
        summonSignButtonImage = networkSettingsRoot.Query<VisualElement>("SummonSignButtonImage");
        voiceChatButtonImage = networkSettingsRoot.Query<VisualElement>("VoiceChatButtonImage");
        playerNameButtonImage = networkSettingsRoot.Query<VisualElement>("PlayerNameButtonImage");
        launchSettingButtonImage = networkSettingsRoot.Query<VisualElement>("LaunchSettingsButtonImage");
        networkDefaultButtonImage = networkSettingsRoot.Query<VisualElement>("NetworkDefaultButtonImage");

        crossRegionTextImage = networkSettingsRoot.Query<VisualElement>("CrossRegionTextImage");
        summonSignTextImage = networkSettingsRoot.Query<VisualElement>("SummonSignTextImage");
        voiceChatTextImage = networkSettingsRoot.Query<VisualElement>("VoiceChatTextImage");
        playerNameTextImage = networkSettingsRoot.Query<VisualElement>("PlayerNameTextImage");
        launchSettingTextImage = networkSettingsRoot.Query<VisualElement>("LaunchSettingsTextImage");
    }
    #endregion
    #region MouseEvents
    void GameSettingsHover(MouseOverEvent eventHover)
    {

        var nameOfObject = eventHover.target.ToString();
            Debug.Log("Game Hover Active");
            if (nameOfObject.Contains("ToggleAutoLockOnText"))
            {
                toggleAutoLockOnTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Set auto lock-on to new target when former target dies.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                toggleAutoLockOnTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("ToggleAutoLockOnButton"))
            {
                toggleAutoLockOnButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                toggleAutoLockOnButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("AutoTargetText"))
            {
                autoTargetTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
                description.text = "Automatically target an enemy when attacking close range with no lock.";
            }
            else
            {
                autoTargetTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("AutoTargetButton"))
            {
                autoTargetButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                autoTargetButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("ManualAttackAimingText"))
            {
                manualAttackAimingTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
                description.text = "Allows for manual control of aiming of large weapons when locked on.";
            }
            else
            {
                manualAttackAimingTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("ManualAttackAimingButton"))
            {
                manualAttackAimingButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                manualAttackAimingButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("VibrationText"))
            {
                vibrationTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
                description.text = "Set controls used for jumping.";
            }
            else
            {
                vibrationTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("VibrationButton"))
            {
                vibrationButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                vibrationButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("GameOptionDefaultButton"))
            {
                gameOptionDefaultButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                gameOptionDefaultButtonImage.style.backgroundImage = null;
            
        }
       

    }
    void CameraSettingsHover(MouseOverEvent eventHover)
    {

        ////Debug.Log(eventHover.target);
        var nameOfObject = eventHover.target.ToString();
        if(cameraSettingsIsActive == true)
        {
            Debug.Log("Camera Hover Active");
            if (nameOfObject.Contains("CameraX_AxisText"))
            {
                cameraX_AxisTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Change left/right camera movement.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                cameraX_AxisTextImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("CameraX_AxisButton"))
            {
                cameraX_AxisButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                cameraX_AxisButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("Camera_Y_AxisText"))
            {
                cameraY_AxisTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Change up/down camera movement.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                cameraY_AxisTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("Camera_Y_AxisButton"))
            {
                cameraY_AxisButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                cameraY_AxisButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("ResetCameraY_AxisText"))
            {
                resetCameraY_AxisTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Camera reset also resets the camera y-axis.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                resetCameraY_AxisTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("ResetCameraY_AxisButton"))
            {
                resetCameraY_AxisButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                resetCameraY_AxisButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("CameraSpeedText"))
            {
                cameraSpeedTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
                description.text = "Set camera movemement speed.";
            }
            else
            {
                cameraSpeedTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("CameraAutoWallRecoveryText"))
            {
                cameraAutoWallRecoveryTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
                description.text = "Set whether the camera automatically avoids walls.";
            }
            else
            {
                cameraAutoWallRecoveryTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("CameraAutoWallRecoveryButton"))
            {
                cameraAutoWallRecoveryButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                cameraAutoWallRecoveryButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("CinematicEffectsText"))
            {
                cinematicEffectsTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
                description.text = "Change wheter effects are shown.";
            }
            else
            {
                cinematicEffectsTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("CinematicEffectsButtton"))
            {
                cinematicEffectsButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                cinematicEffectsButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("CameraDefault"))
            {
                cameraDefaultButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                cameraDefaultButtonImage.style.backgroundImage = null;
            }
        }
    }
    void SoundSettingsHover(MouseOverEvent eventHover)
    {
        ////Debug.Log(eventHover.target);
        var nameOfObject = eventHover.target.ToString();
        if (soundSettingsIsActive == true)
        {
            Debug.Log("Sound Hover Active");
            if (nameOfObject.Contains("BloodText"))
            {
                bloodTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Switch deciption of blood on or off.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                bloodTextImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("BloodButton"))
            {
                bloodButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                bloodButtonImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("SubtitlesText"))
            {
                subtitlesTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Switch in-game subtitles on or off.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                subtitlesTextImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("SubtitlesButton"))
            {
                subtitlesButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                subtitlesButtonImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("HUDText"))
            {
                hudTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Configure how in-game HUD is displayed.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                hudTextImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("HUDButton"))
            {
                hudButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                hudButtonImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("MusicText"))
            {
                musicTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Adjust music level.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                musicTextImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("SoundEffectsText"))
            {
                sfxTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Adjust sound level.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                sfxTextImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("VoiceText"))
            {
                voiceTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Adjust voice level.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                voiceTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("SoundDefaultButton"))
            {
                soundDefaultButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                soundDefaultButtonImage.style.backgroundImage = null;
            }
        }
    }
    void BrightnessSetttingsHover(MouseOverEvent eventHover)
    {
        ////Debug.Log(eventHover.target);
        var nameOfObject = eventHover.target.ToString();
        if (brightnessSettingsIsActive == true)
        {
            Debug.Log("Brightness Hover Active");


            if (nameOfObject.Contains("BrightnessText"))
            {
                brightnessTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Adjust screen brightness.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                brightnessTextImage.style.backgroundImage = null;
            }

        }
    }
    void NetworkSettingsHover(MouseOverEvent eventHover)
    {
       Debug.Log(eventHover.target);
        var nameOfObject = eventHover.target.ToString();
        if (networkSettingsIsActive == true)
        {
            Debug.Log("Network Hover Active");


            if (nameOfObject.Contains("CrossRegionText"))
            {
                crossRegionTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Allow or restrict cross-region matching.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                crossRegionTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("CrossRegionButton"))
            {
                crossRegionButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                crossRegionButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("PasswordMatchingText"))
            {
                passwordMatchingTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Edit to match with players using the same password.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                passwordMatchingTextImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("SummonSignText"))
            {
                summonSignTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Restrict the visibility of your summon sign in enemy phantom worlds.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                summonSignTextImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("SummonSignButton"))
            {
                summonSignButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                summonSignButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("VoiceChatText"))
            {
                voiceChatTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Allow or restrict voice chat.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                voiceChatTextImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("VoiceChatButton"))
            {
                voiceChatButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                voiceChatButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("PlayerNameText"))
            {
                playerNameTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Change options for display of player names.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                playerNameTextImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("PlayerNameButton"))
            {
                playerNameButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                playerNameButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("LaunchSettingsText"))
            {
                launchSettingTextImage.style.backgroundImage = new StyleBackground(textBackgroundImage);
                description.text = "Choose to start the game in online or offline mode.";
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.scrollSoundOptions);
            }
            else
            {
                launchSettingTextImage.style.backgroundImage = null;
            }

            if (nameOfObject.Contains("LaunchSettingsButton"))
            {
                launchSettingButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                launchSettingButtonImage.style.backgroundImage = null;
            }
            if (nameOfObject.Contains("NetworkDefaultButton"))
            {
                networkDefaultButtonImage.style.backgroundImage = new StyleBackground(buttonBackgroundImage);
                uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
            }
            else
            {
                networkDefaultButtonImage.style.backgroundImage = null;
            }
        }
      
    }
    void SettingsClicked(ClickEvent eventEnter)
    {
        //Debug.Log(eventEnter.target);
        var nameOfObject = eventEnter.target.ToString();

        if (nameOfObject.Contains("GameUnhighlighted"))
        {
            GameOptionsActive();
        }
        if (nameOfObject.Contains("CameraUnhighlighted"))
        {
            CameraOptionsActive();
        }
        if (nameOfObject.Contains("SoundUnhighlighted"))
        {
            SoundOptionsActive();
        }
        if (nameOfObject.Contains("BrightnessUnhighlighted"))
        {
            BrightnessOptionsActive();
        }
        if (nameOfObject.Contains("NetworkUnhighlighted"))
        {
            NetworkOptionsActive();
        }
    }
    void ActiveState(VisualElement activeElement, VisualElement disabledElement1,VisualElement disabledElement2, VisualElement disabledElement3, VisualElement disabledElement4)
    {
        VisualElement activeElementMenu = activeElement.Query<VisualElement>("mainMenu");
        activeElementMenu.style.display = DisplayStyle.Flex;

        VisualElement disabledElementMenu1 = disabledElement1.Query<VisualElement>("mainMenu");
        disabledElementMenu1.style.display = DisplayStyle.None;

        VisualElement disabledElementMenu2 = disabledElement2.Query<VisualElement>("mainMenu");
        disabledElementMenu2.style.display = DisplayStyle.None;

        VisualElement disabledElementMenu3 = disabledElement3.Query<VisualElement>("mainMenu");
        disabledElementMenu3.style.display = DisplayStyle.None;

        VisualElement disabledElementMenu4 = disabledElement3.Query<VisualElement>("mainMenu");
        disabledElementMenu4.style.display = DisplayStyle.None;
    }
    void ChangeSortOrder(GameObject activeElement, GameObject disabledElement1, GameObject disabledElement2, GameObject disabledElement3, GameObject disabledElement4)
    {
       UIDocument activeUI = activeElement.GetComponent<UIDocument>();
        UIDocument disabledUI1 = disabledElement1.GetComponent<UIDocument>();
        UIDocument disabledUI2 = disabledElement2.GetComponent<UIDocument>();
        UIDocument disabledUI3 = disabledElement3.GetComponent<UIDocument>();
        UIDocument disabledUI4 = disabledElement4.GetComponent<UIDocument>();

        activeUI.sortingOrder = 1;
        disabledUI1.sortingOrder = 0;
        disabledUI2.sortingOrder = 0;
        disabledUI3.sortingOrder = 0;
        disabledUI4.sortingOrder = 0;
    }
    void ButtonPressed(Button button, string option1, string option2)
    {
        if (button.text == option1)
        {
            button.text = option2;
        }
        else
        {
            button.text = option1;
        }
        uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.clickSoundOptions);
    }
    void GameOptionsDefault(Button button1, Button button2, Button button3, Button button4)
    {
        button1.text = "On";
        button2.text = "On";
        button3.text = "On";
        button4.text = "On";
    }
    void CameraOptionsDefault(Button button1, Button button2, Button button3, Button button4, Button button5, ProgressBar slider)
    {
        button1.text = "Normal";
        button2.text = "Normal";
        button3.text = "On";
        button4.text = "On";
        button5.text = "On";
        slider.value = 10;
    }
    void SoundOptionsDefault(Button button1, Button button2, Button button3, ProgressBar slider, ProgressBar slider2, ProgressBar slider3)
    {

        button1.text = "On";
        button2.text = "On";
        button3.text = "On";

        slider.value = 10;
        slider2.value = 10;
        slider3.value = 10;
    }
    void NetworkOptionsDefault(Button button1, Button button2, Button button3, Button button4, Button button5, TextField textField)
    {
        button1.text = "MatchMaking On";
        button2.text = "Unrestricted";
        button3.text = "Allowed";
        button4.text = "Character Name";
        button5.text = "Online";
        textField.value = "";
    }
    #endregion

}
