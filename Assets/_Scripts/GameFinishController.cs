using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishController : MonoBehaviour {

    [SerializeField]
    private GameObject gameFinishedPanel;

    [SerializeField]
    private Animator gameFinishedAnim, star1Anim, star2Anim, star3Anim, textAnim;

    private int stars;

    public void ShowGameFinishedPanel(int stars)
    {
        this.stars = stars;
        StartCoroutine(ShowPanel());
    }

    public void HideGameFinishedPanel()
    {
        if (gameFinishedPanel.activeInHierarchy)
        {
            StartCoroutine(HidePanel());
        }
    }

    IEnumerator ShowPanel()
    {
        gameFinishedPanel.SetActive(true);

        gameFinishedAnim.Play("FadeIn");

        yield return new WaitForSeconds(1.7f);

        switch (stars)
        {
            case 1:

                star1Anim.Play("StarFadeIn");

                yield return new WaitForSeconds(.1f);

                textAnim.Play("TextFadeIn");

                break;

            case 2:

                star1Anim.Play("StarFadeIn");

                yield return new WaitForSeconds(.25f);

                star2Anim.Play("StarFadeIn");

                yield return new WaitForSeconds(.1f);

                textAnim.Play("TextFadeIn");

                break;

            case 3:

                star1Anim.Play("StarFadeIn");

                yield return new WaitForSeconds(.25f);

                star2Anim.Play("StarFadeIn");

                yield return new WaitForSeconds(.25f);

                star3Anim.Play("StarFadeIn");

                yield return new WaitForSeconds(.1f);

                textAnim.Play("TextFadeIn");

                break;

        }

    }

    IEnumerator HidePanel()
    {
        gameFinishedAnim.Play("FadeOut");

        star1Anim.Play("StarFadeOut");
        if (stars > 1) star2Anim.Play("StarFadeOut");
        if (stars > 2) star3Anim.Play("StarFadeOut");
        textAnim.Play("TextFadeOut");

        yield return new WaitForSeconds(1.5f);

        gameFinishedPanel.SetActive(false);

    }
}
