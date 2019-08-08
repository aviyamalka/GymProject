(function (EladCalendar) {

    EladCalendar.Settings =
        {
            ActivityTypes: ["appointment", "serviceappointment"],
            ViewTypes: {
                "month": "חודש",
                "basicWeek": "שבוע",
                "basicDay": "יום",
                //"agendaWeek": "שבוע",
                //"agendaDay": "יום",
            },
            CalSettings: {
                header: {
                    left: 'next, prev today',
                    center: 'title',
                    right: ''
                },
                views: {
                    month: {
                        titleFormat: 'DD/MM/YYYY'
                    },
                    week: {
                        titleFormat: 'DD/MM/YYYY',
                        columnHeaderHtml: function (mom) {
                            return mom.format("ddd") + "<br/>" + mom.format("D");
                        }
                    },
                    day: {
                        titleFormat: 'DD/MM/YYYY'
                    },
                },
                height: 'parent',
                dayPopoverFormat: 'DD/MM/YYYY',
                showNonCurrentDates: false,
                fixedWeekCount: false,
                selectable: true,
                selectHelper: true,
                editable: true,
                timeFormat: 'H:mm',
                eventLimit: true,
                isRTL: true,
                eventSources: [],
            },
        };
})(window.EladCalendar = window.EladCalendar || {});
