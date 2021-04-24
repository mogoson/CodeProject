# MGS.Logger

## Summary
- Logger for C# project develop.

## Environment
- .Net Framework 3.5 or above.

## Platform
- Windows.
- Android.

## Demand
- Output log to local file.
- Implement custom logger to output the log that print by LogUtility from other module.

## Implemented

- LogUtility: provide unified entrance of log output.
- FileLogger: provide a default logger that you can use to log to local file.

## Usage

- Register logger to LogUtility.

```c#
var logDir = string.Format("{0}/Log/", Environment.CurrentDirectory);
LogUtility.Register(new FileLogger(logDir));
```

- Use LogUtility to output log content.

```C#
LogUtility.Log("Log info is {0}", info);
LogUtility.LogError("Log error is {0}", error);
LogUtility.LogWarning("Log warning is {0}", warning);
```

------

[Previous](../README.md)

------

Copyright © 2021 Mogoson. All rights reserved.	mogoson@outlook.com