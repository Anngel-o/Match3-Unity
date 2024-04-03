using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using DG.Tweening;

public class Piece : MonoBehaviour
{
    public int x;
    public int y;
    public Board board;

    private Vector2 initialPosition;
    private Vector2 mouseOffset;

    public enum type{
        android,
        apple,
        computer,
        unity,
        windows
    };

    public type pieceType;

    public void Setup(int x_, int y_, Board board_) {
        x = x_;
        y = y_;
        board = board_;
    }

    public void Move(int desX, int desY) {
        transform.DOMove(new Vector3(desX, desY, -5f), 0.25f).SetEase(Ease.InOutCubic).onComplete = () => {
            x = desX; 
            y = desY;
        };
    }

    //decorador
    [ContextMenu("Test Move")]
    public void MoveTest() {
        Move(0, 0);
    }
}
