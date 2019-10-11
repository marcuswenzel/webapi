using FPWEB.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPWEB.API.Domain.Communication
{
    public class ParticipantResponse : BaseResponse
    {
        public Participant Participant { get; protected set; }

        private ParticipantResponse(bool success, string message, Participant participant) : base(success, message)
        {
            this.Participant = participant;
        }

        public ParticipantResponse(Participant participant) : this(true, string.Empty, participant)
        { }

        public ParticipantResponse(string message) : this(false, message, null)
        { }
    }
}
