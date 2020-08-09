window.showAlert = (elementId, time) => {
    console.log(elementId)
    if (document.querySelector(elementId)) {
        $(document).ready(function () {
            $(elementId).show('fast');

            console.log(time);
            if (time) {
                setTimeout(function () {
                    $(elementId).hide('fast');
                }, time);
            }
        });
    }
}