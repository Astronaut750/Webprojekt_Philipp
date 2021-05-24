function flipBoard(id, itemtype, imagepath, altpath) {
    var flip = document.getElementById('shopItem-' + id);

    if (itemtype == "Deck") {
        if (flip.src.substring(22) == imagepath) flip.src = altpath;
        else                                     flip.src = imagepath;
    }
}