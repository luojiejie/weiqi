namespace ChessGame
{
    public enum EChessMode
    {
        Login,
        Lobby,//大厅
        Editor,//编辑
        Game,//游戏中
    }
    
    public enum EGameType
    {
        Prepare,//准备
        Gaming,//游戏中
        End,//结束
    }

    public enum ETurn
    {
        None,
        White,
        Black,
    }

    public enum EChess
    {
        Black,
        White,
    }
}