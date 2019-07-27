
var eventsArr = {
        events: DbConnection.getAllLessons()
        , eventDataTransform: function (obj) {
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
        }
    }
   // eventsArr.push(EntityEvents);
//var y = {

//}
//YaelF check


$(function () {
    debugger;
    //var calendarParent = $('#calendarParent');
    var calSettings = EladCalendar.Settings.CalSettings;
    var viewTypes = EladCalendar.Settings.ViewTypes;
    calSettings.select = function (start, end) {
        $.getScript('/events/new', function () { });
        calendar.fullCalendar('unselect');
    };

    calSettings.eventClick = function (event, jsEvent, view) {
        jsEvent.preventDefault();
        debugger;
        $('#subject').html(event.title);
        $('#startTime').html(moment(event.start).format("HH:mm") + " :שעת התחלה");
        // }
        $("#recordUrl").attr("href", event.url);
        $("#recordUrl").attr("target", "_blank");
        $(".modal-footer").attr('dir', 'rtl');
        $('#endTime').html(event.end ? moment(event.end).format("HH:mm") + " :שעת סיום" : null);
        $('#myModal').modal();
    };

    //innerHTML: "<span class="fc-title">תפיסת 5 משאבים שונים</span> <span class="fc-time">07:30</span>"
    //This way the new_description isnt inserted into <div class="fc-content"> but after it, element isn't fc-content
    //calSettings.eventRender = function (event, element) {
    //  element.find(".fc-title").remove();
    //  element.find(".fc-time").remove();
    //  var new_description = '<span dir=rtl><b>' + moment(event.start).format("HH:mm") + ' - </b></span> <span>' + event.title + '</span>'
    //  element.append(new_description);
    //};

    calSettings.eventRender = function (event, element) {
        debugger;
        var limit = 25;
        var iconImg = "";
        var title = "";
        if (event.title.length > limit) {
            title = event.title.substr(0, limit) + "...";
        }
        else {
            title = event.title;
        }
        if (event.icon != null && event.icon != "") {
            iconImg = "<img src='" + event.icon + "' width='18' height='18'>";
        }
        element.find(".fc-title").remove();
        element.find(".fc-time").remove();
        var new_description = '<div dir=rtl>' + iconImg + "  " + moment(event.start).format("HH:mm") + ' - ' + ((event.end != null) ? moment(event.end).format("HH:mm") : "") + " " + title + '</div>';
        //var new_description = '<div dir=rtl>' + "<img src='" + "../WebResources/new_appointment.png" + "' width='15' height='15'>" + "   " + moment(event.start).format("HH:mm") + ' - ' + title + '</div>';
        element.append(new_description);
    }
    calSettings.eventMouseover = function (calEvent, jsEvent) {
        var tooltip = '<div class="tooltipevent" style="">' + calEvent.title + '</div>';
        var $tooltip = $(tooltip).appendTo('body');

        $(this).mouseover(function (e) {
            $(this).css('z-index', 10000);
            $tooltip.fadeIn('500');
            $tooltip.fadeTo('10', 1.9);
        }).mousemove(function (e) {
            $tooltip.css('top', e.pageY + 10);
            $tooltip.css('left', e.pageX + 20);
        });
    },

        calSettings.eventMouseout = function (calEvent, jsEvent) {
            $(this).css('z-index', 8);
            $('.tooltipevent').remove();
        },
        calSettings.windowResize = function (view) {
            var d = new Date();
            console.log("Resized: " + d)
        };

    //Initialization
    var calendar = $('#calendar').fullCalendar(calSettings);
    var dropDown = "";
    dropDown += ('<select class="select_view form-control">');
    Object.keys(viewTypes).forEach(function (key) {
        dropDown += ('<option value="' + key + '">' + viewTypes[key] + '</option>');
    });
    dropDown += ('</select>');
    $(".fc-right").append(dropDown);

    //$(".fc-right").append('<select class="select_view form-control">' +
    //                      '<option value="month">חודש</option>' +
    //                      '<option value="basicWeek">שבוע</option>' +
    //                      '<option value="basicDay">יום</option>' +
    //                      '</select>');

    $(".select_view").on("change", function (event) {
        calendar.fullCalendar('changeView', this.value);
        calendar.fullCalendar('gotoDate', Date.now());
    });
    //for (j = 0; j < eventsArr.length; j++) {
        calendar.fullCalendar('addEventSource', eventsArr);
    //}
    // calendar.fullCalendar('addEventSource', x);
    // calendar.fullCalendar('addEventSource', e);
    // calendar.fullCalendar('addEventSource', j);
    // calendar.fullCalendar('addEventSource', y);
    //calendar.find(".fc-center").prop('dir', 'rtl');
});

