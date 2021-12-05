window.PlayAudio = (elementName) => {
        var audio = document.getElementById(elementName).cloneNode(true);
        audio.play();
}

window.PauseAudio = (elementName) => {
    document.getElementById(elementName).pause();
}