# Suave.Serilog
Get your Suave logs onto Serilog

## How to use
```fsharp
  startWebServer { defaultConfig with logger = Suave.Serilog.LogAdapter Serilog.Log.Logger } app
```
