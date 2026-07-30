var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger UI for easy endpoint testing
app.UseSwagger();
app.UseSwaggerUI();

// 1. POST /api/context
app.MapPost("/api/context", () => Results.Ok(new {
    location = "Lake House",
    timeOfDay = "Evening",
    mood = "Relaxed Acoustic"
}));
// 2. POST /api/music/search (Mocked catalog search)
app.MapGet("/api/music/all", () => Results.Ok);
// 2. POST /api/music/search (Mocked catalog search)
app.MapPost("/api/music/search", (SearchRequest req) => Results.Ok(new {
    resolvedTracks = req.Tracks.Select(t => new {
        title = t.Title,
        artist = t.Artist,
        amazonTrackId = $"amzn1.track.mock_{Guid.NewGuid().ToString()[..8]}"
    })
}));

// 3. POST /api/music/playlist/update (Mocked playlist mutation)
app.MapPost("/api/music/playlist/update", (UpdatePlaylistRequest req) => Results.Ok(new {
    status = "Success",
    playlistId = "amzn1.playlist.mock_12345",
    updatedTrackCount = req.AmazonTrackIds.Count
}));

app.Run();

record TrackItem(string Title, string Artist);
record SearchRequest(List<TrackItem> Tracks);
record UpdatePlaylistRequest(string TargetPlaylistName, List<string> AmazonTrackIds);
