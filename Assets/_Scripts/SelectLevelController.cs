using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelController : MonoBehaviour
{
    [SerializeField]
    private PuzzleGameManager puzzleGameManager;

    [SerializeField]
    private GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;

    [SerializeField]
    private Animator selectPuzzleMenuAnim, puzzleLevelSelectAnim;

    [SerializeField]
    private LoadPuzzleController loadPuzzleController;

    private string selectedPuzzle;

    public void BackToPuzzleSelectMenu()
    {
        StartCoroutine(ShowPuzzleSelectMenu());
    }

    public void SelectPuzzleLevel()
    {
        int level = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        puzzleGameManager.SetLevel(level);
        loadPuzzleController.LoadPuzzle(level, selectedPuzzle);
    }

    public void SetSelectedPuzzle(string puzzle)
    {
        selectedPuzzle = puzzle;
    }

    IEnumerator ShowPuzzleSelectMenu()
    {
        selectPuzzleMenuPanel.SetActive(true);
        selectPuzzleMenuAnim.Play("SlideIn");
        puzzleLevelSelectAnim.Play("SlideOut");
        yield return new WaitForSeconds(1f);
        puzzleLevelSelectPanel.SetActive(false);
    }
}
