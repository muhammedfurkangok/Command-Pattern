
using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class Unitaskpracc : MonoBehaviour
{
    private Tween basicMovementTween;
    private Tween loopMovementTween;
    private Tween easeMovementTween;

    private bool isButtonClicked;

    private void Start()
    {
        //BasicMovement();
        //LoopMovement();
        MovementWithEase();

        //race condition: if two or more functions are called at the same time, the movement will be unpredictable..
        //..because same values (transform.position values) will be trying to changed by two things
        //transform.DOMoveX(5, 1).SetLoops(5, LoopType.Yoyo);
        //basicMovementTween = transform.DOMoveX(-5, 1);
    }

    private async void BasicMovement()
    {
        basicMovementTween = transform.DOMoveX(-5, 1);
        await basicMovementTween;
        print("X movement completed");
    }

    private async void LoopMovement()
    {
        loopMovementTween = transform.DOMoveX(5, 1).SetLoops(5, LoopType.Yoyo);
        loopMovementTween.SetLoops(5, LoopType.Incremental);
        //loopMovementTween.SetLoops(5, LoopType.Restart);
    }
    
    private async void MovementWithEase()
    {
        easeMovementTween = transform.DOMoveX(5, 1).SetEase(Ease.InOutCirc).Pause();
        
        await UniTask.WaitUntil(() => isButtonClicked);
        //await UniTask.WaitUntil(IsButtonClicked);
        
        easeMovementTween.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) isButtonClicked = true;
    }

    private bool IsButtonClicked()
    {
        return isButtonClicked;
    }
}
