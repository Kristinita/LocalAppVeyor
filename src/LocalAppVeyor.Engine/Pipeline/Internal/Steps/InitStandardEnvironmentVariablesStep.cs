﻿using System;
using System.Security;

namespace LocalAppVeyor.Engine.Pipeline.Internal.Steps
{
    internal class InitStandardEnvironmentVariablesStep : IInternalEngineStep
    {
        public bool Execute(ExecutionContext executionContext)
        {
            executionContext.Outputter.Write("Initializing environment variables...");

            try
            {
                Environment.SetEnvironmentVariable("APPVEYOR_BUILD_FOLDER", executionContext.CloneDirectory);
                Environment.SetEnvironmentVariable("CI", "False");
                Environment.SetEnvironmentVariable("APPVEYOR", "False");

                if (!string.IsNullOrEmpty(executionContext.CurrentJob.Configuration))
                {
                    Environment.SetEnvironmentVariable("CONFIGURATION", executionContext.CurrentJob.Configuration);
                }

                if (!string.IsNullOrEmpty(executionContext.CurrentJob.Platform))
                {
                    Environment.SetEnvironmentVariable("PLATFORM", executionContext.CurrentJob.Platform);
                }
            }
            catch (SecurityException)
            {
                executionContext.Outputter.WriteError("User has not permissions to write on environment variables.");
                return false;
            }

            executionContext.Outputter.Write("Environment variables initialized.");

            return true;
        }
    }
}