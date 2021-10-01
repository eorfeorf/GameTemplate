using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TitleView : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button exitButton;

    public IReactiveProperty<Unit> OnClickStartButton => onClickStartButton;
    private readonly ReactiveProperty<Unit> onClickStartButton = new ReactiveProperty<Unit>();
    public IReactiveProperty<Unit> OnClickSettingButton => onClickSettingButton;
    private readonly ReactiveProperty<Unit> onClickSettingButton = new ReactiveProperty<Unit>();
    public IReactiveProperty<Unit> OnClickExitButton => onClickExitButton;
    private readonly ReactiveProperty<Unit> onClickExitButton = new ReactiveProperty<Unit>();

    void Start()
    {
        startButton.onClick.AddListener(StartButtonPushed);
        settingButton.onClick.AddListener(SettingButtonPushed);
        exitButton.onClick.AddListener(ExitButtonPushed);
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(StartButtonPushed);
        settingButton.onClick.RemoveListener(SettingButtonPushed);
        exitButton.onClick.RemoveListener(ExitButtonPushed);
    }

    private void StartButtonPushed()
    {
        onClickStartButton.SetValueAndForceNotify(Unit.Default);
    }

    private void SettingButtonPushed()
    {
        onClickSettingButton.SetValueAndForceNotify(Unit.Default);
    }

    private void ExitButtonPushed()
    {
        onClickExitButton.SetValueAndForceNotify(Unit.Default);
    }
}