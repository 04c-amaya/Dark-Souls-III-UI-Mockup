using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUIManager : MonoBehaviour
{
    UiDocumentManager uiManager;

    VisualElement root;
    Button Continue;
    Button LoadGame;
    Button NewGame;
    Button System;
    Button Information;
    Button Help;
    Button Quit;

    VisualElement ContinueImage;
    VisualElement LoadGameImage;
    VisualElement NewGameImage;
    VisualElement SystemImage;
    VisualElement InformationImage;
    VisualElement HelpImage;
    VisualElement QuitImage;
    public Sprite backgroundImage;

    private void Awake()
    {
        uiManager = GetComponentInParent<UiDocumentManager>();
        root = GetComponent<UIDocument>().rootVisualElement;

        ContinueImage = root.Query<VisualElement>("ContinueImage");
        LoadGameImage = root.Query<VisualElement>("LoadGameImage");
        NewGameImage = root.Query<VisualElement>("NewGameImage");
        SystemImage = root.Query<VisualElement>("SystemImage");
        InformationImage = root.Query<VisualElement>("InformationImage");
        HelpImage = root.Query<VisualElement>("HelpImage");
        QuitImage = root.Query<VisualElement>("QuitImage");

        Continue = root.Query<Button>("Continue");
        LoadGame = root.Query<Button>("LoadGame");
        NewGame = root.Query<Button>("NewGame");
        System = root.Query<Button>("System");
        Information = root.Query<Button>("Information");
        Help = root.Query<Button>("Help");
        Quit = root.Query<Button>("Quit");
    }
    void ClickEventFunction(ClickEvent eventClick)
    {
      //  Debug.Log(eventClick.target);
        if (eventClick.target == Continue)
        {
            uiManager.LoadingScreenActive();
            uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.clickSound);
        }
        if (eventClick.target == LoadGame)
        {

        }
        if (eventClick.target ==NewGame)
        {

        }
        if (eventClick.target ==System)
        {
            uiManager.OptionsActive();
            uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.clickSound);
        }
        if (eventClick.target ==Information)
        {

        }
        if (eventClick.target ==Help)
        {

        }
        if (eventClick.target == Quit)
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }

    void HoverEvent(MouseOverEvent eventHover)
    {
        Debug.Log(eventHover.target);
        if (eventHover.target == Continue)
        {
            ContinueImage.style.backgroundImage = new StyleBackground(backgroundImage);
            uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
        }
        else
        {
            ContinueImage.style.backgroundImage = null;
        }
        if (eventHover.target == LoadGame)
        {
            LoadGameImage.style.backgroundImage = new StyleBackground(backgroundImage);
            uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
        }
        else
        {
            LoadGameImage.style.backgroundImage = null;
        }
        if (eventHover.target == NewGame)
        {
            NewGameImage.style.backgroundImage = new StyleBackground(backgroundImage);
            uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
        }
        else
        {
            NewGameImage.style.backgroundImage = null;
        }
        if (eventHover.target == System)
        {
            SystemImage.style.backgroundImage = new StyleBackground(backgroundImage);
            uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
        }
        else
        {
            SystemImage.style.backgroundImage = null;
        }
        if (eventHover.target == Information)
        {
            InformationImage.style.backgroundImage = new StyleBackground(backgroundImage);
            uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
        }
        else
        {
            InformationImage.style.backgroundImage = null;
        }
        if (eventHover.target == Help)
        {
            HelpImage.style.backgroundImage = new StyleBackground(backgroundImage);
            uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
        }
        else
        {
            HelpImage.style.backgroundImage = null;
        }
        if (eventHover.target == Quit)
        {
            QuitImage.style.backgroundImage = new StyleBackground(backgroundImage);
            uiManager.audioManagerScript.PlaySfx(uiManager.audioManagerScript.hoverSound);
        }
        else
        {
            QuitImage.style.backgroundImage = null;
        }
    }

    private void Update()
    {
        if (uiManager.mainMenuIsActive)
        {
            root.RegisterCallback<ClickEvent>(ClickEventFunction);
            root.RegisterCallback<MouseOverEvent>(HoverEvent);
        }
    }
}
