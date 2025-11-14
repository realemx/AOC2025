using Cocona;
using AOC.Commands;

var app = CoconaApp.Create();

app.AddCommands<AocCommands>();

app.Run();
