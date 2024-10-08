﻿using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConferenceAPI.Models
{

    //constructor fara parametri pt entity framework
    //constructor with params to create participant email notification - use template for message
    //constructor with params to create speaker email notification - use template for message
    public partial class EmailNotification : Notification
    {
        public string To { get; set; } = null!;
        public string Cc { get; set; } = null!;
        public string Subject { get; set; } = null!;

        public EmailNotification() : base(null, string.Empty, string.Empty) { }

        public EmailNotification(string participantName, string conferenceName, string speakerNames, DateTime date, string location, string to, string cc, string subject)
            : base(null, "Hello, {0}! You have been enrolled in the course {1}. It will be led by {2}, starting on {3} at {4}, located at {5}.", string.Empty)
        {
            To = to;
            Cc = cc;
            Subject = subject;
            Message = FormatParticipantMessage(participantName, conferenceName, speakerNames, date, location);
        }

        public EmailNotification(string speakerName, string conferenceName, DateTime date, string location, string to, string cc, string subject)
            : base(null, string.Empty, "Hello, {0}! You have been assigned as a speaker for the course {1}, scheduled for {2} at {3}, at {4}.")
        {
            To = to;
            Cc = cc;
            Subject = subject;
            Message = FormatSpeakerMessage(speakerName, conferenceName, date, location);
        }

        private string FormatParticipantMessage(string participantName, string conferenceName, string speakerNames, DateTime date, string location)
        {
            return string.Format("Hello, {0}! You have been enrolled in the course {1}. It will be led by {2}, starting on {3} at {4}, located at {5}.",
                participantName, conferenceName, speakerNames, date.ToString("MM/dd/yyyy"), date.ToString("HH:mm"), location);
        }

        private string FormatSpeakerMessage(string speakerName, string conferenceName, DateTime date, string location)
        {
            return string.Format("Hello, {0}! You have been assigned as a speaker for the course {1}, scheduled for {2} at {3}, at {4}.",
                speakerName, conferenceName, date.ToString("MM/dd/yyyy"), date.ToString("HH:mm"), location);
        }
    }
}
