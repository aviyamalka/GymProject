document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        header: { center: 'dayGridMonth,timeGridWeek' },
        plugins: ['dayGrid', 'timegrid', 'list'],
        events: DbConnection.getAllLessons()
    , eventDataTransform: function (obj) {
        debugger;
        var event = {};
       // event.id = 1;
        event.title = obj.branchName + "-" + obj.trainningName;
        event.start = obj.startTime;
        event.end = obj.endTime;
        event.url = 'https://fullcalendar.io/docs/eventClick';
       // event.color = "silver";
     //   event.textColor = "black";
      //  event.icon = obj.icon;
     //   event.url = obj.url;
      //  event.editable = true;
        return event;
        },
    isRTL:true,
        eventClick: function (info) {
            info.jsEvent.preventDefault(); // don't let the browser navigate

            if (info.event.url) {
                window.open(info.event.url);
            }
        },
        views: {
            dayGrid: {
                // options apply to dayGridMonth, dayGridWeek, and dayGridDay views
            },
            timeGrid: {
                // options apply to timeGridWeek and timeGridDay views
            },
            week: {
                // options apply to dayGridWeek and timeGridWeek views
            },
            day: {
                // options apply to dayGridDay and timeGridDay views
            }
        }

    });

    calendar.render();
});