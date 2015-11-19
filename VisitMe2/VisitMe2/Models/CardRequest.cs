using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisitMe2.Models
{
    public class CardRequest
    {
        public enum CardRequestType
        {
            RequestGetCard = 0,
            RequestGiveCard = 1,
            RequestTradeCard = 2
        }
        public enum RequestState
        {
            RequestRejected = 0,
            RequestAccepted = 1,
            ReciverNotifyed = 2,
            Standby = 3,
            Done = 4
        }


        public int id { get; set; }
        public int senderId { get; set; }
        public int reciverId { get; set; }
        public int cardId { get; set; }
        public CardRequestType requestType { get; set; }
        public RequestState requestState { get; set; }

        public CardRequest()
        {
            requestState = RequestState.Standby;
        }


        public CardRequestType getRequestTypeFromInt(int request)
        {
            switch (request)
            {
                case 0:
                    return CardRequestType.RequestGetCard;
                case 1:
                    return CardRequestType.RequestGiveCard;
                case 2:
                    return CardRequestType.RequestTradeCard;
                default:
                    return CardRequestType.RequestGetCard;
            }
        }
    }
}