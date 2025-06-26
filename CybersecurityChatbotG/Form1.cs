using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CybersecurityChatbotG
{
   
    public partial class Form1 : Form
    {
        string favouriteTopic = "";
        string userName = "";
        string currentTopic = "";
        int followUpIndex = 0;

        List<string> positiveSentiments = new List<string> { "curious", "interested", "happy", "excited" };
        List<string> negativeSentiments = new List<string> { "worried", "frustrated", "scared", "confused" };

        Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
{
      {
        "phishing", new List<string> {
        "Phishing scams often use emails or fake websites that look like legitimate ones, asking for sensitive data.",
        "To protect yourself, always double-check the sender's email address and avoid clicking on suspicious links.",
        "Phishing attacks can also occur through phone calls (vishing) or text messages (smishing), so be cautious in all forms of communication." }
    },
      {
        "password", new List<string> {
        "Always use strong, unique passwords and enable two-factor authentication (2FA).",
        "Password safety involves using at least 12 characters, mixing symbols, and avoiding personal info.",
        "Do not reuse passwords across different websites; a password manager can help you store and create complex passwords.",
        "Consider using a passphrase made up of random words or a sentence that only makes sense to you, for added security." }
    },
      {
        "privacy", new List<string> {
        "Privacy means controlling your personal info online and understanding what data is collected.",
        "Be careful when sharing personal details online, especially on social media platforms. Review privacy settings regularly.",
        "Use strong privacy settings to limit who can view your posts, photos, and location data on social media.",
        "Consider using encrypted messaging services and a VPN to protect your communications and browsing data." }
    },
      {
        "scam", new List<string> {
        "Scams can come in many forms, like fake job offers or phishing attempts.",
        "Scammers often disguise themselves as trusted sources, so be cautious about unsolicited offers or requests.",
        "To protect yourself, never share personal details or payment information with unverified contacts.",
        "If something seems too good to be true, it probably is. Always verify the legitimacy of offers before taking action." }
    },
      {
        "safe browsing", new List<string> {
        "When browsing safely, make sure to look for 'HTTPS' before entering any personal information.",
        "Avoid clicking on suspicious links in emails or social media messages, even if they seem to come from friends.",
        "Keep your browser and operating system updated to prevent security vulnerabilities from being exploited by hackers.",
        "Be cautious of pop-up ads or downloads from untrusted sources, as they may contain malware or lead to phishing sites." }
    }
};
        public Form1()

        {
            InitializeComponent();
            this.Text = "Cybersecurity Awareness ChatBot";
            AppendChat("Chatbot: Welcome! What's your name?");
            ShowAsciiArt();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtUserInput.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            AppendChat("You" + input);
            txtUserInput.Clear();

            if(string.IsNullOrEmpty(userName))
            {
                userName = input;
                AppendChat($"Chatbot Nice to meet you, {userName}! I'm a CyberAwarenss Chatbot, here to help you stay safe online.");
                AppendChat("Chaybot: Ask me about phishing, password safety, privacy, scams, or safe browsing.");
                return;
            }

            string response = GetChatbotResponse(input.ToLower());
            AppendChat("Chatbot:" + response);
        }
        private void ShowAsciiArt() 
        {
            string asciiArt = @"
                     ███████   ███████╗  
                     ██╔══██╗  ██╔════╝  
                     ██║  ██║  ██║       
                     ██████╔╝  █████╗    
                     ██╔══██╗  ██╔══╝    
                     ██║  ██║  ██║       
                     ███████   ███████  
  
        ██████╗  ██╗   ██╗  ███████   ███████╗  ███████
       ██╔════   ██║   ██║  ██╔══██╗  ██╔════╝  ██╔══██╗
       ██║       ╚██╗ ██╔╝  ██║  ██║  ██║       ██║  ██║
       ██║        ╚████╔╝   ██████╔╝  █████╗    ██████╔╝ 
       ██║          ██║     ██╔══██╗  ██╔══╝    ██╔══██╗
       ╚██████╗     ██║     ██║  ██║  ██║       ██║  ██║
        ╚═════╝     ╚═╝     ███████   ███████   ╚═╝  ╚═╝ 
                                   
          █████╗  ██╗    ██╗  █████╗  ███████  ██████╗  
         ██╔══██╗ ██║    ██║ ██╔══██╗ ██╔══██╗ ██╔═══╝  
         ██║  ██║ ██║    ██║ ██║  ██║ ██║  ██║ ██║      
         ███████║ ██║ █╗ ██║ ███████║ ██████╔╝ █████╗   
         ██╔══██║ ██║███╗██║ ██╔══██║ ██╔══██╗ ██╔══╝   
         ██║  ██║ ╚███╔███╔╝ ██║  ██║ ██║  ██║ ██║      
         ╚═╝  ╚═╝  ╚══╝╚══╝  ╚═╝  ╚═╝ ╚═╝  ╚═╝ ███████     
                 !! Protect Yourself Online !!

";
        txtAsciiArt.Text = asciiArt;
        }

        private void btnPlayGreeting_Click(object sender, EventArgs e)
        {
            PlayVoiceGreeting();
        }

        private void PlayVoiceGreeting()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(@"C:\Users\letha\source\repos\Cybersecurity Chatbot\Cybersecurity Chatbot\bin\greetings.wav"))
                {
                    player.Load();
                    player.Play();
                }
            }
            catch (Exception ex)
            {
               
            }
        }
        
        private void AppendChat(string message)
        {
            txtChatHistory.AppendText(message + Environment.NewLine);
        }

        private string GetChatbotResponse(string question)
        {
            if ((question.Contains("tell me more") || question.Contains("what else") || question.Contains("go on")) && !string.IsNullOrEmpty(currentTopic))
            {
                if (keywordResponses.ContainsKey(currentTopic) && followUpIndex < keywordResponses[currentTopic].Count)
                {
                    string extraInfo = keywordResponses[currentTopic][followUpIndex];
                    followUpIndex++;
                    return $"Sure! {AppendInterestContext(currentTopic, extraInfo)} Do you still want to know more about {currentTopic}?";
                }
                else
                {
                    return $"That's all I have on {currentTopic} for now. Would you like to learn about another topic?";
                }
            }

            if ((question == "no" || question.Contains("no thanks") || question.Contains("not really")) && !string.IsNullOrEmpty(currentTopic))
            {
                currentTopic = "";
                followUpIndex = 0;
                return "Okay, what else would you like to know about?";
            }

            if ((question == "yes" || question.Contains("yes please") || question.Contains("sure")) && !string.IsNullOrEmpty(currentTopic))
            {
                if (keywordResponses.ContainsKey(currentTopic) && followUpIndex < keywordResponses[currentTopic].Count)
                {
                    string nextInfo = keywordResponses[currentTopic][followUpIndex];
                    followUpIndex++;
                    return $"Here's more on {currentTopic}: {AppendInterestContext(currentTopic, nextInfo)} Do you still want to know more about {currentTopic}?";
                }
                else
                {
                    return $"That's all I have on {currentTopic} for now. Would you like to learn about another topic?";
                }
            }

            if (question.Contains("i'm interested in") || question.Contains("my favourite topic is") || question.Contains("is my favourite topic"))
            {
                foreach (string topic in keywordResponses.Keys)
                {
                    if (question.Contains(topic))
                    {
                        favouriteTopic = topic;
                        return $"Got it! I'll remember that you're interested in {topic}.";
                    }
                }
                return "Thanks for sharing! I'll try to remember your interest.";
            }

            if (question.Contains("what is my favourite topic") || question.Contains("what's my favourite topic"))
            {
                if (!string.IsNullOrEmpty(favouriteTopic))
                {
                    return $"Your favourite topic is {favouriteTopic}. Would you like to learn more about it?";
                }
                else
                {
                    return "I don't think you've told me your favourite topic yet.";
                }
            }

            foreach (var word in negativeSentiments)
            {
                if (question.Contains(word.ToLower()))
                {
                    return "It sounds like you're having a tough time. I'm here to help with anything cybersecurity-related.";
                }
            }

            foreach (var word in positiveSentiments)
            {
                if (question.Contains(word.ToLower()))
                {
                    return "I'm glad you're feeling good! Let's keep learning about staying safe online.";
                }
            }

            foreach (var keyword in keywordResponses.Keys)
            {
                if (question.Contains(keyword))
                {
                    currentTopic = keyword;
                    followUpIndex = 0;
                    return $"Here's some info on {keyword}: {keywordResponses[keyword][0]} Would you like to know more?";
                }
            }

            switch (question)
            {
                case "how are you?":
                    return "I'm just a bot, but I'm here to help you stay safe online!";
                case "what's your purpose?":
                    return "I'm a cybersecurity awareness bot, designed to educate you on online safety and digital security.";
                default:
                    return "I'm not sure I understand. Could you try rephrasing or ask another cybersecurity-related question?";
            }
        }

        private string AppendInterestContext(string topic, string message)
        {
            if (!string.IsNullOrEmpty(favouriteTopic) && topic == favouriteTopic)
            {
                message += $" Since you're interested in {topic}, be sure to check your settings and stay updated!";
            }
            return message;
        }
    }
}