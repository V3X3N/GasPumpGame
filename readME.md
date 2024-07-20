# Needle Game

Welcome to the GasPumpGame! 🎯 This Unity project is a fun and interactive game where players can control a needle on a gauge to land it in specific zones. The project is designed with principles of object-oriented design and showcases Unity features.

## 🌟 Features

- **Dynamic Needle Movement**: Control the needle's movement and speed.
- **Interactive UI**: Real-time updates with countdown timers and multipliers.
- **Difficulty Settings**: Adjustable difficulty through a `ScriptableObject`.
- **Responsive Input**: Click on the `GasPump` to start and stop the needle.

## 🛠 Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/V3X3N/GasPumpGame
   ```

2. **Open the Project in Unity**

   - Launch Unity Hub.
   - Click on "Add" and select the cloned project folder.

## 🚀 Usage

1. **Running the Game**

   - Open the project in Unity.
   - Click `Play` to start the game in the Unity Editor.

2. **Controls**

   - **Click on GasPump**: Starts or stops the needle movement.

3. **UI Components**

   - **Gauge**: Displays the needle and countdown timer.
   - **Zones**: Visual indicators for different zones on the gauge.

## 🔧 How It Works

### **Scripts**

- **`NeedleController.cs`**: Manages the needle's movement, speed, and interactions with different zones.
- **`DifficultyData.cs`**: A `ScriptableObject` for configuring game difficulty settings.
- **`PlayerInput.cs`**: Handles player input for starting and stopping the needle.

### **Components**

- **`Needle`**: GameObject representing the needle.
- **`GasPump`**: UI element that triggers the needle's action.

### **ScriptableObject**

- **`DifficultyData`**: Customize game settings such as speed, zone sizes, and multipliers.
