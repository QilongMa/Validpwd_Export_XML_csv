
//JavaScript Version
window.onload = function () {
    if (document.addEventListener) {
        document.getElementById('button1').addEventListener('click', clickHandler, false);
    }
    else {
        document.getElementById('button1').attachEvent('onclick', clickHandler);
    }
};

function clickHandler() {
    alert('Simple jQuery');
}

//jQuery