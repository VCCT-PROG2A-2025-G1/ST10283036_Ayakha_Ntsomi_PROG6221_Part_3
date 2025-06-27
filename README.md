# 🛡️ Cybersecurity Awareness Chatbot (C# Console App)

This **C# Console Chatbot** helps users learn and practice basic cybersecurity awareness. Designed to simulate a **friendly and intelligent assistant**, it delivers cybersecurity tips and insights in a conversational manner.

## 🎯 Features

### 🔊 Voice Greeting *(Windows only)*
- Plays a welcome audio (`greetings.wav`) when the app starts to greet the user.

### 🎨 ASCII Logo
- Loads and displays branding from an `ascii.txt` file to create a custom terminal aesthetic.

### 🧠 Smart Responses & Keyword Detection
- Responds intelligently to cybersecurity-related questions using **keyword matching** (e.g., “phishing”, “passwords”, “2FA”).
- Provides quick, factual advice to help users stay safe online.

### 💬 Conversation Memory
- Recalls the last discussed topic to follow up on user queries.
- Remembers the user’s favorite topic (if mentioned) to personalize future interactions.

### 😊 Sentiment Awareness
- Recognizes emotional cues like "worried" or "confused" and replies empathetically to offer reassurance or clarification.

### ⌨️ Typing Animation
- Simulates a typing effect when the bot responds, creating a more human-like interaction.

### ✅ Input Validation
- Gracefully handles blank, null, or invalid user inputs with helpful prompts.

### 🚀 GitHub Actions CI
- Includes a GitHub Actions workflow to:
  - Validate builds using the .NET SDK.
  - Ensure project integrity during commits and pushes.

## ▶️ How to Run the Bot

### **Option 1: Visual Studio**
1. Open the project `.sln` file in Visual Studio.
2. Build and run the application (`F5` or click "Start").

### **Option 2: .NET CLI**
```bash
dotnet run
```

## 📁 Project Structure

```plaintext
/Chatbot
├── greetings.wav        # Voice greeting audio
├── ascii.txt            # ASCII art for console branding
├── Program.cs           # Main chatbot logic
├── Bot.cs               # Chatbot responses and memory
├── GitHub/workflows
│   └── dotnet.yml       # GitHub Actions CI workflow
└── README.md            # Project description (you are here)
```

## 🛠️ Technologies Used
- C# (.NET 6 or later)
- Windows Forms Console I/O
- GitHub Actions CI/CD
- WAV file audio playback (System.Media)
- Basic NLP via `string.Contains` and pattern matching

## 💡 Future Enhancements (Ideas)
- Implement a GUI version with Windows Forms or WPF.
- Add scheduling for real reminders.
- Integrate external cybersecurity news API.
- Export conversation history or logs.

## 🤝 Contribution
Pull requests are welcome. For major changes, please open an issue first to discuss your ideas.

## 📜 License
This project is licensed under the MIT License.
