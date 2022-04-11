function SetPlayerVolume(playerId, newVolume) {
    document.getElementById(playerId).volume = newVolume;
}


function StartPlayer(playerId) {

    document.getElementById(playerId).play()
}


function StopPlayer(playerId) {

    document.getElementById(playerId).pause()
}