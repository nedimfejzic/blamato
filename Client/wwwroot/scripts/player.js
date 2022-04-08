function SetPlayerVolume(playerId, newVolume) {
    document.getElementById(playerId).volume = newVolume;
    console.log("playerId - " + playerId + "| volume is - "+ newVolume);
}


function StartPlayer(playerId) {

    document.getElementById(playerId).play()
}


function StopPlayer(playerId) {

    document.getElementById(playerId).pause()
}