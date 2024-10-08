﻿using System;
using System.Collections.Generic;

namespace ConferenceAPI.Models;

public partial class LogsBackup
{
    public int Id { get; set; }

    public string Message { get; set; } = null!;

    public string? Level { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? Exception { get; set; }

    public string? LogEvent { get; set; }

    public Guid? CorrelationId { get; set; }
}
