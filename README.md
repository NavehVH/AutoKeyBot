# AutoKeyBot

**AutoKeyBot** is a Windows Forms application written in C# that automates gameplay based on user-defined logic. It offers two primary modes of operation:

### Regular Bot Mode
Configure how the player behaves in response to in-game events using an intuitive UI with built-in features.

### Script Bot Mode
Write and compile your own custom code using the provided **Botting API**, allowing for more flexible and high-performance behavior based on game data.

---

## How It Works

AutoKeyBot simulates keystrokes using the Windows API to control the player in-game. It gathers in-game information by analyzing pixel data from the screen, enabling it to detect:

- Player position  
- Presence of other players on the map  
- Health levels  
- Additional in-game status

All components run concurrently using multithreading, enabling smooth and responsive automation.

With access to real-time game data, you can create complex behaviors triggered by conditions such as:

- Player position  
- Time-based events  
- Health thresholds  
- Any custom condition you define

---

## Botting

Each botting instance can be saved to an MSSQL database, ensuring that your information, code, and settings are preserved across sessions.

A built-in debug console is available to help you test and troubleshoot your custom code. The provided API includes methods for interacting with the debug tools directly.

The application includes a dedicated UI window that displays real-time data about the bot and the player. This makes it easier to customize and monitor the bot’s behavior.

*(Insert bot UI screenshot here)*

---

## Script Bot Mode

The Script Bot Mode provides access to a custom API with methods that allow you to control the player and retrieve live data during gameplay.

*(Insert API methods image here)*

You can also define **"Timer" events** — sequences of keystrokes that are executed automatically at specified intervals while the script bot is active.

All user-written code is placed inside a provided `Main()` method. When the bot runs, this method is executed in a continuous loop, enabling persistent logic and automation.

You can start or pause the bot at any time through the application interface.

*(Insert script code GIF/example here)*

---

## Technologies Used
- C#
- WinForms (.NET)
- Windows API (`SendInput`, `PostMessage`)
- Input Simulation
- Timers

---

## Disclaimer

This software is provided for educational and personal automation purposes only.  
The author does not condone or encourage the use of this tool to violate the Terms of Service of any software, game, or platform.

By using this software, you acknowledge that:
- You are solely responsible for how you use it.
- The author assumes no liability for any consequences, including account bans, data loss, or other damages resulting from misuse.
- You agree to comply with all applicable laws and service agreements when using this tool.

**Use responsibly.**

---

## License

MIT License – See [`LICENSE`](LICENSE) for full details.
