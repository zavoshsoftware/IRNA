function verifyTimer(duration, display) {
    var timer = duration, minutes, seconds;
    setInterval(function () {
        minutes = parseInt(timer / 60, 10);
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        display.textContent = minutes + ":" + seconds;

        if (--timer < 0) {
            document.location.href = "/Login"
        }
    }, 1000);
}

document.addEventListener("DOMContentLoaded", function () {
    verifyTimer(60 * 3, document.querySelector('#time'));
});

if (localStorage.getItem("verify_key") == null)
{
    var currentdate = new Date();
    var datetime = currentdate.getDate() + "/"
        + (currentdate.getMonth() + 1) + "/"
        + currentdate.getFullYear() + "_"
        + currentdate.getHours() + ":"
        + currentdate.getMinutes() + ":"
        + currentdate.getSeconds() + ":"
        + currentdate.getMilliseconds();
    localStorage.setItem("verify_key", datetime);
}