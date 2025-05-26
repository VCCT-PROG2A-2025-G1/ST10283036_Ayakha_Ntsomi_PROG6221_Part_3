# Cybersecurity Awareness Bot

This C# Console chatbot helps users learn and practice basic cybersecurity awareness. Also designed to simulate a friendly, intelligent assistant, this bot provides tips on topics like phishing, passwords, scams, and privacyin a conversational manner. It features:

- Voice greeting (Windows Only): Plays a welcome audio (greetings.wav) when the app starts.
- ASCII logo: Displays custom ASCII art from ascii.txt for branding.
- Keyword Detection: Responds intelligently to questions about cybersecurity topics.
- Smart responses to security topics
- Conversation Memory
    - Recalls last discussed topic for follow-ups.
    - Remembers user's favorite topic if mentioned.
- Sentiment Awareness: Responds empathetically to emotional cues (e.g. "worried", "confused).
- Typing Animation: Simulates typing effect for realistic bot experience.
- Input Validation: Gracefully handled null, blank, or invalid input.
- GitHub Actions CI: Includes a workflow to validate build and restore using .NET SDK.

## Run the bot
- Open visual Studioo or run via CLI
'''bash
dotnetrun
