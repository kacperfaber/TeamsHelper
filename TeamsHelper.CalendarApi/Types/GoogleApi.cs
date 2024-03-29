﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TeamsHelper.CalendarApi
{
    public class GoogleApi
    {
        public IGetCalendarsRequestGenerator GetCalendarsRequestGenerator;
        public IGetCalendarRequestGenerator GetCalendarRequestGenerator;
        public ICreateCalendarRequestGenerator CreateCalendarRequestGenerator;
        public IInsertEventRequestGenerator InsertEventRequestGenerator;
        public IDeleteEventRequestGenerator DeleteEventRequestGenerator;
        public IListEventsRequestGenerator ListEventsRequestGenerator;
        public IUpdateEventRequestGenerator UpdateEventRequestGenerator;

        readonly HttpClient _http = new HttpClient();

        public GoogleApi()
        {
        }

        public GoogleApi(IGetCalendarsRequestGenerator getCalendarsRequestGenerator, ICreateCalendarRequestGenerator createCalendarRequestGenerator,
            IInsertEventRequestGenerator insertEventRequestGenerator, IGetCalendarRequestGenerator getCalendarRequestGenerator,
            IDeleteEventRequestGenerator deleteEventRequestGenerator, IListEventsRequestGenerator listEventsRequestGenerator,
            IUpdateEventRequestGenerator updateEventRequestGenerator)
        {
            GetCalendarsRequestGenerator = getCalendarsRequestGenerator;
            CreateCalendarRequestGenerator = createCalendarRequestGenerator;
            InsertEventRequestGenerator = insertEventRequestGenerator;
            GetCalendarRequestGenerator = getCalendarRequestGenerator;
            DeleteEventRequestGenerator = deleteEventRequestGenerator;
            ListEventsRequestGenerator = listEventsRequestGenerator;
            UpdateEventRequestGenerator = updateEventRequestGenerator;
        }

        public virtual async Task<List<GoogleCalendar>> GetCalendarsAsync(string accessToken)
        {
            HttpRequestMessage req = GetCalendarsRequestGenerator.Generate(accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);

            string content = await response.Content.ReadAsStringAsync();
            List<GoogleCalendar> calendars = JObject.Parse(content)["items"].ToObject<List<GoogleCalendar>>();
            return calendars;
        }

        public virtual async Task<GoogleCalendar> GetCalendar(string calendarId, string accessToken)
        {
            HttpRequestMessage req = GetCalendarRequestGenerator.Generate(calendarId, accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);
            string content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content).ToObject<GoogleCalendar>();
        }

        public virtual async Task<GoogleCalendar> CreateCalendarAsync(GoogleCalendar googleCalendar, string accessToken)
        {
            HttpRequestMessage req = CreateCalendarRequestGenerator.Generate(googleCalendar, accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);

            string content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content).ToObject<GoogleCalendar>();
        }

        public virtual async Task<GoogleEvent> InsertAsync(InsertEventPayload payload, string calendarId, string accessToken)
        {
            HttpRequestMessage request = InsertEventRequestGenerator.Generate(calendarId, payload, accessToken);
            HttpResponseMessage response = await _http.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content).ToObject<GoogleEvent>();
        }

        public virtual async Task DeleteAsync(string calendarId, string eventId, string accessToken)
        {
            HttpRequestMessage request = DeleteEventRequestGenerator.Generate(calendarId, eventId, accessToken);
            await _http.SendAsync(request);
        }

        public virtual async Task<List<GoogleEvent>> ListAsync(string calendarId, DateTime updatedMin, string accessToken)
        {
            HttpRequestMessage request = ListEventsRequestGenerator.Generate(calendarId, updatedMin, accessToken);
            HttpResponseMessage response = await _http.SendAsync(request);
            JObject obj = JObject.Parse(await response.Content.ReadAsStringAsync());
            return obj.SelectToken("items").ToObject<List<GoogleEvent>>();
        }

        public virtual async Task<GoogleEvent> UpdateAsync(UpdateEventPayload updateEventPayload, string calendarId, string eventId,
            string accessToken)
        {
            HttpRequestMessage req = UpdateEventRequestGenerator.Generate(updateEventPayload, calendarId, eventId, accessToken);
            HttpResponseMessage response = await _http.SendAsync(req);
            JObject obj = JObject.Parse(await response.Content.ReadAsStringAsync());
            return obj.ToObject<GoogleEvent>();
        }
    }
}