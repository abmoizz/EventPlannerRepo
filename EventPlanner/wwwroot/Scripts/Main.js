$(document).ready(function () {

    $('#EventTable').jtable({
        title: 'The Events List',
        actions: {
            listAction: '/Home/GetAllEvents',
            createAction: '/Home/AddEvent',
            updateAction: '/Home/UpdateEvent',
            deleteAction: '/Home/DeleteEvent'
        },

        fields: {

            "EventId": {
                key: true,
                title: 'Event Id',
                width: '15%',
            },
            "EventDate": {
                title: 'Event Date',
                width: '15%'
            },
            "EventName": {
                title: 'Event name',
                width: '15%'
            }

        }

    });

    $('#EventTable').jtable('load');


})