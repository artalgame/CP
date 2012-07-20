function DrawText(text, x, y, fontColor, fontFamily, fontSize, fontStyle) {
    var canvas = document.getElementById("myCanvas");
    var context = canvas.getContext("2d");

    context.fillStyle = fontColor;
    var fontProperties = fontStyle + ' ' + fontSize + 'px ' + fontFamily;
    context.font = fontProperties;
    context.fillText(text, x, y);
};