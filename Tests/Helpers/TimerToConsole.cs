﻿#region licence
// The MIT License (MIT)
// 
// Filename: TimerToConsole.cs
// Date Created: 2014/07/21
// 
// Copyright (c) 2014 Jon Smith (www.selectiveanalytics.com & www.thereformedprogrammer.net)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion
using System;
using System.Diagnostics;
using System.Text;

namespace Tests.Helpers
{
    class TimerToConsole : IDisposable
    {

        private readonly Stopwatch _timer;

        private readonly string _message;
        private readonly int _numTimes;

        public TimerToConsole(string message, int numTimes = 0)
        {
            _message = message;
            _numTimes = numTimes;
            _timer = new Stopwatch();
            _timer.Start();
        }

        public void Dispose()
        {
            var timeInMs = 1000.0*_timer.ElapsedTicks/Stopwatch.Frequency;
            var sb = new StringBuilder();
            sb.AppendFormat("{0} took {1:f2} ms", _message, timeInMs);
            if (_numTimes > 0)
                sb.AppendFormat(". Each took {0:f3} ms ({1:#,#}/second)", timeInMs/_numTimes, (int)( _numTimes * 1000/timeInMs));
            Console.WriteLine(sb);
        }
    }
}
