var same = new Audio();

window.PlayAudio = (elementName, secondName) => {
    if (same == document.getElementById(elementName)) {
        var audio = document.getElementById(elementName).cloneNode(true);
        audio.play();
    } else {
        document.getElementById(elementName).play();
        same = document.getElementById(elementName);
    }

}

window.PauseAudio = (elementName) => {
    document.getElementById(elementName).pause();
}