using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private Text textArea;

        private OpenAIApi openai = new OpenAIApi();

        private string userInput;
        private string Instruction = "Act as a random stranger in a chat room and reply to the questions.\nQ: ";

        public UnityEvent OnReplyReceived;

        public UnityEvent OnAnswerSent;

        private void Start()
        {
            button.onClick.AddListener(SendReply);
        }

        private async void SendReply()
        {
            userInput = inputField.text;
            Instruction += $"{userInput}\nA: ";
            
            textArea.text = "...";
            inputField.text = "";

            button.enabled = false;
            inputField.enabled = false;

            // Complete the instruction
            var completionResponse = await openai.CreateCompletion(new CreateCompletionRequest()
            {
                Prompt = Instruction,
                Model = "text-davinci-003",
                MaxTokens = 128
            });

            // Here we invoke the trigger to animation TALK
            OnReplyReceived.Invoke();
            
            textArea.text = completionResponse.Choices[0].Text;
            Instruction += $"{completionResponse.Choices[0].Text}\nQ: ";

            button.enabled = true;
            inputField.enabled = true;
            
            // Here we return the animation to NORMAl, if we want
            OnAnswerSent.Invoke();
        }
    }
}