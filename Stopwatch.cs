using System;
using System.Runtime.InteropServices;
using System.Security;

//Stopwatch myTimer = new Stopwatch(); 
//
//myTimer.Start();
//
//// Do some stuff here
//
//myTimer.Stop();
//
//// Show Results
//
//double result = myTimer.Elapsed.TotalMilliseconds;
//
//Console.WriteLine( "Elapsed milliseconds: {0}", result );
//
//// If you want a new timing, just reset the current timer
//
//myTimer.Reset();

namespace TimeManagedCode.Diagnostics
{
	#region Stopwatch class

	/// <summary>
	/// Managed wrapper class to encapsulate the Microsoft® Win32® functions 
	/// QueryPerformanceCounter and	QueryPerformanceFrequency. This class is compatible
	/// with .NET Framework 2.0 version.
	/// </summary>
	/// <remarks>
	/// This class provides access to the Kernel32.dll high resolution clock API.  
	/// This is motivated by the need to have higher resolution than .Net's
	/// DateTime.Now, which is about 10ms.  The effective resolution
	/// of this class on a P4 1.4GHz is about 10us.
	/// <seealso cref="System.TimeSpan"/>
	/// <seealso cref="System.DateTime"/>
	/// <para>
	/// <b>Note</b>: If QueryPerformanceCounter is not present, will fallback to <see cref="DateTime.Now"/> value.
	/// </para>
	/// </remarks>
	public class Stopwatch
	{
		#region Private Fields

		private long elapsed;
		private bool isRunning;
		private long startTimeStamp;
		private static readonly double tickFrequency;
		// (A tick is 100 nanoseconds.)
		private const long TicksPerMillisecond = TimeSpan.TicksPerMillisecond;
		private const long TicksPerSecond = TimeSpan.TicksPerSecond;

		#endregion

		#region Constructors

		/// <summary>
		/// Static initializer.
		/// </summary>
		static Stopwatch()
		{
			bool isHiResolution = SafeNativeMethods.QueryPerformanceFrequency(out Stopwatch.Frequency);
			
			if( !isHiResolution )
			{
				Stopwatch.IsHighResolution = false;
				Stopwatch.Frequency = TicksPerSecond;
				Stopwatch.tickFrequency = 1f;
				return; 
			}
			Stopwatch.IsHighResolution = true;
			Stopwatch.tickFrequency = (double)TicksPerSecond;
			Stopwatch.tickFrequency /= (double)Stopwatch.Frequency;
		}

		/// <summary>
		/// Default initializer.
		/// </summary>
		public Stopwatch()
		{
			this.Reset();
		}

		#endregion

		#region Public Fields

		/// <summary>
		/// This returns the number of high performance counter ticks (NOT .Net ticks) per second,
		/// as measured by Kernel32.dll's QueryPerformanceFrequency() function.
		/// </summary>
		public static readonly long Frequency;
		
		/// <summary>
		/// True if the HighRes Timer is enabled.
		/// </summary>
		public static readonly bool IsHighResolution;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the <see cref="TimeSpan"/> time between the <see cref="Start"/> and <see cref="Stop"/> methods.
		/// </summary>
		public TimeSpan Elapsed
		{
			get
			{
				return new TimeSpan( this.GetElapsedDateTimeTicks() ); 
			}
		}

		/// <summary>
		/// Gets the elapsed miliseconds between the <see cref="Start"/> and <see cref="Stop"/> methods.
		/// </summary>
		public long ElapsedMilliseconds
		{
			get
			{
				return( this.GetElapsedDateTimeTicks() / TicksPerMillisecond ); 
			} 
		}
		
		/// <summary>
		/// Gets the elapsed hires clock Ticks between the <see cref="Start"/> and <see cref="Stop"/> methods.
		/// </summary>
		public long ElapsedTicks
		{
			get
			{
				return this.GetRawElapsedTicks(); 
			}
		}
		
		/// <summary>
		/// Gets if the Stopwatch is running or not.
		/// </summary>
		public bool IsRunning
		{
			get
			{
				return this.isRunning; 
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets the elapsed time between Start and Stop methods.
		/// </summary>
		/// <returns></returns>
		public static long GetTimeStamp()
		{
			long high = 0;

			if(Stopwatch.IsHighResolution)
			{
				SafeNativeMethods.QueryPerformanceCounter(out high);
				return high; 
			}

			// Fallback to Ticks
			return DateTime.Now.Ticks;
		}

		/// <summary>
		/// Reset the stop watch values.
		/// </summary>
		public void Reset()
		{
			this.elapsed = 0;
			this.isRunning = false;
			this.startTimeStamp = 0;
		}

		/// <summary>
		/// Start the time measurement.
		/// </summary>
		public void Start()
		{
			if (!this.isRunning)
			{
				this.startTimeStamp = Stopwatch.GetTimeStamp();
				this.isRunning = true; 
			}
		}

		/// <summary>
		/// Gets the singleton <see cref="Stopwatch"/> instance and starts the timer.
		/// </summary>
		/// <returns></returns>
		public static Stopwatch StartNew()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			return stopwatch;
		}

		/// <summary>
		/// End the time measurement.
		/// </summary>
		public void Stop()
		{
			long endTime;
			long duration;

			if (this.isRunning)
			{
				endTime = Stopwatch.GetTimeStamp();
				duration = (endTime - this.startTimeStamp);
				this.elapsed += duration;
				this.isRunning = false; 
			}
		}

		#endregion

		#region Private Methods

		private long GetElapsedDateTimeTicks()
		{
			double high;
			long rawElapsed = this.GetRawElapsedTicks();

			if (Stopwatch.IsHighResolution)
			{
				high = (double)rawElapsed;
				high *= Stopwatch.tickFrequency;
				return (long)high; 
			}
			return rawElapsed;
		}

		private long GetRawElapsedTicks()
		{
			long tstamp;
			long delta;
			long elap = this.elapsed;

			if (this.isRunning)
			{
				tstamp = Stopwatch.GetTimeStamp();
				delta = (tstamp - this.startTimeStamp);
				elap += delta; 
			}
			return elap;
		}

		#endregion
	}
	#endregion

	#region SafeNativeMethods class

	/// <summary>
	/// Class for handling safe platform invoke declarations.
	/// </summary>
	[SuppressUnmanagedCodeSecurity]
	internal sealed class SafeNativeMethods
	{
		#region "DllImport functions"

		[DllImport("kernel32.dll")]
		public static extern bool QueryPerformanceFrequency(out long lpFrequency);

		[DllImport("kernel32.dll")]
		public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

		#endregion
	}

	#endregion
}
