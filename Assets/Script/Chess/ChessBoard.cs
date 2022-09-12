using System;
using System.Collections;
using System.Collections.Generic;
using ChessGame;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] private int Size;
    [SerializeField] private BoardGrid GridTemplate;
    [SerializeField] private Chess ChessTemplate;
    [SerializeField] private Image BoardImage;
    
    private List<BoardGrid> GridList;
    private float Grid_Width;
    private float Grid_Height;
    
    void Start()
    {
        GridList = new List<BoardGrid>();
        if (BoardImage)
        {
            int totalNum = Size * Size;
            for (int i = 0; i < totalNum; i++)
            {
                BoardGrid Grid = Instantiate(GridTemplate);
                Grid.InitBoard(this, i / Size - Size/2, i % Size - Size/2);
                print("grid : x: "+ Grid.x + " y: " + Grid.y);
                Grid.rectTransform.SetParent(transform);
                GridList.Add(Grid);
            }
        }
    }

    public void OnRestart()
    {
        foreach (var Grid in GridList)
        {
            Chess RemovedChess = Grid.RemoveChess();
            if (RemovedChess)
            {
                Destroy(RemovedChess.gameObject);
            }
        }
    }

    /// <summary>
    /// 尝试是否有吃子
    /// </summary>
    public void TryEat()
    {
        
    }

    public void OnGridClicked(BoardGrid Grid)
    {
        EChess ChessType = EChess.Black;
        if (ChessMgr.Instance.Turn == ETurn.White)
            ChessType = EChess.White;
        
        if (Grid.IsEmpty())
        {
            Chess NewChess = SpawnChess(ChessType);
            NewChess.rectTransform.SetParent(Grid.rectTransform);
            NewChess.rectTransform.localPosition = Vector3.zero;
            Grid.PutOnChess(NewChess);
            SoundMgr.Instance.PlayVoiceChessDown();
        }
        else
        {
            Chess RemovedChess = Grid.RemoveChess();
            Destroy(RemovedChess.gameObject);
            SoundMgr.Instance.PlayVoiceChessUp();
        }
    }

    /// <summary>
    /// 创建棋子
    /// </summary>
    /// <returns></returns>
    private Chess SpawnChess(EChess ChessType)
    {
        Chess NewChess = Instantiate(ChessTemplate);
        if (ChessType == EChess.Black)
        {
            NewChess.SetChess(EChess.White);
        }
        else
        {
            NewChess.SetChess(EChess.Black);
        }
        return NewChess;
    }

}
