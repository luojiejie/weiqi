using Fun;

namespace ChessGame
{
    public class ChessMgr : SingletonMono<ChessMgr>
    {
        public EChessMode ChessMode = EChessMode.Editor;
        public EGameType GameType = EGameType.Prepare;
        public ETurn Turn = ETurn.None;
        
        
    }
}