

using System;

public class ErrorNotification
{
    public string environment { get; set; }
    public string fileName { get; set; }
    public string message { get; set; }
    public string stack { get; set; }
    public string parameters { get; set; }
    public string componentStack { get; set; }
    public Details Details { get; set; }
}

public class Details
{
    public string url { get; set; }
    public string message { get; set; }
    public int httpStatus { get; set; }
}

