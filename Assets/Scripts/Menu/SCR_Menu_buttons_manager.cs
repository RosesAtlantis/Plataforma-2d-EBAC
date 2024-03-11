using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SCR_Menu_buttons_manager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animations")]

    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    private void Awake()
    {
        HiddenAllButtons();
        ShowButtons();
    }

    private void HiddenAllButtons()
    {
        foreach (var b in buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        // foreach (var b in buttons)
        for(int i = 0; i < buttons.Count; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i*delay).SetEase(ease);
        }
    }
}
