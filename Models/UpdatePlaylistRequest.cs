namespace SparkMusicBridge.Models
{
    public record UpdatePlaylistRequest(string TargetPlaylistName, List<string> AmazonTrackIds);
}
