#region Copyright (c) 2002, James W. Newkirk, Michael C. Two, Alexei A. Vorontsov, Philip A. Craig
/************************************************************************************
'
' Copyright � 2002 James W. Newkirk, Michael C. Two, Alexei A. Vorontsov
' Copyright � 2000-2002 Philip A. Craig
'
' This software is provided 'as-is', without any express or implied warranty. In no 
' event will the authors be held liable for any damages arising from the use of this 
' software.
' 
' Permission is granted to anyone to use this software for any purpose, including 
' commercial applications, and to alter it and redistribute it freely, subject to the 
' following restrictions:
'
' 1. The origin of this software must not be misrepresented; you must not claim that 
' you wrote the original software. If you use this software in a product, an 
' acknowledgment (see the following) in the product documentation is required.
'
' Portions Copyright � 2002 James W. Newkirk, Michael C. Two, Alexei A. Vorontsov 
' or Copyright � 2000-2002 Philip A. Craig
'
' 2. Altered source versions must be plainly marked as such, and must not be 
' misrepresented as being the original software.
'
' 3. This notice may not be removed or altered from any source distribution.
'
'***********************************************************************************/
#endregion

namespace NUnit.Core
{
	using System;
	using System.IO;

	/// <summary>
	/// Summary description for StackTraceFilter.
	/// </summary>
	public class StackTraceFilter
	{
		public static string Filter(string stack) 
		{
			if(stack == null) return null;
			StringWriter sw = new StringWriter();
			StringReader sr = new StringReader(stack);

			try 
			{
				string line;
				while ((line = sr.ReadLine()) != null) 
				{
					if (!FilterLine(line))
						sw.WriteLine(line);
				}
			} 
			catch (Exception) 
			{
				return stack;
			}
			return sw.ToString();
		}

		static bool FilterLine(string line) 
		{
			string[] patterns = new string[]
			{
				"NUnit.Core.TestCase",
				"NUnit.Core.ExpectedExceptionTestCase",
				"NUnit.Core.TemplateTestCase",
				"NUnit.Core.TestResult",
				"NUnit.Core.TestSuite",
				"NUnit.Framework.Assertion" 
			};

			for (int i = 0; i < patterns.Length; i++) 
			{
				if (line.IndexOf(patterns[i]) > 0)
					return true;
			}

			return false;
		}

	}
}
