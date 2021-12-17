using StopWatchesCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StopWatchesCore.Services
{
    public interface IStopWatchService
    {
        void CreateStopWatch(SotpWatch input);
        SotpWatch GetStopWatch(int id);
    }
}
