using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.UI;

namespace Timeline
{
    public class SubtitleTrackMixer : PlayableBehaviour
    {
        private string currentEntireText = "";
        private float textIndex = 0.0f;
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            Text text = playerData as Text;
            if (!text)
                return;

            string partialText = "";

            int inputCount = playable.GetInputCount();
            for (int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);

                if (inputWeight > 0f)
                {
                    ScriptPlayable<SubtitleProperty> inputPlayable = (ScriptPlayable<SubtitleProperty>)playable.GetInput(i);

                    SubtitleProperty input = inputPlayable.GetBehaviour();

                    if (input.SubtitleText != currentEntireText)
                    {
                        textIndex = 0;
                        currentEntireText = input.SubtitleText;
                    }
                    partialText = (textIndex < currentEntireText.Length) ? currentEntireText.Substring(0, (int)textIndex) : currentEntireText;
                    partialText += "<color=#00000000>" + ((int)textIndex > currentEntireText.Length ? "" : currentEntireText.Substring((int)textIndex)) + "</color>";

                    textIndex += input.TypingSpeed * Time.deltaTime;
                    text.color = new Color(input.TextColor.r, input.TextColor.g, input.TextColor.b, inputWeight);
                }
            }

            if (text.text != partialText)
                text.text = partialText;
        }
    }
}
