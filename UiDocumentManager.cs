using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UiDocumentManager : MonoBehaviour
{
    SliderFix sliderFix;
    public GameObject mainMenu;
    public GameObject announment;
    public GameObject splashScreen;
    public GameObject loadingScreen;
    public GameObject options;

    [HideInInspector]
    public bool mainMenuIsActive;
    [HideInInspector]
    public bool announmentIsActive;
    [HideInInspector]
    public bool splashScreenIsActive;
    [HideInInspector]
    public bool loadingScreenIsActive;
    [HideInInspector]
    public bool optionsIsActive;

    public GameObject AudioManager;
    public GameObject BrightnessManager;
    public GameObject GameManager;
    OptionsUIManager optionsUIManager;
    public BrightnessManager brightnessManagerScript;
    public AudioManager audioManagerScript;
    public GameManager gameManagerScript;
    VisualElement mainMenuRoot;
    VisualElement announmentRoot;
    VisualElement splashScreenRoot;
    VisualElement loadingScreenRoot;
    VisualElement optionsRoot;

    private void Awake()
    {
        optionsUIManager = options.GetComponent<OptionsUIManager>();
        brightnessManagerScript = BrightnessManager.GetComponent<BrightnessManager>();
        audioManagerScript = AudioManager.GetComponent<AudioManager>();
        gameManagerScript = GameManager.GetComponent<GameManager>();

        mainMenuRoot = mainMenu.GetComponent<UIDocument>().rootVisualElement;
        announmentRoot = announment.GetComponent<UIDocument>().rootVisualElement;
        splashScreenRoot = splashScreen.GetComponent<UIDocument>().rootVisualElement;
        loadingScreenRoot = loadingScreen.GetComponent<UIDocument>().rootVisualElement;
        optionsRoot = optionsUIManager.gameSettings.GetComponent<UIDocument>().rootVisualElement;
        sliderFix = GetComponentInChildren<SliderFix>();

        SplashScreenActive();
    }
    private void Update()
    {
        audioManagerScript.ChangeMusicVolume(sliderFix.musicSlider);
        audioManagerScript.ChangeSoundEffectVolume(sliderFix.soundEffectSlider);
        brightnessManagerScript.ChangeBrightness(sliderFix.brightnessSlider);
    }
    public void MainMenuActive()
    {
        ActiveState(mainMenuRoot, loadingScreenRoot, announmentRoot, splashScreenRoot, optionsRoot);

         mainMenuIsActive= true;
         announmentIsActive= false;
         splashScreenIsActive= false;
         loadingScreenIsActive= false;
         optionsIsActive= false;

        // ChangeSortOrder(mainMenu, splashScreen, announment, loadingScreen, options);
    }
    public void AnnounmentActive()
    {
        ActiveState(announmentRoot, loadingScreenRoot, mainMenuRoot, splashScreenRoot, optionsRoot);
        mainMenuIsActive = false;
        announmentIsActive = true;
        splashScreenIsActive = false;
        loadingScreenIsActive = false;
        optionsIsActive = false;
        // ChangeSortOrder(announment, splashScreen, mainMenu, loadingScreen, options);
    }
    public void SplashScreenActive()
    {
        ActiveState(splashScreenRoot, announmentRoot, mainMenuRoot, loadingScreenRoot, optionsRoot);
        mainMenuIsActive = false;
        announmentIsActive = false;
        splashScreenIsActive = true;
        loadingScreenIsActive = false;
        optionsIsActive = false;
        //  ChangeSortOrder(splashScreen, announment, mainMenu, loadingScreen, options);
    }
    public void LoadingScreenActive()
    {
        ActiveState(loadingScreenRoot, announmentRoot, mainMenuRoot, splashScreenRoot, optionsRoot);
        mainMenuIsActive = false;
        announmentIsActive = false;
        splashScreenIsActive = false;
        loadingScreenIsActive = true;
        optionsIsActive = false;
        //  ChangeSortOrder(loadingScreen, announment, mainMenu, splashScreen, options);

    }
    public void OptionsActive()
    {
        ActiveState(optionsRoot, announmentRoot, mainMenuRoot, splashScreenRoot, loadingScreenRoot);
        mainMenuIsActive = false;
        announmentIsActive = false;
        splashScreenIsActive = false;
        loadingScreenIsActive = false;
        optionsIsActive = true;

        //  ChangeSortOrder(options, announment,mainMenu,loadingScreen,splashScreen);

    }
    void ActiveState(VisualElement activeElement, VisualElement disabledElement1, VisualElement disabledElement2, VisualElement disabledElement3, VisualElement disabledElement4)
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

}
