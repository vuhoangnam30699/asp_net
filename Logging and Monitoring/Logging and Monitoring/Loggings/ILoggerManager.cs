﻿namespace Logging_and_Monitoring.Loggings
{
	public interface ILoggerManager
	{
		void LogInfo(string message);
		void LogWarn(string message);
		void LogDebug(string message);
		void LogError(string message);
	}
}
