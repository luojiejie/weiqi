using Fun;
using UnityEngine;

namespace ChessGame
{
    public class SoundMgr : SingletonMono<SoundMgr>
    {
        [SerializeField] private AudioSource voicePlayer;//定义音频播放器
        [SerializeField] private AudioClip ChessDown;
        [SerializeField] private AudioClip ChessUp;
        readonly float voiceVolumeValue = 0.5f;// 音量默认值
        

        public void PlayVoiceChessDown()
        {
            voicePlayer.PlayOneShot(ChessDown);
        }

        public void PlayVoiceChessUp()
        {
            voicePlayer.PlayOneShot(ChessUp);
        }
    }
}