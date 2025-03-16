using System;
using System.Security.Claims;

namespace SmartHomeSystem
{
    // Enum to define device commands
    public enum DeviceCommand
    {
        TurnOn,
        TurnOff,
        SetTemperature,
        ActivateAlarm
    }

    // TODO: Define a delegate named "CommandHandler" that takes a DeviceCommand as a parameter named "command".
    public delegate void CommandHandler(DeviceCommand command);

    public class SmartHomeController
    {
        // TODO: Declare an event named "OnCommandReceived" using the delegate
        public event CommandHandler OnCommandReceived;

        public void ExecuteCommand(DeviceCommand command)
        {
            Console.WriteLine($"\n[Controller] Executing command: {command}");

            if (OnCommandReceived != null)
            {
                OnCommandReceived(command);
            }
        }
    }

    // TODO: Create a class "Light" with a method "HandleCommand" that reacts to TurnOn and TurnOff commands.
    public class Light
    {
        public void HandleCommand(DeviceCommand command)
        {
            switch (command)
            {
                case DeviceCommand.TurnOn:
                    Console.WriteLine("[Light] Turning ON");
                    break;
                case DeviceCommand.TurnOff:
                    Console.WriteLine("[Light] Turning OFF");
                    break;
            }
        }
    }

    // TODO: Create a class "AC" with a method "HandleCommand" that reacts to SetTemperature and TurnOff commands.
    public class AC
    {
        public void HandleCommand(DeviceCommand command)
        {
            switch (command)
            {
                case DeviceCommand.SetTemperature:
                    Console.WriteLine("[AC] Setting temperature");
                    break;
                case DeviceCommand.TurnOff:
                    Console.WriteLine("[AC] Turning OFF");
                    break;
            }
        }
    }

    // TODO: Create a class "Alarm" with a method "HandleCommand" that reacts to ActivateAlarm and TurnOff commands.
    public class Alarm
    {
        public void HandleCommand(DeviceCommand command)
        {
            switch (command)
            {
                case DeviceCommand.ActivateAlarm:
                    Console.WriteLine("[Alarm] Activating alarm system");
                    break;
                case DeviceCommand.TurnOff:
                    Console.WriteLine("[Alarm] Turning OFF");
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create controller and devices
            SmartHomeController controller = new SmartHomeController();
            Light light = new Light();
            AC ac = new AC();
            Alarm alarm = new Alarm();

            // TODO: Subscribe the device methods to the controller event.
            controller.OnCommandReceived += light.HandleCommand;
            controller.OnCommandReceived += ac.HandleCommand;
            controller.OnCommandReceived += alarm.HandleCommand;

            // TODO: Simulate different commands being executed.
            controller.ExecuteCommand(DeviceCommand.TurnOn);
            controller.ExecuteCommand(DeviceCommand.TurnOff);
            controller.ExecuteCommand(DeviceCommand.SetTemperature);
            controller.ExecuteCommand(DeviceCommand.ActivateAlarm);
        }
    }
}