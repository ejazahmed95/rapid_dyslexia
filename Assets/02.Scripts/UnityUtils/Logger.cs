using UnityEngine;

namespace EAUtils {
	public enum LogLevel {
		TRACE = 1,
		DEBUG = 2,
		INFO = 3,
		WARN = 4,
		ERROR = 5,
		FATAL = 6,
	}
	
	public static class Log {
		private static LogLevel level = LogLevel.DEBUG;

		public static void setLogLevel(LogLevel l) {
			level = l;
		}
		
		public static void t(string tag, string message) {
			if (level > LogLevel.TRACE) return;
			Debug.Log($"[T] [{tag}]: {message}");
		}
		
		public static void d(string tag, string message) {
			if (level > LogLevel.DEBUG) return;
			Debug.Log($"[D] [{tag}]: {message}");
		}
		
		public static void i(string tag, string message) {
			if (level > LogLevel.INFO) return;
			Debug.Log($"[I] [{tag}]: {message}");
		}
		
		public static void w(string tag, string message) {
			if (level > LogLevel.WARN) return;
			Debug.LogWarning($"[W] [{tag}]: {message}");
		}
		public static void e(string tag, string message) {
			if (level > LogLevel.ERROR) return;
			Debug.LogError($"[E] [{tag}]: {message}");
		}
		public static void f(string tag, string message) {
			// if (level > LogLevel.INFO) return;
			Debug.LogError($"[Fatal] [{tag}]: {message}");
		}
	}
}