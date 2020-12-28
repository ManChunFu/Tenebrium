using UnityEngine;
using UnityEngine.Playables;

namespace Timeline
{
    public class SubtitleClip : PlayableAsset
    {
        public Color TextColor = Color.white;
        public float TypingSpeed = 10.0f;

        [TextArea(3, 10)]
        public string SubtitleText;

        private void OnEnable()
        {
            //if (TextFont == null)
            //    TextFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<SubtitleProperty>.Create(graph);

            SubtitleProperty subtitleProperty = playable.GetBehaviour();
            subtitleProperty.TextColor = TextColor;
            subtitleProperty.TypingSpeed = TypingSpeed;
            subtitleProperty.SubtitleText = SubtitleText;

            return playable;
        }
    }
}
