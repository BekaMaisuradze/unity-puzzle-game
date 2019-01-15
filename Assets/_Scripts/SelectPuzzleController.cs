using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPuzzleController : MonoBehaviour
{
    [SerializeField]
    private PuzzleGameManager puzzleGameManager;

    [SerializeField]
    private GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;

    [SerializeField]
    private Animator selectPuzzleMenuAnim, puzzleLevelSelectAnim;

    [SerializeField]
    private SelectLevelController selectLevelController;

    private string selectedPuzzle;

    public void SelectedPuzzle()
    {
        selectedPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        puzzleGameManager.SetSelectedPuzzle(selectedPuzzle);
        selectLevelController.SetSelectedPuzzle(selectedPuzzle);
        StartCoroutine(ShowPuzzleLevelSelectMenu());
    }

    IEnumerator ShowPuzzleLevelSelectMenu()
    {
        puzzleLevelSelectPanel.SetActive(true);
        selectPuzzleMenuAnim.Play("SlideOut");
        puzzleLevelSelectAnim.Play("SlideIn");
        yield return new WaitForSeconds(1f);
        selectPuzzleMenuPanel.SetActive(false);
    }
}
