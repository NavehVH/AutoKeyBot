# AutoKeyBot

**AutoKeyBot** is a Windows Forms application written in C# that automates gameplay based on user-defined logic. It offers two primary modes of operation:

### Script Bot Mode
Write and compile your own custom code using the provided **Botting API**, allowing for more flexible and high-performance behavior based on game data.

### Regular Bot Mode
Configure how the player behaves in response to in-game events using an intuitive UI with built-in features.

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

## ## Bot Management & Monitoring

Each botting instance can be saved to an MSSQL database, ensuring that your information, code, and settings are preserved across sessions.

A built-in debug console is available to help you test and troubleshoot your custom code. The provided API includes methods for interacting with the debug tools directly.

The application includes a dedicated UI window that displays real-time data about the bot and the player. This makes it easier to customize and monitor the bot’s behavior.

*(Insert bot UI screenshot here)*

---

## Script Bot Mode

The Script Bot Mode provides access to a custom API via an included DLL, which exposes methods to control the player and retrieve live gameplay data.

*(Insert API methods image here)*

You can also define **"Timer" events** — sequences of keystrokes that are executed automatically at specified intervals while the script bot is active.

All user-written code is placed inside a provided `Main()` method. When the bot runs, this method is executed in a continuous loop, enabling persistent logic and automation.

You can start or pause the bot at any time through the application interface.

*(Insert script code GIF/example here)*

---

## Regular Bot Mode

This mode allows you to create a bot **without writing any code**. You define a table of keystroke inputs along with the duration each input should be held. The bot will execute this sequence in an endless loop until it is paused or stopped.

*(Insert main key table image here)*

To enhance customization, Regular Bot Mode includes a feature called **Events**. Events allow you to define conditions that, when met in-game, trigger an alternative sequence of actions (a different input table) while the event is active.

Supported event types include:

- **Player Position** – Triggers if the player is within a specific range on the map
- **Other Player in Map** – Triggers if another player is detected nearby
- **Player Health** – Triggers if the player's health drops below a defined threshold
- **Timer Event** – Triggers every X seconds

*(Insert event example images here)*

All features work seamlessly together, allowing you to define complex behaviors and precisely control how your player reacts to in-game situations.

---

## Botting Session Settings

The botting session includes its own configurable settings, allowing for personalized and responsive automation. You can:

- Enable a notification sound when another player appears on the map
- Enable a notification sound after a specified amount of time has passed since the bot started
- Automatically move the bot window to the top-left corner of the screen when it starts
- Choose how the Regular Bot should behave when the player moves out of a defined range (e.g., stop current actions, trigger a fallback event, etc.)

*(Insert botting session settings image here)*

---

## Extra Features and Functionality

- Full ability to **save, edit, and delete** all bots, settings, and configurations
- **Responsive UI** that remains functional and interactive while the bot is running
- Option to **manually define screen coordinates** for reading player position and health via pixel data
- UI layout is **responsive to different screen sizes** and resolutions for a smooth user experience

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
