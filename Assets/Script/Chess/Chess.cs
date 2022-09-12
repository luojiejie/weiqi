using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ChessGame
{
    public class Chess : UIBehaviour
    {
        [SerializeField] private Image Image;
        [SerializeField] private Sprite White;
        [SerializeField] private Sprite Black;

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

        public void SetChess(EChess Chess)
        {
            if (Chess == EChess.Black)
            {
                this.Image.sprite = White;
            }
            else
            {
                this.Image.sprite = Black;
            }
        }
    }
}