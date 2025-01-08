using System.Diagnostics;
using AudioSwitcher.AudioApi.CoreAudio;

namespace MyPC.commands.imple;

[CommandProvider(true)]
public class SetVolumeCommand : Command
{
    public SetVolumeCommand() : base("SetVolume", new List<Param>
    {
        new Param { Name = "Volume" },
        new Param { Name = "Mute" }
    }) { }

    public override void Handle(List<Param> _params)
    {
        string volumeString = GetParamValue(_params, "Volume");
        string muteString = GetParamValue(_params, "Mute");
        
        if (!Utils.EqualsIgnoreCase(volumeString, ""))
        {
            try
            {
                int volume = int.Parse(volumeString);
                CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
                defaultPlaybackDevice.Volume = volume;
            }
            catch (Exception ignore)
            {
                
            }
        }
        
        if (!Utils.EqualsIgnoreCase(muteString, ""))
        {
            try
            {
                bool mute = bool.Parse(muteString);
                CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
                defaultPlaybackDevice.Mute(mute);
            }
            catch (Exception ignore)
            {
                
            }
        }
    }
}