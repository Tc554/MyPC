using WindowsInput;
using WindowsInput.Native;

namespace MyPC.commands.imple;

[CommandProvider(true)]
public class KeyboardInputCommad : Command
{
    public KeyboardInputCommad() : base("KeyboardInput", new List<Param>
    {
        new Param { Name = "Input" }
    }) { }

    public override void Handle(List<Param> _params)
    {
        try
        {
            InputSimulator robot = CommandHandler.inputSimulator;

            string input = GetParamValue(_params, "Input");

            string[] splitInput = input.Split(';');

            List<VirtualKeyCode> toRelease = new List<VirtualKeyCode>();
            

            foreach (string s in splitInput)
            {
                if (!VirtualKeyCode.TryParse(s, out VirtualKeyCode vkCode))
                {
                    
                    if (Utils.EqualsIgnoreCase(s.ToUpper(), "%RELEASE%"))
                    {
                        foreach (var virtualKeyCode in toRelease)
                        {
                            robot.Keyboard.KeyUp(virtualKeyCode);
                        }

                        toRelease.Clear();
                    }
                    else
                    {
                        foreach (var c in s.ToCharArray())
                        {
                            if (!VirtualKeyCode.TryParse("VK_" + c.ToString().ToUpper(), out VirtualKeyCode v))
                            {
                                robot.Keyboard.TextEntry(c);
                            }
                            else
                            {
                                robot.Keyboard.KeyDown(v);
                                toRelease.Add(v);
                            }
                        }
                    }
                }
                else
                {
                    robot.Keyboard.KeyDown(vkCode);
                    toRelease.Add(vkCode);
                }
            }
        }
        catch (Exception ignore)
        {
            
        }
    }
}