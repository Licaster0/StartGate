using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public SnapToPosition[] puzzlePieces;

    private void Update()
    {
        if (IsPuzzleComplete())
        {
            Debug.Log("Puzzle Tamamlandı!");
            // Oyun tamamlandıktan sonra yapılacak işlemler
        }
    }

    private bool IsPuzzleComplete()
    {
        foreach (SnapToPosition piece in puzzlePieces)
        {
            if (!piece.enabled) return false;
        }
        return true;
    }
}
