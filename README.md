# Cybersecurity Awareness Chatbot (C# Console App)

This **C# Console Chatbot** helps users learn and practice basic cybersecurity awareness. Designed to simulate a **friendly and intelligent assistant**, it delivers cybersecurity tips and insights in a conversational manner while teaching key security concepts.

## Key Features

### Voice Greeting *(Windows only)*
- Plays a welcome audio (`greetings.wav`) when the application starts.

### ASCII Logo
- Loads and displays custom ASCII art from an `ascii.txt` file for a personalized interface.

### Smart Responses & Keyword Detection
- Provides quick advice to help users stay safe online.
- Detects and responds to keywords such as:
  - **phishing**
  - **password**
  - **scams**
  - **privacy**
  - **firewall**

### Conversation Simulation
- Detects emotional cues such as, *"worried"*, *"confused"*, and responds empathetically.
- **Memory**
  -  Recalls the last discussed topic to follow up on user queries.
  -  Rememeber's the users favourite topic mentioned.

### Typing Animation
- Simulates a typing effect when the bot responds, creating a more human-like interaction.

### Input Validation
- Gracefully handles blank, null, or invalid user inputs with helpful prompts.

### GitHub Actions CI
- Includes a GitHub Actions workflow to:
  - Validate builds using the .NET SDK.
  - Ensure project integrity during commits and pushes.

## How to Run the Bot

### **Option 1: Visual Studio**
1. Open the solution in **Visual Studio**.
2. Build and run the application (Press `F5` or click **Start**).

### **Option 2: .NET CLI**
```bash
dotnet run

## 📁 Project Structure

```plaintext
/Chatbot
├── greetings.wav        # Voice greeting audio
├── ascii.txt            # ASCII art for console branding
├── Program.cs           # Main chatbot logic
├── Bot.cs               # Chatbot responses and memory
├── GitHub/workflows
│   └── dotnet.yml       # GitHub Actions CI workflow
└── README.md            # Project description
```

## Technologies Used
- C# (.NET )
- Windows Forms Console I/O
- GitHub Actions CI/CD
- WAV file audio playback (System.Media)
- Basic NLP via `string.Contains` and pattern matching.

## 
## License
This project is licensed under the MIT License.
