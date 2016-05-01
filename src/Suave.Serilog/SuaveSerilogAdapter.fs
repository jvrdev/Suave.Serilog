namespace Suave.Serilog

open Suave.Logging
open Serilog.Events

type LogAdapter (logger : Serilog.ILogger) =
    let mapLevel = function
    | LogLevel.Debug -> LogEventLevel.Debug
    | LogLevel.Error -> LogEventLevel.Error
    | LogLevel.Fatal -> LogEventLevel.Fatal
    | LogLevel.Info -> LogEventLevel.Information
    | LogLevel.Verbose -> LogEventLevel.Verbose
    | LogLevel.Warn -> LogEventLevel.Warning
        
    interface Logger with
        member x.Log level fLine =
            let line = fLine ()
            let serilogLevel = mapLevel level
            match line.``exception`` with
            | Some exn -> logger.Write (serilogLevel, exn, line.message)
            | None -> logger.Write (serilogLevel, line.message)