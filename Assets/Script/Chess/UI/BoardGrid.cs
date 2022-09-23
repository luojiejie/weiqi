using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ChessGame
{
    public class BoardGrid : UIBehaviour
    {
        [SerializeField] private Button Button;
        public int x;
        public int y;
        
        private Chess Chess;
        private ChessBoard ChessBoard;

        private RectTransform m_RectTransform;
        public RectTransform rectTransform
        {
            get
            {
                if (ReferenceEquals(m_RectTransform, null))
                {
                    m_RectTransform = GetComponent<RectTransform>();
                }
                return m_RectTransform;
            }
        }

        public void InitBoard(ChessBoard pBoard, int px, int py)
        {
            this.ChessBoard = pBoard;
            x = px;
            y = py;
        }

        protected override void Start()
        {
            base.Start();
            Button.onClick.AddListener(OnClick);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Button.onClick.RemoveListener(OnClick);
        }

        public bool IsEmpty()
        {
            return Chess == null;
        }

        public void PutOnChess(Chess NewChess)
        {
            if (Chess != null)
            {
                return;
            }
            Chess = NewChess;
        }

        public Chess RemoveChess()
        {
            if (Chess == null)
            {
                return null;
            }

            Chess removedChess = Chess;
            Chess = null;
            return removedChess;
        }
        
        public Chess GetChess()
        {
            return Chess;
        }

        private void OnClick()
        {
            ChessBoard.OnGridClicked(this);
        }
    }
}