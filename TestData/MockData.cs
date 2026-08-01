using SparkMusicBridge.Models;

namespace SparkMusicBridge.TestData
{
    public class MockData
    {
        public static Playlist GetPlaylist()
        {
            Playlist Result;
            List<TrackItem> tmpTracks;

            try
            {
                tmpTracks = new List<TrackItem>
                {
                    new TrackItem("Song A", "Artist 1"),
                    new TrackItem("Song B", "Artist 1")
                };
                Result = new Playlist(tmpTracks);
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating mock playlist data", ex);
            }
            return Result;
        }
    }
}
