function getTimeRemaining(endtime) {
    var t = Date.parse(endtime) - Date.parse(new Date());
    var seconds;
    var minutes;
    var hours;
    var days;
    if (t > 0) {
         seconds = Math.floor((t / 1000) % 60);
         minutes = Math.floor((t / 1000 / 60) % 60);
         hours = Math.floor((t / (1000 * 60 * 60)) % 24);
         days = Math.floor(t / (1000 * 60 * 60 * 24));
    } else {
        seconds = 0;
        minutes = 0;
        hours = 0;
        days =0;
    }
    return {
        'total': t,
        'days': days,
        'hours': hours,
        'minutes': minutes,
        'seconds': seconds
    };
}

function initializeClock(curClock, endtime, proId) {
    var clock = curClock;
    var daysSpan = clock.querySelector('.days');
    var hoursSpan = clock.querySelector('.hours');
    var minutesSpan = clock.querySelector('.minutes');
    var secondsSpan = clock.querySelector('.seconds');

    function updateClock() {
        var t = getTimeRemaining(endtime);
        daysSpan.innerHTML = t.days;
        hoursSpan.innerHTML = ('0' + t.hours).slice(-2);
        minutesSpan.innerHTML = ('0' + t.minutes).slice(-2);
        secondsSpan.innerHTML = ('0' + t.seconds).slice(-2);

        if (t.total <= 0) {
            clearInterval(timeinterval);
        }
    }

    updateClock();
    var timeinterval = setInterval(updateClock, 1000);
}

$(function () {
    $('.biddingProduct').each(function (number, element) {
        var deadline = new Date(Date.parse($(element).children('input[type=hidden]').val()));
        var curClock = element;
        initializeClock(curClock, deadline);
    });
});