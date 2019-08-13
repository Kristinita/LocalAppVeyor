﻿using LocalAppVeyor.Engine.Configuration;

namespace LocalAppVeyor.Engine.Internal.Steps
{
    internal sealed class OnFinishStep : ScriptBlockExecuterStep
    {
        public OnFinishStep(string workigDirectory, ScriptBlock scriptBlock)
            : base(workigDirectory, scriptBlock)
        {
        }
    }
}